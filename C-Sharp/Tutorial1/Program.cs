/**
 * @file   Program.cs
 * @Author Frank (Frank@CrookedThumbSoftware.com)
 * @date   November 2012
 * @brief  The initial program.  Will display the form 1.
 * Copyright (c) 2012, Crooked Thumb Software, All rights reserved.
 *
 * The main program class file
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Tutorial
{
    /**
     * The static class used for the initial call
     */
    static class Program
    {
        /** 
         * <summary> The main entry point for the application.</summary>
         **/
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Show the custom form1
            Application.Run(new Form1());
        }
    }
}
