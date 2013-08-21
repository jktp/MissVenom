﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace MissVenom
{
    public partial class frmIpPick : Form
    {
        public string[] IpAddresses { get; set; }

        public frmIpPick()
        {
            InitializeComponent();
            if (IpAddresses != null && IpAddresses.Any())
            {
                var bindableIp = (from ip in IpAddresses select new { Address = ip }).ToList();
                grdIp.DataSource = bindableIp;
                grdIp.Refresh();
            }
        }

        public string SelectedIP()
        {
            return IpAddresses[grdIp.CurrentRow.Index];
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (grdIp.SelectedRows != null && grdIp.SelectedRows.Count == 1)
                DialogResult = System.Windows.Forms.DialogResult.OK;
            else
                DialogResult = System.Windows.Forms.DialogResult.Abort;
        }
    }
}
