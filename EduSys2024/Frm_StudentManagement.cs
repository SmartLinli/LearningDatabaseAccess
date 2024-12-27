using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace EduSys2024
{
    /// <summary>
    /// 学生管理窗体（辅导员用）
    /// </summary>
    public partial class Frm_StudentManagement : Form
    {
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public Frm_StudentManagement()
        {
            InitializeComponent();
            this.FormClosed += Frm_StudentManagement_FormClosed;
        }
        /// <summary>
        /// 窗体关闭后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_StudentManagement_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms.Count == 0)
                Application.Exit();
        }
        /// <summary>
        /// 窗体载入时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_StudentManagement_Load(object sender, EventArgs e)
        {
            #region 向数据库查询学生表、班级表（用于下拉菜单）
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString =
                "Server=(local);Database=EduBase2024;Integrated Security=sspi";
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "SELECT * FROM tb_Student;";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.SelectCommand = sqlCommand;
            DataTable studentTable = new DataTable();
            DataTable classTable = new DataTable();
            sqlConnection.Open();
            sqlDataAdapter.Fill(studentTable);
            sqlCommand.CommandText = "SELECT * FROM tb_Class;";
            sqlDataAdapter.Fill(classTable);
            sqlConnection.Close();
            #endregion
            dgv_Students.DataSource = studentTable;
            #region 向数据网格视图添加下拉框列，用于显示学生的班级
            DataGridViewComboBoxColumn classColumn = new DataGridViewComboBoxColumn();
            classColumn.DataSource = classTable;
            classColumn.DisplayMember = "Name";
            classColumn.ValueMember = "Number";
            classColumn.DataPropertyName = "ClassNumber";
            dgv_Students.Columns.Add(classColumn);
            dgv_Students.Columns["ClassNumber"].Visible = false;
            classColumn.DisplayIndex = 4;
            classColumn.HeaderText = "班级";
            dgv_Students.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            #endregion
        }
        /// <summary>
        /// 点击更新按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Update_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString =
                "Server=(local);Database=EduBase2024;Integrated Security=sspi";
            SqlCommand insertCommand = new SqlCommand();
            insertCommand.Connection = sqlConnection;
            insertCommand.CommandText =
                "INSERT tb_Student" +
                 "(Number,Name,Gender,BirthDate,Class,Speciality)" +
                 " VALUES(@Number,@Name,@Gender,@BirthDate,@Class,@Speciality);";
            insertCommand.Parameters.Add("@Number", SqlDbType.Char, 10, "Number");
            insertCommand.Parameters.Add("@Name", SqlDbType.VarChar, 0, "Name");
            insertCommand.Parameters.Add("@Gender", SqlDbType.VarChar, 0, "Gender");
            insertCommand.Parameters.Add("@BirthDate", SqlDbType.VarChar, 0, "BirthDate");
            insertCommand.Parameters.Add("@Class", SqlDbType.VarChar, 0, "Class");
            insertCommand.Parameters.Add("@Speciality", SqlDbType.VarChar, 0, "Speciality");
            SqlCommand updateCommand = new SqlCommand();
            updateCommand.Connection = sqlConnection;
            updateCommand.CommandText =
                "UPDATE tb_Student" +
                 " SET Name=@Name,Gender=@Gender,BirthDate=@BirthDate,Class=@Class,Speciality=@Speciality" +
                 " WHERE Number=@Number;";
            updateCommand.Parameters.Add("@Name", SqlDbType.VarChar, 0, "Name");
            updateCommand.Parameters.Add("@Gender", SqlDbType.VarChar, 0, "Gender");
            updateCommand.Parameters.Add("@BirthDate", SqlDbType.VarChar, 0, "BirthDate");
            updateCommand.Parameters.Add("@Class", SqlDbType.VarChar, 0, "Class");
            updateCommand.Parameters.Add("@Speciality", SqlDbType.VarChar, 0, "Speciality");
            updateCommand.Parameters.Add("@Number", SqlDbType.Char, 10, "Number");
            SqlCommand deleteCommand = new SqlCommand();
            deleteCommand.Connection = sqlConnection;
            deleteCommand.CommandText =
                "DELETE tb_Student WHERE Number=@Number;";
            deleteCommand.Parameters.Add("@Number", SqlDbType.Char, 10, "Number");
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.InsertCommand = insertCommand;
            sqlDataAdapter.UpdateCommand = updateCommand;
            sqlDataAdapter.DeleteCommand = deleteCommand;
            DataTable studentTable = (DataTable)dgv_Students.DataSource;
            sqlConnection.Open();
            int rowAffected = sqlDataAdapter.Update(studentTable);
            sqlConnection.Close();
            MessageBox.Show($"更新{rowAffected}行。");
        }
    }
}
