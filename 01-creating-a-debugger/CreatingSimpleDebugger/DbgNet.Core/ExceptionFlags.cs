using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static DbgNet.Core.NativeMethods;

namespace DbgNet.Core
{

    public enum ExceptionFlags
    {
        EXCEPTION_CONTINUABLE = 0x00,
        EXCEPTION_NONCONTINUABLE = 0x01
    }

}
