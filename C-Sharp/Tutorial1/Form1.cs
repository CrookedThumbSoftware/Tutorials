/**
 * @file   Form1.cs
 * @Author Frank (Frank@CrookedThumbSoftware.com)
 * @date   November 2012
 * @brief  Will display a gui with a button and respond with a message when clicked
 * Copyright (c) 2012, Crooked Thumb Software, All rights reserved.
 *
 * The tutorial C# file that handles the form.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tutorial
{
    /**
     * The class will display the form and respond to the button click
     */
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /**
         * Function called in response to button1 click
         */
        private void button1_Click(object sender, EventArgs e)
        {
            //Show the message
            MessageBox.Show("The 1st tutorial Windows app in the book!");
        }
    }
}
