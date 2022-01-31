using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Sözlük
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglantı1 = new SqlConnection(@"Data Source=DESKTOP-S6SDE8U\SQLSERVER;Initial Catalog=Sözlük;Integrated Security=True");
        SqlCommand cmd;

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            baglantı1.Open();
            textBox2.Clear();
            var query = "Select TURKCE From Sözlük Where ENGLISH='" + textBox1.Text + "'";

            cmd = new SqlCommand(query, baglantı1);
            


            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    textBox2.Text = dr.GetString(0);
                }
            }

            baglantı1.Close();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            baglantı1.Open();
            textBox1.Clear();
            var query = "Select ENGLISH from Sözlük Where TURKCE='" + textBox2.Text + "'";
            cmd = new SqlCommand(query, baglantı1);
            if (e.KeyChar==(char)Keys.Enter)
            {
                e.Handled = true;
                
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    textBox1.Text = dr.GetString(0);
                }
            }
            baglantı1.Close();
        }
    }
}































