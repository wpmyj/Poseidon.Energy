﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Poseidon.Energy.Core.DL
{
    using Poseidon.Base.Framework;

    /// <summary>
    /// 指标记录类
    /// </summary>
    public class TargetRecord : BusinessEntity
    {
        #region Proprety
        /// <summary>
        /// 计划指标ID
        /// </summary>
        [Display(Name = "计划指标ID")]
        public string TargetId { get; set; }

        /// <summary>
        /// 部门ID
        /// </summary>
        [Display(Name = "部门ID")]
        public string DepartmentId { get; set; }

        /// <summary>
        /// 人数指标
        /// </summary>
        [Display(Name = "人数指标")]
        public List<StaffTarget> StaffTarget { get; set; }

        /// <summary>
        /// 补贴
        /// </summary>
        [Display(Name = "补贴")]
        public List<Allowance> Allowance { get; set; }

        /// <summary>
        /// 总用电量
        /// </summary>
        [Display(Name = "总用电量")]
        public decimal TotalKilowatt { get; set; }

        /// <summary>
        /// 总金额
        /// </summary>
        [Display(Name = "总金额")]
        public decimal TotalAmount { get; set; }
        #endregion //Property
    }

    /// <summary>
    /// 补贴
    /// </summary>
    public class Allowance
    {
        /// <summary>
        /// 名称
        /// </summary>
        [Display(Name = "名称")]
        public string Name { get; set; }

        /// <summary>
        /// 参数
        /// </summary>
        [Display(Name = "参数")]
        public decimal Parameter { get; set; }

        /// <summary>
        /// 月度数
        /// </summary>
        [Display(Name = "月度数")]
        public decimal MonthKilowatt { get; set; }

        /// <summary>
        /// 月数
        /// </summary>
        [Display(Name = "月数")]
        public int MonthCount { get; set; }

        /// <summary>
        /// 年指标度数
        /// </summary>
        [Display(Name = "年指标度数")]
        public decimal YearKilowatt { get; set; }

        /// <summary>
        /// 年指标金额
        /// </summary>
        [Display(Name = "年指标金额")]
        public decimal YearAmount { get; set; }
    }
}