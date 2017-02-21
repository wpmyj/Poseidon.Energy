﻿namespace Poseidon.Energy.ClientDx
{
    partial class FrmDepartmentOverview
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.depGrid = new Poseidon.Energy.ClientDx.DepartmentGrid();
            this.groupsTree1 = new Poseidon.Winform.Core.GroupsTree();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupControl2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupControl3, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(784, 483);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.groupsTree1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(3, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(194, 194);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "分组";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.btnAdd);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(203, 3);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(578, 194);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "操作";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(49, 54);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "添加部门";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.depGrid);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl3.Location = new System.Drawing.Point(203, 203);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(578, 277);
            this.groupControl3.TabIndex = 2;
            this.groupControl3.Text = "部门列表";
            // 
            // depGrid
            // 
            this.depGrid.DataSource = null;
            this.depGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.depGrid.Location = new System.Drawing.Point(2, 21);
            this.depGrid.Name = "depGrid";
            this.depGrid.ShowFooter = false;
            this.depGrid.ShowLineNumber = true;
            this.depGrid.Size = new System.Drawing.Size(574, 254);
            this.depGrid.TabIndex = 0;
            // 
            // groupsTree1
            // 
            this.groupsTree1.DataSource = null;
            this.groupsTree1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupsTree1.Location = new System.Drawing.Point(2, 21);
            this.groupsTree1.Name = "groupsTree1";
            this.groupsTree1.ShowCode = false;
            this.groupsTree1.ShowRemark = false;
            this.groupsTree1.Size = new System.Drawing.Size(190, 171);
            this.groupsTree1.TabIndex = 0;
            // 
            // FrmDepartmentOverview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 483);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmDepartmentOverview";
            this.Text = "部门总览";
            this.Load += new System.EventHandler(this.FrmDepartmentOverview_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DepartmentGrid depGrid;
        private Winform.Core.GroupsTree groupsTree1;
    }
}