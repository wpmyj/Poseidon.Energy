﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poseidon.Energy.Test
{
    using Poseidon.Winform.Base;
    using Poseidon.Energy.ClientDx;

    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void menuTargetOverview_Click(object sender, EventArgs e)
        {
            ChildFormManage.LoadMdiForm(this, typeof(FrmTargetOverview));
        }

        private void menuTargetMake_Click(object sender, EventArgs e)
        {
            ChildFormManage.LoadMdiForm(this, typeof(FrmTargetMake));
        }

        private void menuPopulationOverview_Click(object sender, EventArgs e)
        {
            ChildFormManage.LoadMdiForm(this, typeof(FrmPopulationOverview));
        }

        private void menuFundOverview_Click(object sender, EventArgs e)
        {
            ChildFormManage.LoadMdiForm(this, typeof(FrmFundOverview));
        }

        private void menuDepartmentOverview_Click(object sender, EventArgs e)
        {
            ChildFormManage.LoadMdiForm(this, typeof(FrmDepartmentOverview));
        }

        private void menuExpenseOverview_Click(object sender, EventArgs e)
        {
            //ChildFormManage.LoadMdiForm(this, typeof(FrmExpenseOverview));
        }

        private void menuExpenseAccount_Click(object sender, EventArgs e)
        {
           
        }

        private void menuExpenseReceipt_Click(object sender, EventArgs e)
        {
          
        }

        private void menuPopulationManage_Click(object sender, EventArgs e)
        {
            ChildFormManage.LoadMdiForm(this, typeof(FrmPopulationManage));
        }

        private void menuFundManage_Click(object sender, EventArgs e)
        {
            ChildFormManage.LoadMdiForm(this, typeof(FrmFundManage));
        }

        private void menuMeasureManage_Click(object sender, EventArgs e)
        {
            ChildFormManage.LoadMdiForm(this, typeof(FrmMeasureManage));
        }

        private void menuMeasureOverview_Click(object sender, EventArgs e)
        {
            ChildFormManage.LoadMdiForm(this, typeof(FrmMeasureOverview));
        }

        private void menuSettlementManage_Click(object sender, EventArgs e)
        {
            ChildFormManage.LoadMdiForm(this, typeof(FrmSettlementManage));
        }

        private void menuSettlementOverview_Click(object sender, EventArgs e)
        {
            ChildFormManage.LoadMdiForm(this, typeof(FrmSettlementOverview));
        }
    }
}
