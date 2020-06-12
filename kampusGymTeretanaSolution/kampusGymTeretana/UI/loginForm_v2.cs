using kampusGymTeretana.Baza_podataka;
using kampusGymTeretana.Klase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kampusGymTeretana.UI
{
    public partial class loginForm_v2 : Form
    {
        public loginForm_v2()
        {
            InitializeComponent();
        }

        loginBP b = new loginBP();
        loginKlasa k = new loginKlasa();

        private void loginForm_v2_Load(object sender, EventArgs e)
        {
            this.AcceptButton = button1;  //enter radi za botun
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            k.username = textBox1.Text;
            k.password = textBox2.Text;

            bool success = b.loginCheck(k);

            if (success)
            {
                MessageBox.Show("Prijava uspješna", "Obavijest");
                if (k.username == "admin" || k.username == "user")
                {
                    kampusGymHome au = new kampusGymHome();
                    au.Show();
                    this.Hide();
                }
            }
            else
            {
                //login failed
                MessageBox.Show("Prijava neuspješna. Pokušajte ponovo.");
            }
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://www.facebook.com/StudentskiCentarSplit/");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Greška prilikom pristupa linku!\nObjašnjenje greške: " + ex , "Upozorenje");
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://www.scst.unist.hr/");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška prilikom pristupa linku!\nObjašnjenje greške: " + ex , "Upozorenje");
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://www.instagram.com/studentski_centar_split/");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška prilikom pristupa linku!\nObjašnjenje greške: "+ex , "Upozorenje");
            }
        }
    }
}
