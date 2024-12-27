namespace EduSys2024
{
    partial class Frm_StudentManagement
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
            this.btn_Update = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Students)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Students
            // 
            this.dgv_Students.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Students.Location = new System.Drawing.Point(12, 13);
            this.dgv_Students.Name = "dgv_Students";
            this.dgv_Students.RowTemplate.Height = 23;
            this.dgv_Students.Size = new System.Drawing.Size(584, 213);
            this.dgv_Students.TabIndex = 0;
            // 
            // btn_Update
            // 
            this.btn_Update.Location = new System.Drawing.Point(521, 236);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(75, 23);
            this.btn_Update.TabIndex = 1;
            this.btn_Update.Text = "更新";
            this.btn_Update.UseVisualStyleBackColor = true;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // Frm_StudentManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 271);
            this.Controls.Add(this.btn_Update);
            this.Controls.Add(this.dgv_Students);
            this.Name = "Frm_StudentManagement";
            this.Text = "学生管理";
            this.Load += new System.EventHandler(this.Frm_StudentManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Students)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Students;
        private System.Windows.Forms.Button btn_Update;
    }
}

