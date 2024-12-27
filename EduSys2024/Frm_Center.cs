using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace EduSys2024
{
    /// <summary>
    /// 学生个人中心窗体
    /// </summary>
    public partial class Frm_Center : Form
    {
        /// <summary>
        /// 学号
        /// </summary>
        private string _StudentNumber;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="number">学号</param>
        public Frm_Center(string number)
        {
            InitializeComponent();
            _StudentNumber = number;
            this.FormClosed += Frm_Center_FormClosed;
        }
        /// <summary>
        /// 窗体关闭后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_Center_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// 窗体载入时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_Center_Load(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString =
                "Server=(local);Database=EduBase2024;Integrated Security=sspi";
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = "SELECT * FROM tb_Class";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.SelectCommand = sqlCommand;
            DataTable classTable = new DataTable();
            sqlConnection.Open();
            sqlDataAdapter.Fill(classTable);
            sqlConnection.Close();
            cmb_Class.DataSource = classTable;
            cmb_Class.DisplayMember = "Name";
            cmb_Class.ValueMember = "Number";
            sqlCommand.CommandText =
                $@"SELECT * 
                    FROM tb_Student 
                    WHERE Number=@Number;";
            sqlCommand.Parameters.AddWithValue("@Number", _StudentNumber);
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            byte[] photoBytes = null;
            if (sqlDataReader.Read())
            {
                txb_Number.Text = _StudentNumber;
                txb_Name.Text = sqlDataReader["Name"].ToString();
                rdb_Male.Checked = (bool)sqlDataReader["Gender"];
                rdb_Female.Checked = !(bool)sqlDataReader["Gender"];
                dtp_BirthDate.Value = ((DateTime)sqlDataReader["BirthDate"]);
                cmb_Class.SelectedValue = (int)sqlDataReader["ClassNumber"];
                txb_Speciality.Text = sqlDataReader["Speciality"].ToString();
                if (sqlDataReader["Photo"] != DBNull.Value)
                    photoBytes = (byte[])sqlDataReader["Photo"];
            }
            sqlDataReader.Close();
            if (photoBytes != null)
            {
                MemoryStream memoryStream = new MemoryStream(photoBytes);
                pcb_Photo.Image = Image.FromStream(memoryStream);
            }
        }
        /// <summary>
        /// 点击更新按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Update_Click(object sender, EventArgs e)
        {
            MemoryStream memoryStream = new MemoryStream();
            pcb_Photo.Image.Save(memoryStream, ImageFormat.Bmp);
            byte[] photoBytes = new byte[memoryStream.Length];
            memoryStream.Seek(0, SeekOrigin.Begin);
            memoryStream.Read(photoBytes, 0, photoBytes.Length);
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString =
                "Server=(local);Database=EduBase2024;Integrated Security=sspi";
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText =
                "UPDATE tb_Student" +
                 " SET Name=@Name,Gender=@Gender,BirthDate=@BirthDate,ClassNumber=@ClassNumber,Speciality=@Speciality,Photo=@Photo" +
                 " WHERE Number=@Number;";
            sqlCommand.Parameters.AddWithValue("@Name", txb_Name.Text);
            sqlCommand.Parameters.AddWithValue("@Gender", rdb_Male.Checked);
            sqlCommand.Parameters.AddWithValue("@BirthDate", dtp_BirthDate.Value);
            sqlCommand.Parameters.AddWithValue("@ClassNumber", cmb_Class.SelectedValue);
            sqlCommand.Parameters.AddWithValue("@Speciality", txb_Speciality.Text);
            sqlCommand.Parameters.AddWithValue("@Photo", photoBytes);
            sqlCommand.Parameters.AddWithValue("@Number", _StudentNumber);
            sqlConnection.Open();
            int rowAffected = sqlCommand.ExecuteNonQuery();
            MessageBox.Show($"成功更新{rowAffected}条。");
            sqlConnection.Close();
        }
        /// <summary>
        /// 点击打开照片按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OpenPhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog openPhotoDialog = new OpenFileDialog();
            openPhotoDialog.Title = "打开照片文件";
            openPhotoDialog.Filter = "图像文件|*.bmp;*.jpg";
            openPhotoDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures); 
            openPhotoDialog.ShowDialog();
            string fileName = openPhotoDialog.FileName;
            pcb_Photo.Image = Image.FromFile(fileName);
        }
    }
}
