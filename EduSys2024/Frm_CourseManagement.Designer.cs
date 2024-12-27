namespace EduSys2024
{
    partial class Frm_CourseManagement
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
            this.dgv_Courses = new System.Windows.Forms.DataGridView();
            this.txb_Pinyin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Courses)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Courses
            // 
            this.dgv_Courses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Courses.Location = new System.Drawing.Point(12, 12);
            this.dgv_Courses.Name = "dgv_Courses";
            this.dgv_Courses.RowTemplate.Height = 23;
            this.dgv_Courses.Size = new System.Drawing.Size(584, 228);
            this.dgv_Courses.TabIndex = 2;
            // 
            // txb_Pinyin
            // 
            this.txb_Pinyin.Location = new System.Drawing.Point(456, 255);
            this.txb_Pinyin.Name = "txb_Pinyin";
            this.txb_Pinyin.Size = new System.Drawing.Size(140, 21);
            this.txb_Pinyin.TabIndex = 3;
            this.txb_Pinyin.TextChanged += new System.EventHandler(this.txb_Pinyin_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(313, 258);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "根据拼音缩写查找课程：";
            // 
            // Frm_CourseManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 290);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txb_Pinyin);
            this.Controls.Add(this.dgv_Courses);
            this.Name = "Frm_CourseManagement";
            this.Text = "课程管理";
            this.Load += new System.EventHandler(this.Frm_CourseManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Courses)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgv_Courses;
        private System.Windows.Forms.TextBox txb_Pinyin;
        private System.Windows.Forms.Label label1;
    }
}

