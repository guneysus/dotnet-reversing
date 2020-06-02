using System.Runtime.InteropServices;

namespace win32api_sandbox
{
    public class NativeMethods {

        [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool FreeConsole();
    }
}
