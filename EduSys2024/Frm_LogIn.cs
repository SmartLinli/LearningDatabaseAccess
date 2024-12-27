using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace EduSys2024
{
    /// <summary>
    /// 登录窗体
    /// </summary>
    public partial class Frm_LogIn : Form
    {
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public Frm_LogIn()
        {
            InitializeComponent();
            this.FormClosed += Frm_LogIn_FormClosed;
        }
        /// <summary>
        /// 窗体关闭后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_LogIn_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms.Count==0)
                Application.Exit();
        }
        /// <summary>
        /// 点击登录按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_LogIn_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString =
                "Server=(local);Database=EduBase2024;Integrated Security=false;User ID=SqlLogin1;Password=$q17o9!n1";
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText =
                $@"SELECT COUNT(1) 
                    FROM tb_User 
                    WHERE Number=@Number 
                        AND Password=HASHBYTES('MD5',@Password)";
            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = "@Number";
            sqlParameter.SqlDbType = SqlDbType.Char;
            sqlParameter.Size = 10;
            sqlParameter.Value = txb_UserNumber.Text;
            sqlCommand.Parameters.Add(sqlParameter);
            sqlCommand.Parameters.AddWithValue("@Password", txb_Password.Text);
            sqlCommand.Parameters["@Password"].SqlDbType = SqlDbType.VarChar;
            sqlConnection.Open();
            int rowCount = (int)sqlCommand.ExecuteScalar();
            sqlConnection.Close();
            if (rowCount == 1)
            {
                MessageBox.Show("登录成功");
            }
            else
            {
                MessageBox.Show("登录失败");
                return;
            }
            switch (txb_UserNumber.Text.Length)
            {
                case 3:     //校长账号001，密码001，打开全校管理窗体
                    {
                        Frm_UniversityManagement frm_UniversityManagement=new Frm_UniversityManagement();
                        frm_UniversityManagement.Show();
                        this.Close();
                    }
                    break;
                case 7:     //教师账号2004004，密码004，打开课程管理窗体
                    {
                        Frm_CourseManagement frm_CourseManagement= new Frm_CourseManagement();
                        frm_CourseManagement.Show();
                        this.Close();
                    }
                    break;
                case 8:     //辅导员账号20091009，密码009，打开学生管理窗体
                    {
                        Frm_StudentManagement frm_StudentManagement = new Frm_StudentManagement();  
                        frm_StudentManagement.Show();
                        this.Close();
                    }
                    break;
                case 10:    //学生账号3230707001，密码7001，打开个人中心窗体
                    {
                        Frm_Center frm_Center = new Frm_Center(txb_UserNumber.Text);
                        frm_Center.Show();
                        this.Close();
                    }
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// 点击注册按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_SignUp_Click(object sender, EventArgs e)
        {
            Frm_SignUp frm_SignUp = new Frm_SignUp();
            frm_SignUp.ShowDialog();
        }
    }
}