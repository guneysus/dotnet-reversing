using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static DbgNet.Core.NativeMethods;

namespace DbgNet.Core
{

    public enum FileMapAccessType : uint
    {
        Copy = 0x01,
        Write = 0x02,
        Read = 0x04,
        AllAccess = 0x08,
        Execute = 0x20,
    }

}
