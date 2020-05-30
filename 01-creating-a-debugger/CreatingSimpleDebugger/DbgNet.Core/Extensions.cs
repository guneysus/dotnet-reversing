using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static DbgNet.Core.NativeMethods;

namespace DbgNet.Core
{


    public static class Extensions
    {
        public static string ToHex(this IntPtr value) => String.Format("0x{0:X}", value);
        public static string ToHex(this int value) => String.Format("0x{0:X}", value);
        public static string ToHex(this uint value) => String.Format("0x{0:X}", value);
    }
}
