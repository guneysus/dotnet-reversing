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
        public static string Address(this IntPtr value) => value.ToInt64().Address();
        public static string Address(this UIntPtr value) => value.ToUInt64().Address();
        public static string Address(this Int32 value) => String.Format("0x{0:x}", value);
        public static string Address(this UInt32 value) => String.Format("0x{0:x}", value);
        public static string Address(this Int16 value) => String.Format("0x{0:x}", value);
        public static string Address(this UInt16 value) => String.Format("0x{0:x}", value);
        public static string Address(this Int64 value) => String.Format("0x{0:x}", value);
        public static string Address(this UInt64 value) => String.Format("0x{0:x}", value);
    }
}
