﻿namespace EduSys2024
{
    partial class Frm_UniversityManagement
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.dgv_Students = new System.Windows.Forms.DataGridView();
            this.trv_EducationUnit = new System.Windows.Forms.TreeView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Students)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Students
            // 
            this.dgv_Students.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Students.Location = new System.Drawing.Point(171, 13);
            this.dgv_Students.Name = "dgv_Students";
            this.dgv_Students.RowTemplate.Height = 23;
            this.dgv_Students.Size = new System.Drawing.Size(425, 329);
            this.dgv_Students.TabIndex = 0;
            // 
            // trv_EducationUnit
            // 
            this.trv_EducationUnit.Location = new System.Drawing.Point(13, 13);
            this.trv_EducationUnit.Name = "trv_EducationUnit";
            this.trv_EducationUnit.Size = new System.Drawing.Size(143, 329);
            this.trv_EducationUnit.TabIndex = 5;
            this.trv_EducationUnit.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trv_EducationUnit_AfterSelect);
            // 
            // Frm_UniversityManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 388);
            this.Controls.Add(this.trv_EducationUnit);
            this.Controls.Add(this.dgv_Students);
            this.Name = "Frm_UniversityManagement";
            this.Text = "全校管理";
            this.Load += new System.EventHandler(this.Frm_UniversityManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Students)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Students;
        private System.Windows.Forms.TreeView trv_EducationUnit;
    }
}

