using Microsoft.Extensions.Configuration;
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
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appconfig.json");
            var config = builder.Build();
            var connectionString = config.GetConnectionString("SqlServerConnection");
            using (SqlConnection conn = new SqlConnection(connectionString))
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
