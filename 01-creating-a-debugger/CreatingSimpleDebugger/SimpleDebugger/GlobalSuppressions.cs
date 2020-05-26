// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Major Code Smell", "S4214:\"P/Invoke\" methods should not be visible", Justification = "<Pending>", Scope = "member", Target = "~M:NativeMethods.DebugActiveProcess(System.Int32)~System.Boolean")]
[assembly: SuppressMessage("Major Code Smell", "S4200:Native methods should be wrapped", Justification = "<Pending>", Scope = "member", Target = "~M:SimpleDebugger.NativeMethods.DebugActiveProcess(System.Int32)~System.Boolean")]
[assembly: SuppressMessage("Major Code Smell", "S4200:Native methods should be wrapped", Justification = "<Pending>", Scope = "member", Target = "~M:SimpleDebugger.NativeMethods.CreateProcess(System.String,System.String,SimpleDebugger.NativeMethods.SECURITY_ATTRIBUTES@,SimpleDebugger.NativeMethods.SECURITY_ATTRIBUTES@,System.Boolean,SimpleDebugger.NativeMethods.CreateProcessFlags,System.IntPtr,System.String,SimpleDebugger.NativeMethods.STARTUPINFO@,SimpleDebugger.NativeMethods.PROCESS_INFORMATION@)~System.Boolean")]
[assembly: SuppressMessage("Major Code Smell", "S4214:\"P/Invoke\" methods should not be visible", Justification = "<Pending>", Scope = "member", Target = "~M:SimpleDebugger.NativeMethods.DebugActiveProcess(System.Int32)~System.Boolean")]
[assembly: SuppressMessage("Major Code Smell", "S4200:Native methods should be wrapped", Justification = "<Pending>", Scope = "member", Target = "~M:SimpleDebugger.NativeMethods.CheckRemoteDebuggerPresent(System.IntPtr,System.Boolean@)~System.Boolean")]
[assembly: SuppressMessage("Minor Code Smell", "S101:Types should be named in PascalCase", Justification = "<Pending>", Scope = "type", Target = "~T:SimpleDebugger.NativeMethods.PROCESS_INFORMATION")]
