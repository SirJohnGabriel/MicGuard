using MicGuard.Services;
using MicGuard.Services.Enums;
using System.Security.Cryptography;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace MicGuard.Ui;

public partial class MicGuard : Form
{
    private VolumeWatcher? watcher;
    private CoreAudio.IAudioEndpointVolume? vol;
    private bool active = false;

    public float targetVolume = 0.0f;
    CoreAudio.IMMDeviceEnumerator _enum = (CoreAudio.IMMDeviceEnumerator)new CoreAudio.MMDeviceEnumerator();
    ERole role = new();
    CoreAudio.IMMDevice? dev = null;

    public MicGuard()
    {
        InitializeComponent();
        this.FormClosing += MicGuard_FormClosing;
        notifyIcon1.MouseDoubleClick += notifyIcon1_MouseDoubleClick;

        var trayMenu = new ContextMenuStrip();
        trayMenu.Items.Add("Show", null, (_, _) => ShowFromTray());
        trayMenu.Items.Add("Exit", null, (_, _) => ExitApp());
        notifyIcon1.ContextMenuStrip = trayMenu;

        try
        {
            int defaultAudioEndpoint = _enum.GetDefaultAudioEndpoints(EDataFlow.eCapture, role, out dev);
            Console.WriteLine($"Default Audio Endpoint: {defaultAudioEndpoint}");

            Guid iid = typeof(CoreAudio.IAudioEndpointVolume).GUID;

            int hrAct = dev.Activate(ref iid, 23, IntPtr.Zero, out object obj);
            vol = (CoreAudio.IAudioEndpointVolume)obj;

            int hrVol = vol.GetMasterVolumeLevelScalar(out float level);

            watcher = new VolumeWatcher(vol, targetVolume);
            int hrReg = vol.RegisterControlChangeNotify(watcher);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }

    private void MicGuard_Load(object? sender, EventArgs e)
    {
        targetVolume = Properties.Settings.Default.targetVolume * 100;
        checkBox1.Checked = Properties.Settings.Default.systemTray;

        label1.Text = ((int)targetVolume).ToString();
        trackBar1.Value = (int)targetVolume;
        label2.Text = "Inactive";
        label2.ForeColor = SystemColors.ControlText;
    }

    private void button1_Click(object? sender, EventArgs e)
    {
        if (dev is null) return;

        try
        {
            float.TryParse(label1.Text, out float percent);
            float scalar = percent / 100f;
            Console.WriteLine($"Target Volume: {scalar:P0}");

            if (watcher is not null && vol is not null)
            {
                watcher.SetTarget(scalar);
                Guid ctx = Guid.Empty;
                vol.SetMasterVolumeLevelScalar(scalar, ref ctx);

                targetVolume = percent;

                if (!active)
                {
                    active = true;
                    label2.Text = "Active";
                    label2.ForeColor = Color.Green;
                }

                Properties.Settings.Default.targetVolume = scalar;
                Properties.Settings.Default.Save();
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }

    private void trackBar1_Scroll(object? sender, EventArgs e)
    {
        label1.Text = trackBar1.Value.ToString();
    }

    private void MicGuard_FormClosing(object? sender, FormClosingEventArgs e)
    {
        if (e.CloseReason == CloseReason.UserClosing && checkBox1.Checked)
        {
            trackBar1.Value = (int)targetVolume;
            label1.Text = targetVolume.ToString();
            Console.WriteLine($"Target Volume upon close: {targetVolume}");
            e.Cancel = true;
            this.Hide();

            notifyIcon1.Visible = true;
        }
    }

    private void notifyIcon1_MouseDoubleClick(object? sender, MouseEventArgs e)
    {
        ShowFromTray();
    }

    private void ShowFromTray()
    {
        this.Show();
        this.WindowState = FormWindowState.Normal;
        this.Activate();
    }

    private void ExitApp()
    {
        notifyIcon1.Visible = false;
        Application.Exit();
    }

    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
        Properties.Settings.Default.systemTray = checkBox1.Checked;
        Properties.Settings.Default.Save();
    }
}
