using System.Data.SqlClient;

namespace SPTask
{
    public partial class LoginOrSignIn : Form
    {
        string connection = @"Data Source=DESKTOP-7HUNHTF;Integrated Security=True;Connect Timeout=30;ApplicationIntent=ReadWrite; Database=LoginRegister";

        public LoginOrSignIn()
        {
            InitializeComponent();
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            Register menuform = new Register();
            menuform.ShowDialog();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            SqlDataReader DR;

            string user = password_txtbx.Text;
            string pass = username_txtbx.Text;


            using (SqlConnection conn = new SqlConnection(connection))
            {
                SqlCommand cmd = new SqlCommand();

                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM UserLogin WHERE Username='" + username_txtbx.Text + "' AND Password='" + password_txtbx.Text + "'";
                DR = cmd.ExecuteReader();

                if (DR.Read())
                    MessageBox.Show("Welcome");
                else MessageBox.Show("Invalid Login");
            }
        }
        }
}
