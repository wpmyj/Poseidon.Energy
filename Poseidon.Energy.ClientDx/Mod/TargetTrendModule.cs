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
    using DevExpress.XtraCharts;
    using Poseidon.Base.Framework;
    using Poseidon.Common;
    using Poseidon.Core.BL;
    using Poseidon.Core.DL;
    using Poseidon.Energy.Core.BL;
    using Poseidon.Energy.Core.DL;
    using Poseidon.Energy.Core.Utility;

    /// <summary>
    /// 指标趋势组件
    /// </summary>
    public partial class TargetTrendModule : DevExpress.XtraEditors.XtraUserControl
    {
        #region Field
        /// <summary>
        /// 当前关联部门
        /// </summary>
        private Department currentDepartment;

        /// <summary>
        /// 当前关联分组
        /// </summary>
        private Group currentGroup;

        /// <summary>
        /// 指标类型
        /// </summary>
        private int targetType;
        #endregion //Field

        #region Constructor
        public TargetTrendModule()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 载入数据
        /// </summary>
        /// <param name="department"></param>
        /// <param name="targetType"></param>
        private async void LoadData(Department department, int targetType)
        {
            var task = Task.Run(() =>
            {
                var records = BusinessFactory<TargetRecordBusiness>.Instance.FindByDepartment(department.Id, targetType);

                List<SeriesPoint> points = new List<SeriesPoint>();
                List<SeriesPoint> linePoints = new List<SeriesPoint>();

                foreach (var item in records)
                {
                    var target = BusinessFactory<TargetBusiness>.Instance.FindById(item.TargetId);

                    var point = new SeriesPoint();
                    point.Argument = target.Year.ToString() + "年";
                    point.Values = new double[] { Convert.ToDouble(item.PlanQuantum) };

                    points.Add(point);

                    var point2 = new SeriesPoint();
                    point2.Argument = target.Year.ToString() + "年";
                    point2.Values = new double[] { Convert.ToDouble(item.PlanAmount) };

                    linePoints.Add(point2);
                }
                points = points.OrderBy(r => r.Argument).ToList();
                linePoints = points.OrderBy(r => r.Argument).ToList();

                var data = new
                {
                    BarPoint = points,
                    LinePoint = linePoints
                };
                return data;
            });

            var chartPoints = await task;

            this.trendChart.SetChartTitle($"{department.ShortName}历年指标情况");

            if (targetType == 1)
            {
                this.trendChart.SetBar(chartPoints.BarPoint, "计划用电量(度)");
                this.trendChart.SetLine(chartPoints.LinePoint, "计划金额(元)");
            }
            else if (targetType == 2)
            {
                this.trendChart.SetBar(chartPoints.BarPoint, "计划用水量(吨)");
                this.trendChart.SetLine(chartPoints.LinePoint, "计划金额(元)");
            }
        }

        /// <summary>
        /// 载入分组数据
        /// </summary>
        /// <param name="group"></param>
        /// <param name="targetType"></param>
        private async void LoadData(Group group, int targetType)
        {
            var task = Task.Run(() =>
            {
                var targets = BusinessFactory<TargetBusiness>.Instance.FindAll().OrderBy(r => r.Year);
                var groupItems = BusinessFactory<GroupBusiness>.Instance.FindAllItems(group.Id);

                List<SeriesPoint> points = new List<SeriesPoint>();
                List<SeriesPoint> linePoints = new List<SeriesPoint>();

                foreach (var target in targets)
                {
                    var targetRecords = BusinessFactory<TargetRecordBusiness>.Instance.FindByTarget(target.Id);
                    var records = targetRecords.Where(r => groupItems.Select(s => s.EntityId).Contains(r.DepartmentId)).ToList();

                    var point = new SeriesPoint();
                    point.Argument = target.Year.ToString() + "年";
                    point.Values = new double[] { Convert.ToDouble(records.Where(r => r.Type == targetType).Sum(r => r.PlanQuantum)) };

                    points.Add(point);

                    var point2 = new SeriesPoint();
                    point2.Argument = target.Year.ToString() + "年";
                    point2.Values = new double[] { Convert.ToDouble(records.Where(r => r.Type == targetType).Sum(r => r.PlanAmount)) };

                    linePoints.Add(point2);
                }

                points = points.OrderBy(r => r.Argument).ToList();
                linePoints = points.OrderBy(r => r.Argument).ToList();

                var data = new
                {
                    BarPoint = points,
                    LinePoint = linePoints
                };
                return data;
            });

            var chartPoints = await task;

            this.trendChart.SetChartTitle($"{group.Name}历年指标情况");

            if (targetType == 1)
            {
                this.trendChart.SetBar(chartPoints.BarPoint, "计划用电量(度)");
                this.trendChart.SetLine(chartPoints.LinePoint, "计划金额(元)");
            }
            else if (targetType == 2)
            {
                this.trendChart.SetBar(chartPoints.BarPoint, "计划用水量(吨)");
                this.trendChart.SetLine(chartPoints.LinePoint, "计划金额(元)");
            }
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 设置部门
        /// </summary>
        /// <param name="department">部门</param>
        /// <param name="targetType">指标类型</param>
        public void SetDepartment(Department department, int targetType)
        {
            this.currentDepartment = department;
            this.targetType = targetType;

            LoadData(department, targetType);
        }

        /// <summary>
        /// 设置分组
        /// </summary>
        /// <param name="group">分组</param>
        /// <param name="targetType">指标类型</param>
        public void SetGroup(Group group, int targetType)
        {
            this.currentGroup = group;
            this.targetType = targetType;

            LoadData(group, targetType);
        }
        #endregion //Method
    }
}
