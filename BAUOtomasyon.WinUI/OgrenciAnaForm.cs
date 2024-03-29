﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BAUOtomasyon.WinUI
{
    public partial class OgrenciAnaForm : Form
    {
        public OgrenciAnaForm()
        {
            InitializeComponent();
        }

        private void kaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OgrenciForm ogrForm = new OgrenciForm();
            ogrForm.MdiParent = this;
            ogrForm.Show();
        }

        private void güncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OgrenciIletisimForm frm = new OgrenciIletisimForm();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
