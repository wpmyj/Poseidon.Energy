﻿namespace Poseidon.Energy.ClientDx
{
    partial class TargetRecordGrid
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.colTargetId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDepartmentId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFinance = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSchoolTake = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSelfTake = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPlanQuantum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPlanAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bsEntity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgcEntity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEntity)).BeginInit();
            this.SuspendLayout();
            // 
            // bsEntity
            // 
            this.bsEntity.DataSource = typeof(Poseidon.Energy.Core.DL.TargetRecord);
            // 
            // dgcEntity
            // 
            this.dgcEntity.Size = new System.Drawing.Size(568, 378);
            // 
            // dgvEntity
            // 
            this.dgvEntity.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colTargetId,
            this.colDepartmentId,
            this.colType,
            this.colFinance,
            this.colSchoolTake,
            this.colSelfTake,
            this.colPlanQuantum,
            this.colPlanAmount,
            this.colRemark,
            this.colStatus});
            this.dgvEntity.IndicatorWidth = 40;
            this.dgvEntity.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvEntity.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvEntity.OptionsBehavior.Editable = false;
            this.dgvEntity.OptionsView.EnableAppearanceEvenRow = true;
            this.dgvEntity.OptionsView.EnableAppearanceOddRow = true;
            this.dgvEntity.OptionsView.ShowGroupPanel = false;
            this.dgvEntity.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.dgvEntity_CustomColumnDisplayText);
            // 
            // colTargetId
            // 
            this.colTargetId.FieldName = "TargetId";
            this.colTargetId.Name = "colTargetId";
            this.colTargetId.Visible = true;
            this.colTargetId.VisibleIndex = 1;
            // 
            // colDepartmentId
            // 
            this.colDepartmentId.FieldName = "DepartmentId";
            this.colDepartmentId.Name = "colDepartmentId";
            this.colDepartmentId.Visible = true;
            this.colDepartmentId.VisibleIndex = 2;
            // 
            // colType
            // 
            this.colType.FieldName = "Type";
            this.colType.Name = "colType";
            this.colType.Visible = true;
            this.colType.VisibleIndex = 3;
            // 
            // colFinance
            // 
            this.colFinance.FieldName = "Finance";
            this.colFinance.Name = "colFinance";
            this.colFinance.Visible = true;
            this.colFinance.VisibleIndex = 4;
            // 
            // colSchoolTake
            // 
            this.colSchoolTake.FieldName = "SchoolTake";
            this.colSchoolTake.Name = "colSchoolTake";
            this.colSchoolTake.Visible = true;
            this.colSchoolTake.VisibleIndex = 5;
            // 
            // colSelfTake
            // 
            this.colSelfTake.FieldName = "SelfTake";
            this.colSelfTake.Name = "colSelfTake";
            this.colSelfTake.Visible = true;
            this.colSelfTake.VisibleIndex = 6;
            // 
            // colPlanQuantum
            // 
            this.colPlanQuantum.FieldName = "PlanQuantum";
            this.colPlanQuantum.Name = "colPlanQuantum";
            this.colPlanQuantum.Visible = true;
            this.colPlanQuantum.VisibleIndex = 7;
            // 
            // colPlanAmount
            // 
            this.colPlanAmount.FieldName = "PlanAmount";
            this.colPlanAmount.Name = "colPlanAmount";
            this.colPlanAmount.Visible = true;
            this.colPlanAmount.VisibleIndex = 8;
            // 
            // colRemark
            // 
            this.colRemark.FieldName = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.Visible = true;
            this.colRemark.VisibleIndex = 9;
            // 
            // colStatus
            // 
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 10;
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.Visible = true;
            this.colId.VisibleIndex = 0;
            // 
            // TargetRecordGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "TargetRecordGrid";
            this.Load += new System.EventHandler(this.TargetRecordGrid_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsEntity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgcEntity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEntity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colTargetId;
        private DevExpress.XtraGrid.Columns.GridColumn colDepartmentId;
        private DevExpress.XtraGrid.Columns.GridColumn colType;
        private DevExpress.XtraGrid.Columns.GridColumn colFinance;
        private DevExpress.XtraGrid.Columns.GridColumn colSchoolTake;
        private DevExpress.XtraGrid.Columns.GridColumn colSelfTake;
        private DevExpress.XtraGrid.Columns.GridColumn colPlanQuantum;
        private DevExpress.XtraGrid.Columns.GridColumn colPlanAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
    }
}
