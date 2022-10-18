using System.Data.SqlClient;

namespace SPTask
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            string connection = @"Data Source=DESKTOP-7HUNHTF;Integrated Security=True;Connect Timeout=30;ApplicationIntent=ReadWrite; Database=Login/Register";

            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();

                string query = "INSERT INTO UserLogin(Name,UserName,Password)" +
                    " VALUES('" + tbox_name.Text + "', '" + tbox_username.Text + "', '" + tbox_password.Text + "')";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);

                da.SelectCommand.ExecuteNonQuery();
                MessageBox.Show("Data saved succesfully");
            }
        }
    }
}
