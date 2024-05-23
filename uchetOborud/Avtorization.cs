using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace uchetOborud
{
    
    public partial class Avtorization : Form
    {
        DateTime DateTime = DateTime.Now;
        public SqlConnection connection = new SqlConnection(@"Data source = DESKTOP-949SEK0; Initial Catalog = uchetOborud; Integrated Security = true");
        public static string FIO;
        public static string id;
        public static string loginUser;
        public Avtorization()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Avtorization_Load(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(159, 0, 61);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            loginUser = textBox1.Text;
            var passwordUser = textBox2.Text;
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            string zapros = $"select * from Stuff where login = '{loginUser}' and password = '{passwordUser}'";
            SqlCommand comm = new SqlCommand(zapros, connection);
            adapter.SelectCommand = comm;
            adapter.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                string idSotr = dt.Rows[0][0].ToString();
                string roll = dt.Rows[0][4].ToString();
                if (roll == "Администратор")
                {
                    connection.Close();
                    connection.Open();
                    string history = $"INSERT INTO HistoryVhod (idSotr, dataTime , status) Values ('{idSotr}', '{DateTime}', 'Успешно')";
                    SqlCommand commp = new SqlCommand(history, connection);
                    commp.ExecuteNonQuery();
                    id = dt.Rows[0][0].ToString();
                    FIO = dt.Rows[0][1].ToString();
                    Administrator administrator = new Administrator();
                    administrator.Show();
                    this.Hide();
                    connection.Close();
                }
                else if (roll == "Сотрудник")
                {
                    connection.Close();
                    connection.Open();
                    string history = $"INSERT INTO HistoryVhod (idSotr, dataTime , status) Values ('{idSotr}', '{DateTime}', 'Успешно')";
                    SqlCommand commp = new SqlCommand(history, connection);
                    commp.ExecuteNonQuery();
                    id = dt.Rows[0][0].ToString();
                    FIO = dt.Rows[0][1].ToString();
                    Sotrudnik sotrudnik = new Sotrudnik();
                    sotrudnik.Show();
                    this.Hide();
                    connection.Close();
                }
                else if (roll == "Руководитель")
                {
                    connection.Close();
                    connection.Open();
                    string history = $"INSERT INTO HistoryVhod (idSotr, dataTime , status) Values ('{idSotr}', '{DateTime}', 'Успешно')";
                    SqlCommand commp = new SqlCommand(history, connection);
                    commp.ExecuteNonQuery();
                    id = dt.Rows[0][0].ToString();
                    FIO = dt.Rows[0][1].ToString();
                    Rucovoditel rucovoditel = new Rucovoditel();
                    rucovoditel.Show();
                    this.Hide();
                    connection.Close();
                }
            }
            else
            {
                connection.Close();
                connection.Open();
                string history = $"INSERT INTO HistoryVhod (log, dataTime , status) Values ('{loginUser}', '{DateTime}', 'не успешно')";
                SqlCommand commp = new SqlCommand(history, connection);
                commp.ExecuteNonQuery();
                MessageBox.Show("Таких пользователей нету");
                connection.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
