using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace DLLImportDemo
{


    public static class Native32
    {

        [DllImport(@"C:\Users\serhiy\source\repos\SystemPromming\Debug\DemoDll.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double Add(double a, double b);
        [DllImport(@"C:\Users\serhiy\source\repos\SystemPromming\Debug\DemoDll.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double Mul(double a, double b);

        [DllImport(@"C:\Users\serhiy\source\repos\SystemPromming\Debug\DemoDll.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double Div(double a, double b);

        [DllImport(@"C:\Users\serhiy\source\repos\SystemPromming\Debug\DemoDll.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double Sub(double a, double b);

        [DllImport(@"C:\Users\serhiy\source\repos\SystemPromming\Debug\DemoDll.dll", CallingConvention = CallingConvention.Cdecl,CharSet =CharSet.Ansi)]
        public static extern long testString(string s);
        [DllImport("user32.dll")]
        public static extern void MessageBox(int hWnd, String text,String caption,uint uType =0x00000002);



    }
}
