using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace EduSys2024
{
    /// <summary>
    /// 注册窗体
    /// </summary>
    public partial class Frm_SignUp : Form
    {
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public Frm_SignUp()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 点击注册按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_SignUp_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString =
                "Server=(local);Database=EduBase2024;Integrated Security=false;User ID=SqlLogin1;Password=$q17o9!n1";
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText =
                $@"INSERT tb_User(Number,Password) 
                    VALUES('{txb_UserNumber.Text}',HASHBYTES('MD5','{txb_Password.Text}'));";
            sqlConnection.Open();
            int rowAffected = sqlCommand.ExecuteNonQuery();
            MessageBox.Show($"成功注册{rowAffected}名新用户。");
            sqlConnection.Close();
        }
    }
}
