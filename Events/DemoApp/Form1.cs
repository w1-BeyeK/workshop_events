﻿using AlarmLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoApp
{
    public partial class Form1 : Form
    {
        public Clock Clock { get; set; }

        public Form1()
        {
            InitializeComponent();
        }
    }
}
