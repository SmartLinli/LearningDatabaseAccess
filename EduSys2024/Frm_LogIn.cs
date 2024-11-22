using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace EduSys2024
{
    public partial class Frm_LogIn : Form
    {
        public Frm_LogIn()
        {
            InitializeComponent();
        }

        private void btn_LogIn_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString =
                "Server=(local);Database=EduBase2024;Integrated Security=sspi";
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
                MessageBox.Show("登录成功");
            else
                MessageBox.Show("登录失败");
        }

        private void btn_SignUp_Click(object sender, EventArgs e)
        {
            Frm_SignUp frm_SignUp = new Frm_SignUp();
            frm_SignUp.ShowDialog();
        }
    }
}
