using MicGuard.Services.Enums;
using System.Runtime.InteropServices;

namespace MicGuard.Services
{
    public static class CoreAudio
    {
        [ComImport, Guid("BCDE0395-E52F-467C-8E3D-C4579291692E")]
        public class MMDeviceEnumerator { }

        [ComImport, Guid("A95664D2-9614-4F35-A746-DE8DB63617E6"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IMMDeviceEnumerator
        {
            [PreserveSig] int EnumAudioEndpoints(EDataFlow eDataFlow, int dwStateMask, out IMMDeviceEnumerator ppDevices);
            [PreserveSig] int GetDefaultAudioEndpoints(EDataFlow eDataFlow, ERole eRole, out IMMDevice ppDevice);
        }

        [ComImport, Guid("D666063F-1587-4E43-81F1-B948E807363F"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IMMDevice
        {
            [PreserveSig] int Activate(ref Guid iid, int dwClsCtx, IntPtr pActivationParams, [MarshalAs(UnmanagedType.IUnknown)] out object ppInterface);
            [PreserveSig] int OpenPropertyStore(int stgmAccess, out IntPtr ppProperties);
            [PreserveSig] int GetId(out IntPtr ppstrId);
            [PreserveSig] int GetState(out int pdwState);
        }

        [ComImport, Guid("5CDF2C82-841E-4546-9722-0CF74078229A"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IAudioEndpointVolume
        {
            [PreserveSig] int RegisterControlChangeNotify(IAudioEndpointVolumeCallback pNotify);
            [PreserveSig] int UnregisterControlChangeNotify(IAudioEndpointVolumeCallback pNotify);
            [PreserveSig] int GetChannelCount();
            [PreserveSig] int SetMasterVolumeLevel();
            [PreserveSig] int SetMasterVolumeLevelScalar(float fLevel, ref Guid pguidEventContext);
            [PreserveSig] int GetMasterVolumeLevel(out float pfLevel);
            [PreserveSig] int GetMasterVolumeLevelScalar(out float pfLevel);
        }

        [Guid("657804FA-D6AD-4496-8A60-352752AF4F89"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IAudioEndpointVolumeCallback
        {
            [PreserveSig] int OnNotify(IntPtr pNotify);
        }
    }
}