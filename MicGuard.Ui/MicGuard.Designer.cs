namespace MicGuard.Ui;

partial class MicGuard
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MicGuard));
        button1 = new Button();
        trackBar1 = new TrackBar();
        label1 = new Label();
        notifyIcon1 = new NotifyIcon(components);
        checkBox1 = new CheckBox();
        label2 = new Label();
        toolTip1 = new ToolTip(components);
        ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
        SuspendLayout();
        // 
        // button1
        // 
        button1.AccessibleName = "";
        button1.Location = new Point(197, 77);
        button1.Name = "button1";
        button1.Size = new Size(75, 23);
        button1.TabIndex = 0;
        button1.Text = "Set Volume";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // trackBar1
        // 
        trackBar1.Location = new Point(12, 26);
        trackBar1.Maximum = 100;
        trackBar1.Name = "trackBar1";
        trackBar1.Size = new Size(412, 45);
        trackBar1.TabIndex = 1;
        trackBar1.Value = 100;
        trackBar1.Scroll += trackBar1_Scroll;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(430, 35);
        label1.Name = "label1";
        label1.Size = new Size(25, 15);
        label1.TabIndex = 2;
        label1.Text = "100";
        // 
        // notifyIcon1
        // 
        notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
        notifyIcon1.Text = "notifyIcon1";
        notifyIcon1.Visible = true;
        notifyIcon1.MouseDoubleClick += notifyIcon1_MouseDoubleClick;
        // 
        // checkBox1
        // 
        checkBox1.AutoSize = true;
        checkBox1.Location = new Point(12, 124);
        checkBox1.Name = "checkBox1";
        checkBox1.Size = new Size(155, 19);
        checkBox1.TabIndex = 3;
        checkBox1.Text = "Minimize to System Tray";
        toolTip1.SetToolTip(checkBox1, "Clicking X minimizes the app instead of closing it completely.");
        checkBox1.UseVisualStyleBackColor = true;
        checkBox1.CheckedChanged += checkBox1_CheckedChanged;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(423, 128);
        label2.Name = "label2";
        label2.Size = new Size(38, 15);
        label2.TabIndex = 4;
        label2.Text = "label2";
        // 
        // toolTip1
        // 
        toolTip1.ToolTipIcon = ToolTipIcon.Info;
        toolTip1.ToolTipTitle = "Minimize to System Tray";
        // 
        // MicGuard
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(473, 147);
        Controls.Add(label2);
        Controls.Add(checkBox1);
        Controls.Add(label1);
        Controls.Add(trackBar1);
        Controls.Add(button1);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        Name = "MicGuard";
        Text = "Mic Guard";
        Load += MicGuard_Load;
        ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button button1;
    private TrackBar trackBar1;
    private Label label1;
    private NotifyIcon notifyIcon1;
    private CheckBox checkBox1;
    private Label label2;
    private ToolTip toolTip1;
}
