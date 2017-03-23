﻿using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Poseidon.Energy.ClientDx.Report
{
    using DevExpress.XtraReports.UI;
    using Poseidon.Base.Framework;
    using Poseidon.Energy.Core.BL;
    using Poseidon.Energy.Core.DL;

    /// <summary>
    /// 部门指标计划单报表
    /// </summary>
    public partial class RepDepartmentTarget : DevExpress.XtraReports.UI.XtraReport
    {
        #region Field
        /// <summary>
        /// 缓存部门
        /// </summary>
        private List<Department> departments;
        #endregion //Field

        #region Constructor
        public RepDepartmentTarget()
        {
            InitializeComponent();
            InitData();
        }
        #endregion //Constructor

        #region Function
        private void InitData()
        {
            this.departments = BusinessFactory<DepartmentBusiness>.Instance.FindAll().ToList();
        }
        #endregion //Function

        #region Event
        private void lbDepartment_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var id = this.GetCurrentColumnValue<string>("DepartmentId");
            var dep = this.departments.Find(r => r.Id == id);
            if (dep == null)
                this.lbDepartment.Text = "";
            else
                this.lbDepartment.Text = dep.Name;
        }

        private void lbType_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var type = this.GetCurrentColumnValue<int>("Type");
            if (type == 1)
                this.lbType.Text = "电指标";
            else if (type == 2)
                this.lbType.Text = "水指标";
        }

        private void lbTotalQuantum_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var type = this.GetCurrentColumnValue<int>("Type");
            var quantum = this.GetCurrentColumnValue<decimal>("PlanQuantum");
            if (type == 1)
                this.lbTotalQuantum.Text = string.Format("{0} 度", quantum);
            else if (type == 2)
                this.lbTotalQuantum.Text = string.Format("{0} 吨", quantum);
        }

        private void tableHeadAT_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var at = this.GetCurrentColumnValue("AllowanceTarget") as List<AllowanceTarget>;
            if (at.Count == 0)
                this.tableHeadAT.Visible = false;
            else
                this.tableHeadAT.Visible = true;
        }

        private void tableBodyAT_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var at = this.GetCurrentColumnValue("AllowanceTarget") as List<AllowanceTarget>;
            if (at.Count == 0)
                this.tableBodyAT.Visible = false;
            else
                this.tableBodyAT.Visible = true;
        }
        #endregion //Event
    }
}
