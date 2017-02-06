﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lasetCtrl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            timer.Interval = (100);
            timer.Tick += new EventHandler(updateSignals);
            
            timer.Start();
            

              m_plc = new plc();


            if (m_plc.connect())
                lconnect.Text = "connect";
            else
                lconnect.Text = "connection  error";




            
        }

        private void updateSignals(object sender, EventArgs e)
        {
            tb_inc.Text = m_plc.tags.getInc().ToString();


        }

        plc m_plc;
  
        private Timer timer = new Timer();

        private void btCtl_Click(object sender, EventArgs e)
        {
            var val = UInt16.Parse(tb_ctl.Text);
            m_plc.tags.setInc(val);
        }
    }
}