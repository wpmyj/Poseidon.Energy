﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Energy.Core.DL
{
    using Poseidon.Base.Framework;

    /// <summary>
    /// 部门用能指标类
    /// </summary>
    public class DepartmentIndex : BusinessEntity
    {
        #region Proprety
        /// <summary>
        /// 计划指标ID
        /// </summary>
        [Display(Name = "计划指标ID")]
        public string PlanIndexId { get; set; }

        /// <summary>
        /// 部门ID
        /// </summary>
        [Display(Name = "部门ID")]
        public string DepartmentId { get; set; }

        public List<StaffIndex> StaffIndex { get; set; }

        public List<Allowance> Allowance { get; set; }
        #endregion //Property
    }

    /// <summary>
    /// 人数指标
    /// </summary>
    public class StaffIndex
    {

    }

    /// <summary>
    /// 补贴
    /// </summary>
    public class Allowance
    {

    }
}
