using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static DbgNet.Core.NativeMethods;

namespace DbgNet.Core
{


    [Flags]
    public enum FinalPathFlags : uint
    {
        VOLUME_NAME_DOS = 0x0,
        FILE_NAME_NORMALIZED = 0x0,
        VOLUME_NAME_GUID = 0x1,
        VOLUME_NAME_NT = 0x2,
        VOLUME_NAME_NONE = 0x4,
        FILE_NAME_OPENED = 0x8
    }

}
