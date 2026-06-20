using System.Runtime.InteropServices;

namespace MicGuard.Ui;

static class Program
{
    [DllImport("Kernel32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool AllocConsole();

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.

        AllocConsole();
        Console.WriteLine("Console Attached");
        ApplicationConfiguration.Initialize();
        Application.Run(new MicGuard());
    }    
}