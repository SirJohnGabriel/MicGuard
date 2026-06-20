using MicGuard.Services.Structs;
using System.Runtime.InteropServices;
using static MicGuard.Services.CoreAudio;

namespace MicGuard.Services
{
    public class VolumeWatcher : IAudioEndpointVolumeCallback
    {
        private readonly IAudioEndpointVolume vol;
        private float target;
        private static Guid id = Guid.NewGuid();

        public VolumeWatcher(IAudioEndpointVolume vol, float target) => (this.vol, this.target) = (vol, target);

        public int OnNotify(IntPtr pNotify)
        {
            var d = Marshal.PtrToStructure<AUDIO_VOLUME_NOTIFICATION_DATA>(pNotify);

            if (d.guidEventContext == id) return 0;

            if (Math.Abs(d.fMasterVolume - target) > 0.001f)
            {
                Console.WriteLine($"Volume {d.fMasterVolume:P0} locking to {target:P0}");
                vol.SetMasterVolumeLevelScalar(target, ref id);
            }
            return 0;
        }

        public void SetTarget(float target)
        {
            this.target = target;
        }
    }
}
