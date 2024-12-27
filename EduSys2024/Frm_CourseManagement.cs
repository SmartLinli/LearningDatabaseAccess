using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace EduSys2024
{
    /// <summary>
    /// 课程管理窗体（教师用）
    /// </summary>
    public partial class Frm_CourseManagement : Form
    {
        /// <summary>
        /// 课程数据表
        /// </summary>
        private DataTable _CourseTable;
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public Frm_CourseManagement()
        {
            InitializeComponent();
            this.FormClosed += Frm_CourseManagement_FormClosed;
        }
        /// <summary>
        /// 窗体关闭后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_CourseManagement_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms.Count == 0)
                Application.Exit();
        }
        /// <summary>
        /// 窗体载入时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_CourseManagement_Load(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString =
                "Server=(local);Database=EduBase2024;Integrated Security=sspi";
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "SELECT * FROM tb_Course";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.SelectCommand = sqlCommand;
            DataTable courseTable = new DataTable();
            sqlConnection.Open();
            sqlDataAdapter.Fill(courseTable);
            sqlConnection.Close();
            _CourseTable = courseTable;
            dgv_Courses.DataSource = _CourseTable;
        }
        /// <summary>
        /// 拼音文本框文本改动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txb_Pinyin_TextChanged(object sender, EventArgs e)
        {
            DataTable courseTable = _CourseTable;
            DataRow[] results = courseTable.Select($"Pinyin LIKE '%{txb_Pinyin.Text}%'");
            DataTable resultTable = courseTable.Clone();
            foreach (var row in results)
                resultTable.ImportRow(row);
            dgv_Courses.DataSource = resultTable;
        }
    }
}
