﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Energy.Core.BL
{
    using Poseidon.Base.Framework;
    using Poseidon.Base.System;
    using Poseidon.Common;
    using Poseidon.Energy.Core.DL;
    using Poseidon.Energy.Core.IDAL;
    using Poseidon.Energy.Core.Utility;

    /// <summary>
    /// 能源结算业务类
    /// </summary>
    public class SettlementBusiness : AbstractBusiness<Settlement>
    {
        #region Constructor
        /// <summary>
        /// 能源结算业务类
        /// </summary>
        public SettlementBusiness()
        {
            this.baseDal = RepositoryFactory<ISettlementRepository>.Instance;
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 查找所有结算，按顺序返回
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<Settlement> FindAll()
        {
            List<Settlement> data = new List<Settlement>();
            var all = base.FindAll();
            int[] years = all.GroupBy(r => r.Year).Select(s => s.Key).OrderBy(t => t).ToArray();

            for (int i = 0; i < years.Length; i++)
            {
                var settlements = all.Where(r => r.Year == years[i]);

                var first = settlements.Single(r => string.IsNullOrEmpty(r.PreviousId));

                data.Add(first);

                string previousId = first.Id;
                bool flag = true;
                while (flag)
                {
                    var item = settlements.SingleOrDefault(r => r.PreviousId == previousId);
                    if (item != null)
                    {
                        data.Add(item);
                        previousId = item.Id;
                    }
                    else
                        flag = false;
                }
            }

            data.Reverse();
            return data;
        }

        /// <summary>
        /// 获取指标化相关能源结算
        /// </summary>
        /// <param name="targetId">指标计划ID</param>
        /// <returns></returns>
        public IEnumerable<Settlement> FindByTarget(string targetId)
        {
            return this.baseDal.FindListByField("targetId", targetId);
        }

        /// <summary>
        /// 按年度获取顺序能源结算
        /// </summary>
        /// <param name="year">年度</param>
        /// <returns></returns>
        public IEnumerable<Settlement> FindByYear(int year)
        {
            var settlements = this.baseDal.FindListByField("year", year);

            List<Settlement> data = new List<Settlement>();
            if (settlements.Count() == 0)
            {
                return data;
            }

            var first = settlements.Single(r => string.IsNullOrEmpty(r.PreviousId));

            data.Add(first);

            string previousId = first.Id;
            bool flag = true;
            while (flag)
            {
                var item = settlements.SingleOrDefault(r => r.PreviousId == previousId);
                if (item != null)
                {
                    data.Add(item);
                    previousId = item.Id;
                }
                else
                    flag = false;
            }

            return data;
        }

        /// <summary>
        /// 获取能源结算用量汇总
        /// </summary>
        /// <param name="year">年度</param>
        /// <param name="energyType">能源类型</param>
        /// <param name="departments">部门列表</param>
        /// <returns></returns>
        public IEnumerable<SettlementQuantumSummary> GetQuantumSummary(int year, EnergyType energyType, List<Department> departments)
        {
            List<SettlementQuantumSummary> data = new List<SettlementQuantumSummary>();

            foreach (var department in departments)
            {
                var item = GetDepartmentQuantumSummary(year, energyType, department);
                if (item != null)
                    data.Add(item);
            }

            return data;
        }

        /// <summary>
        /// 获取能源结算金额汇总
        /// </summary>
        /// <param name="year">年度</param>
        /// <param name="energyType">能源类型</param>
        /// <param name="departments">部门列表</param>
        /// <returns></returns>
        public IEnumerable<SettlementAmountSummary> GetAmountSummary(int year, EnergyType energyType, List<Department> departments)
        {
            List<SettlementAmountSummary> data = new List<SettlementAmountSummary>();

            foreach (var department in departments)
            {
                var item = GetDepartmentAmountSummary(year, energyType, department);
                if (item != null)
                    data.Add(item);
            }

            return data;
        }

        /// <summary>
        /// 获取部门结算汇总
        /// </summary>
        /// <param name="year">年度</param>
        /// <param name="energyType">能源类型</param>
        /// <param name="department">部门</param>
        /// <returns></returns>
        public DepartmentSettlementSummary GetDepartmentSummary(int year, EnergyType energyType, Department department)
        {
            DepartmentSettlementSummary data = new DepartmentSettlementSummary();
            data.Year = year;
            data.DepartmentId = department.Id;
            data.DepartmentName = department.Name;
            data.EnergyType = energyType.DisplayName();
            data.SettleQuantum = 0;
            data.SettleAmount = 0;

            TargetBusiness targetBusiness = new TargetBusiness();
            var target = targetBusiness.FindByYear(year);

            SettlementRecordBusiness srBusiness = new SettlementRecordBusiness();
            var settlements = FindByYear(year).ToList();
            if (settlements.Count == 0)
                return null;

            bool flag = false;
            for (int i = 0; i < settlements.Count; i++)
            {
                var settle = settlements[i];
                var record = srBusiness.FindByDepartment(settle.Id, department.Id, energyType);
                if (record == null)
                    continue;

                if (i == 0)
                {
                    data.PlanQuantum = record.BeginQuantum;
                    data.PlanAmount = record.BeginAmount;
                    data.UnitPrice = record.UnitPrice;
                }

                data.SettleQuantum += record.Quantum;
                data.SettleAmount += record.Amount;
                flag = true;
            }

            if (!flag)
                return null;

            data.RemainQuantum = data.PlanQuantum - data.SettleQuantum;
            data.RemainAmount = data.PlanAmount - data.SettleAmount;

            if (data.RemainAmount < 0)
            {
                TargetRecordBusiness trBusiness = new TargetRecordBusiness();
                var targetRecord = trBusiness.FindByDepartment(target.Id, department.Id, (int)energyType);
                if (targetRecord == null)
                {
                    data.SchoolTake = 0;
                    data.SelfTake = -data.RemainAmount;
                }
                else
                {
                    data.SchoolTake = Math.Round(-data.RemainAmount * targetRecord.SchoolTake);
                    data.SelfTake = -data.RemainAmount - data.SchoolTake;
                }
            }

            return data;
        }

        /// <summary>
        /// 获取能源结算用量汇总
        /// </summary>
        /// <param name="year">年度</param>
        /// <param name="energyType">能源类型</param>
        /// <param name="department">部门</param>
        /// <returns></returns>
        public SettlementQuantumSummary GetDepartmentQuantumSummary(int year, EnergyType energyType, Department department)
        {
            SettlementQuantumSummary summary = new SettlementQuantumSummary();
            summary.DepartmentName = department.Name;
            summary.Year = year;
            summary.EnergyType = energyType.DisplayName();

            SettlementRecordBusiness srBusiness = new SettlementRecordBusiness();
            var settlements = FindByYear(year).ToList();
            if (settlements.Count == 0)
                return null;

            bool flag = false;

            for (int i = 0; i < settlements.Count; i++)
            {
                var settle = settlements[i];
                var record = srBusiness.FindByDepartment(settle.Id, department.Id, energyType);
                if (record == null)
                    continue;

                switch (i)
                {
                    case 0:
                        summary.PlanQuantum = record.BeginQuantum;
                        summary.FirstQuarter = record.Quantum;
                        break;
                    case 1:
                        summary.SecondQuarter = record.Quantum;
                        break;
                    case 2:
                        summary.ThirdQuarter = record.Quantum;
                        break;
                    case 3:
                        summary.FourthQuarter = record.Quantum;
                        break;
                }
                flag = true;
            }

            summary.TotalQuantum = summary.FirstQuarter + summary.SecondQuarter + summary.ThirdQuarter + summary.FourthQuarter;
            summary.RemainQuantum = summary.PlanQuantum - summary.TotalQuantum;

            if (!flag)
                return null;

            return summary;
        }

        /// <summary>
        /// 获取能源结算金额汇总
        /// </summary>
        /// <param name="year">年度</param>
        /// <param name="energyType">能源类型</param>
        /// <param name="department">部门</param>
        /// <returns></returns>
        public SettlementAmountSummary GetDepartmentAmountSummary(int year, EnergyType energyType, Department department)
        {
            SettlementAmountSummary summary = new SettlementAmountSummary();
            summary.DepartmentName = department.Name;
            summary.Year = year;
            summary.EnergyType = energyType.DisplayName();

            TargetBusiness targetBusiness = new TargetBusiness();
            var target = targetBusiness.FindByYear(year);

            SettlementRecordBusiness srBusiness = new SettlementRecordBusiness();
            var settlements = FindByYear(year).ToList();
            if (settlements.Count == 0)
                return null;

            bool flag = false;

            for (int i = 0; i < settlements.Count; i++)
            {
                var settle = settlements[i];
                var record = srBusiness.FindByDepartment(settle.Id, department.Id, energyType);
                if (record == null)
                    continue;

                switch (i)
                {
                    case 0:
                        summary.UnitPrice = record.UnitPrice;
                        summary.PlanAmount = record.BeginAmount;
                        summary.FirstQuarter = record.Amount;
                        break;
                    case 1:
                        summary.SecondQuarter = record.Amount;
                        break;
                    case 2:
                        summary.ThirdQuarter = record.Amount;
                        break;
                    case 3:
                        summary.FourthQuarter = record.Amount;
                        break;
                }
                flag = true;
            }

            summary.TotalAmount = summary.FirstQuarter + summary.SecondQuarter + summary.ThirdQuarter + summary.FourthQuarter;
            summary.RemainAmount = summary.PlanAmount - summary.TotalAmount;

            if (summary.RemainAmount < 0)
            {
                TargetRecordBusiness trBusiness = new TargetRecordBusiness();
                var targetRecord = trBusiness.FindByDepartment(target.Id, department.Id, (int)energyType);

                summary.SchoolTake = Math.Round(-summary.RemainAmount * targetRecord.SchoolTake);
                summary.SelfTake = -summary.RemainAmount - summary.SchoolTake;
            }

            if (!flag)
                return null;

            return summary;
        }

        /// <summary>
        /// 添加能源结算
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <param name="user">操作用户</param>
        /// <returns></returns>
        public Settlement Create(Settlement entity, LoginUser user)
        {
            entity.CreateBy = new UpdateStamp
            {
                UserId = user.Id,
                Name = user.Name,
                Time = DateTime.Now
            };
            entity.UpdateBy = new UpdateStamp
            {
                UserId = user.Id,
                Name = user.Name,
                Time = DateTime.Now
            };
            entity.Status = 0;
            return base.Create(entity);
        }

        /// <summary>
        /// 编辑能源结算
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <param name="user">操作用户</param>
        /// <returns></returns>
        public bool Update(Settlement entity, LoginUser user)
        {
            entity.UpdateBy = new UpdateStamp
            {
                UserId = user.Id,
                Name = user.Name,
                Time = DateTime.Now
            };
            return base.Update(entity);
        }

        /// <summary>
        /// 删除能源结算
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public override bool Delete(Settlement entity)
        {
            // delete the records
            SettlementRecordBusiness recordBusiness = new SettlementRecordBusiness();
            recordBusiness.DeleteBySettlement(entity.Id);

            return base.Delete(entity);
        }
        #endregion //Method
    }
}
