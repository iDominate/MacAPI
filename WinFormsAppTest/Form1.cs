using MySql.Data.MySqlClient;
using MySqlConnector.Authentication;


namespace WinFormsAppTest
{
    public partial class Form1 : Form
    {
        MySqlConnection conn;
        string connString;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var builder = new MySqlConnectionStringBuilder
                {
                    Server = "194.163.164.140",
                    UserID = "stack_ahmed",
                    Password = "ahmed12345",
                    Database = "stack_ahmed",
                };
                //string datasource = "Server=194.163.164.140;Database=stack_pos;port=2087;username=stack_pos;password=ahmed12345;CharSet=latin1;SslMode=None"; ;
                //connString = @"SERVER=194.163.164.140;PORT=2087;DATABASE=stack_pos;User=stack_pos;PASSWORD=ahmed12345;SslMode=None";
                conn = new MySqlConnection(builder.ConnectionString);
                conn.Open();
                MessageBox.Show("Connection Success");
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
    }

}
