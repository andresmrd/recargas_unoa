using System;
using System.Runtime.InteropServices;

namespace VentasUNOA
{
    public class RawPrinterHelper
    {
        [StructLayout(LayoutKind.Sequential)]
        public class DOCINFOA
        {
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDocName;

            [MarshalAs(UnmanagedType.LPStr)]
            public string pOutputFile;

            [MarshalAs(UnmanagedType.LPStr)]
            public string pDataType;
        }

        [DllImport("winspool.Drv", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "OpenPrinterA", ExactSpelling = true, SetLastError = true)]
        public static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPStr)] string szPrinter, out IntPtr hPrinter, IntPtr pd);

        [DllImport("winspool.Drv", CallingConvention = CallingConvention.StdCall, ExactSpelling = true, SetLastError = true)]
        public static extern bool ClosePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "StartDocPrinterA", ExactSpelling = true, SetLastError = true)]
        public static extern bool StartDocPrinter(IntPtr hPrinter, int level, [MarshalAs(UnmanagedType.LPStruct)] [In] RawPrinterHelper.DOCINFOA di);

        [DllImport("winspool.Drv", CallingConvention = CallingConvention.StdCall, ExactSpelling = true, SetLastError = true)]
        public static extern bool EndDocPrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", CallingConvention = CallingConvention.StdCall, ExactSpelling = true, SetLastError = true)]
        public static extern bool StartPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", CallingConvention = CallingConvention.StdCall, ExactSpelling = true, SetLastError = true)]
        public static extern bool EndPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", CallingConvention = CallingConvention.StdCall, ExactSpelling = true, SetLastError = true)]
        public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, int dwCount, out int dwWritten);

        public static bool SendBytesToPrinter(string szPrinterName, IntPtr pBytes, int dwCount)
        {
            int num = 0;
            IntPtr hPrinter = new IntPtr(0);
            RawPrinterHelper.DOCINFOA dOCINFOA = new RawPrinterHelper.DOCINFOA();
            bool flag = false;
            dOCINFOA.pDocName = "My C#.NET RAW Document";
            dOCINFOA.pDataType = "RAW";
            if (RawPrinterHelper.OpenPrinter(szPrinterName.Normalize(), out hPrinter, IntPtr.Zero))
            {
                if (RawPrinterHelper.StartDocPrinter(hPrinter, 1, dOCINFOA))
                {
                    if (RawPrinterHelper.StartPagePrinter(hPrinter))
                    {
                        flag = RawPrinterHelper.WritePrinter(hPrinter, pBytes, dwCount, out num);
                        RawPrinterHelper.EndPagePrinter(hPrinter);
                    }
                    RawPrinterHelper.EndDocPrinter(hPrinter);
                }
                RawPrinterHelper.ClosePrinter(hPrinter);
            }
            if (!flag)
            {
                Marshal.GetLastWin32Error();
            }
            return flag;
        }

        public static bool SendStringToPrinter(string szPrinterName, string szString)
        {
            int length = szString.Length;
            IntPtr intPtr = Marshal.StringToCoTaskMemAnsi(szString);
            RawPrinterHelper.SendBytesToPrinter(szPrinterName, intPtr, length);
            Marshal.FreeCoTaskMem(intPtr);
            return true;
        }
    }
}
