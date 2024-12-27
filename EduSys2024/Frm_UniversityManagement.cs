using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace EduSys2024
{
    /// <summary>
    /// 全校管理窗体（校长用）
    /// </summary>
    public partial class Frm_UniversityManagement : Form
    {
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public Frm_UniversityManagement()
        {
            InitializeComponent();
            this.FormClosed += Frm_UniversityManagement_FormClosed;
        }
        /// <summary>
        /// 窗体关闭后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_UniversityManagement_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms.Count == 0)
                Application.Exit();
        }
        /// <summary>
        /// 窗体载入时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_UniversityManagement_Load(object sender, EventArgs e)
        {
            #region 向数据库查询教学单位（含学院、专业、班级等多张表）
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString =
                "Server=(local);Database=EduBase2024;Integrated Security=sspi";
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText =
                "SELECT * FROM tb_Department;" +
                "SELECT * FROM tb_Major;" +
                "SELECT * FROM tb_Class";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.SelectCommand = sqlCommand;
            DataSet dataSet = new DataSet();
            sqlConnection.Open();
            sqlDataAdapter.Fill(dataSet);
            sqlConnection.Close();
            DataTable departmentTable = dataSet.Tables[0];
            DataTable majorTable = dataSet.Tables[1];
            DataTable classesTable = dataSet.Tables[2];
            #endregion
            #region 向树形控件添加学院、专业、班级的节点
            DataRelation dataRelation = new DataRelation
                ("Department_Major",
                 departmentTable.Columns["Number"],
                 majorTable.Columns["DepartmentNumber"]);
            DataRelation dataRelation2 = new DataRelation
                ("Major_Class",
                 majorTable.Columns["Number"],
                 classesTable.Columns["MajorNumber"]);
            dataSet.Relations.Add(dataRelation);
            dataSet.Relations.Add(dataRelation2);
            foreach (DataRow departmentRow in departmentTable.Rows)
            {
                TreeNode departmentNode = new TreeNode();
                departmentNode.Text = departmentRow["Name"].ToString();
                trv_EducationUnit.Nodes.Add(departmentNode);
                foreach (DataRow majorRow in departmentRow.GetChildRows("Department_Major"))
                {
                    TreeNode majorNode = new TreeNode();
                    majorNode.Text = majorRow["Name"].ToString();
                    departmentNode.Nodes.Add(majorNode);
                    foreach (DataRow classRow in majorRow.GetChildRows("Major_Class"))
                    {
                        TreeNode classNode = new TreeNode();
                        classNode.Text = classRow["Name"].ToString();
                        classNode.Tag = (int)classRow["Number"];
                        majorNode.Nodes.Add(classNode);
                    }
                }
            }
            #endregion
        }
        /// <summary>
        /// 教学单位树形视图选中节点后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trv_EducationUnit_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (trv_EducationUnit.SelectedNode.Level != 2)
                return;
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString =
                "Server=(local);Database=EduBase2024;Integrated Security=sspi";
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "SELECT * FROM tb_Student WHERE ClassNumber=@ClassNumber;";
            int selectedClassNumber = (int)trv_EducationUnit.SelectedNode.Tag;
            sqlCommand.Parameters.AddWithValue("@ClassNumber", selectedClassNumber);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.SelectCommand = sqlCommand;
            DataTable studentTable = new DataTable();
            sqlConnection.Open();
            sqlDataAdapter.Fill(studentTable);
            sqlConnection.Close();
            dgv_Students.DataSource = studentTable;
        }
    }
}
