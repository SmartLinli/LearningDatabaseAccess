using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace EduSys2024
{
    public partial class Frm_SignUp : Form
    {
        public Frm_SignUp()
        {
            InitializeComponent();
        }

        private void btn_SignUp_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString =
                "Server=(local);Database=EduBase2024;Integrated Security=sspi";
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
