using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace PowerProfileSwitcher
{
    public static class ApiCalls
    {
        public static void PowerOffDisplay()
        {
            if (PostMessage((IntPtr)HWND_BROADCAST, WM_SYSCOMMAND, (IntPtr)SC_MONITORPOWER, (IntPtr)POWER_OFF) == IntPtr.Zero)
            {
                throw new Win32Exception();
            }
        }

        public static void StartScreensaver()
        {
            if (PostMessage((IntPtr)HWND_BROADCAST, WM_SYSCOMMAND, (IntPtr)SC_SCREENSAVE, IntPtr.Zero) == IntPtr.Zero)
            {
                throw new Win32Exception();
            }
        }

        public static void SetLocalExecutionState(bool DisplayRequired, bool SystemRequired)
        {
            SetThreadExecutionState(EXECUTION_STATE.CONTINUOUS |
                (DisplayRequired ? EXECUTION_STATE.DISPLAY_REQUIRED : EXECUTION_STATE.NONE) |
                (SystemRequired ? EXECUTION_STATE.SYSTEM_REQUIRED : EXECUTION_STATE.NONE));
        }

        public static bool[] GetGlobalExecutionState()
        {
            EXECUTION_STATE result;
            uint status = CallNtPowerInformation(POWER_INFORMATION_LEVEL.SystemExecutionState, IntPtr.Zero, 0, out result, Marshal.SizeOf(typeof(uint)));
            if (status != 0)
                throw new Win32Exception("CallNtPowerInformation failed with status " + status);
            return new bool[] { (result & EXECUTION_STATE.DISPLAY_REQUIRED) != 0, (result & EXECUTION_STATE.SYSTEM_REQUIRED) != 0 };
        }

        public static Dictionary<Guid, string> GetPowerSchemes()
        {
            var result = new Dictionary<Guid, string>();
            var schemeGuid = Guid.Empty;
            uint sizeSchemeGuid = (uint)Marshal.SizeOf(typeof(Guid));
            uint sizeName = 1024;
            IntPtr pSizeName = Marshal.AllocHGlobal((int)sizeName);
            try
            {
                for (uint schemeIndex = 0; PowerEnumerate(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, ACCESS_SCHEME, schemeIndex, ref schemeGuid, ref sizeSchemeGuid) == 0; schemeIndex++)
                {
                    sizeName = 1024;
                    PowerReadFriendlyName(IntPtr.Zero, ref schemeGuid, IntPtr.Zero, IntPtr.Zero, pSizeName, ref sizeName);
                    result.Add(schemeGuid, Marshal.PtrToStringUni(pSizeName));
                }
            }
            finally
            {
                Marshal.FreeHGlobal(pSizeName);
            }
            return result;
        }

        public static Guid ActivePowerScheme
        {
            get
            {
                IntPtr pCurrentSchemeGuid = IntPtr.Zero;
                PowerGetActiveScheme(IntPtr.Zero, ref pCurrentSchemeGuid);
                return (Guid)Marshal.PtrToStructure(pCurrentSchemeGuid, typeof(Guid));
            }
            set
            {
                PowerSetActiveScheme(IntPtr.Zero, ref value);
            }
        }

        #region PInvoke Declarations

        private const uint HWND_BROADCAST = 0xffff, WM_SYSCOMMAND = 0x112, ACCESS_SCHEME = 16;
        private const uint SC_MONITORPOWER = 0xf170, SC_SCREENSAVE = 0xF140, POWER_OFF = 0x2;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("powrprof.dll", SetLastError = false)]
        private static extern UInt32 CallNtPowerInformation(POWER_INFORMATION_LEVEL InformationLevel, IntPtr lpInputBuffer, UInt32 nInputBufferSize, out EXECUTION_STATE lpOutputBuffer, Int32 nOutputBufferSize);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern EXECUTION_STATE SetThreadExecutionState(EXECUTION_STATE esFlags);

        private enum POWER_INFORMATION_LEVEL : uint
        {
            SystemExecutionState = 16
        }

        [Flags]
        private enum EXECUTION_STATE : uint
        {
            NONE = 0,
            AWAYMODE_REQUIRED = 0x00000040,
            CONTINUOUS = 0x80000000,
            DISPLAY_REQUIRED = 0x00000002,
            SYSTEM_REQUIRED = 0x00000001,
        }


        [DllImport("PowrProf.dll")]
        private static extern UInt32 PowerEnumerate(IntPtr RootPowerKey, IntPtr SchemeGuid, IntPtr SubGroupOfPowerSettingGuid, UInt32 AcessFlags, UInt32 Index, ref Guid Buffer, ref UInt32 BufferSize);

        [DllImport("PowrProf.dll")]
        private static extern UInt32 PowerReadFriendlyName(IntPtr RootPowerKey, ref Guid SchemeGuid, IntPtr SubGroupOfPowerSettingGuid, IntPtr PowerSettingGuid, IntPtr Buffer, ref UInt32 BufferSize);

        [DllImport("PowrProf.dll")]
        private static extern uint PowerGetActiveScheme(IntPtr UserRootPowerKey, ref IntPtr ActivePolicyGuid);

        [DllImport("PowrProf.dll")]
        private static extern uint PowerSetActiveScheme(IntPtr UserRootPowerKey, ref Guid SchemeGuid);

        #endregion
    }
}
