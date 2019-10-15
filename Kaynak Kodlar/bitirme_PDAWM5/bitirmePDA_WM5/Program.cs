using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace bitirmePDA_WM5
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [MTAThread]
        static void Main()
        {
            Application.Run(new giris());
        }
    }
}