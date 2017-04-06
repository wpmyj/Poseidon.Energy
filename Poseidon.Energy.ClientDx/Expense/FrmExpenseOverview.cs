﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poseidon.Energy.ClientDx
{
    using Poseidon.Base.Framework;
    using Poseidon.Base.System;
    using Poseidon.Common;
    using Poseidon.Winform.Base;
    using Poseidon.Energy.Core.BL;
    using Poseidon.Energy.Core.DL;
    using Poseidon.Energy.Core.Utility;

    /// <summary>
    /// 支出总览窗体
    /// </summary>
    public partial class FrmExpenseOverview : BaseMdiForm
    {
        #region Field
        /// <summary>
        /// 当前选择账户
        /// </summary>
        private ExpenseAccount currentAccount;

        /// <summary>
        /// 今年
        /// </summary>
        private int nowYear;
        #endregion //Field

        #region Constructor
        public FrmExpenseOverview()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
        protected override void InitForm()
        {
            this.groupTree.SetGroupCode(EnergyConstant.ExpenseAccountGroupCode);
            this.nowYear = DateTime.Now.Year;
            base.InitForm();
        }

        /// <summary>
        /// 隐藏标签
        /// </summary>
        private void ClearDisplay()
        {
            this.tabPageElectricMeter.PageVisible = false;
            this.tabPageWaterMeter.PageVisible = false;

            this.tabPageElectricCompareGrid.PageVisible = false;
            this.tabPageElectricCompareChart.PageVisible = false;
            this.tabPageElectricReceipt.PageVisible = false;
            this.tabPageWaterCompareGrid.PageVisible = false;
            this.tabPageWaterCompareChart.PageVisible = false;
            this.tabPageWaterReceipt.PageVisible = false;

            this.modElecCompGrid.Clear();
            this.modElectricCompare.Clear();
            this.modWaterCompareGrid.Clear();
            this.modWaterCompare.Clear();
        }

        /// <summary>
        /// 设置账户信息
        /// </summary>
        private void InitAccountInfo()
        {
            this.ctrAccountInfo.SetAccount(this.currentAccount);

            if (this.currentAccount.EnergyType.Contains(1))
            {
                LoadElectric();
            }
            if (this.currentAccount.EnergyType.Contains(2))
            {
                LoadWater();
            }
            if (this.currentAccount.EnergyType.Contains(3))
            { }
            if (this.currentAccount.EnergyType.Contains(4))
            { }
        }

        /// <summary>
        /// 载入电费相关数据
        /// </summary>
        private void LoadElectric()
        {
            // 电表
            this.tabPageElectricMeter.PageVisible = true;
            this.electricMeterGrid.DataSource = this.currentAccount.ElectricMeters;

            // 用电对比表
            this.tabPageElectricCompareGrid.PageVisible = true;
            this.modElecCompGrid.SetAccount(this.currentAccount);

            // 用电对比图
            this.tabPageElectricCompareChart.PageVisible = true;
            this.modElectricCompare.SetAccount(this.currentAccount);

            // 电费单据
            this.tabPageElectricReceipt.PageVisible = true;
            this.electricExpenseReceipt.SetAccount(this.currentAccount);
        }

        /// <summary>
        /// 载入水费相关数据
        /// </summary>
        private void LoadWater()
        {
            // 水表
            this.tabPageWaterMeter.PageVisible = true;
            this.waterMeterGrid.DataSource = this.currentAccount.WaterMeters;

            // 用水对比表
            this.tabPageWaterCompareGrid.PageVisible = true;
            var currentYearList = BusinessFactory<WaterExpenseBusiness>.Instance.FindYearByAccount(this.currentAccount.Id, nowYear).ToList();
            this.modWaterCompareGrid.SetAccount(this.currentAccount);

            // 用水对比图
            this.tabPageWaterCompareChart.PageVisible = true;
            this.modWaterCompare.SetAccount(this.currentAccount);

            // 水费单据
            this.tabPageWaterReceipt.PageVisible = true;
            this.waterExpenseReceipt.SetAccount(this.currentAccount);
        }
        #endregion //Function

        #region Event
        /// <summary>
        /// 账户选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void groupTree_OrganizationSelected(object sender, EventArgs e)
        {
            string id = this.groupTree.GetCurrentSelectId();

            ClearDisplay();
            if (id == null)
                this.currentAccount = null;
            else
            {
                this.currentAccount = BusinessFactory<ExpenseAccountBusiness>.Instance.FindById(id);
                InitAccountInfo();
            }
        }
        #endregion //Event
    }
}
