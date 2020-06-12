using kampusGymTeretana.Baza_podataka;
using kampusGymTeretana.Klase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kampusGymTeretana.UI
{
    public partial class urediForm : Form
    {
        public urediForm()
        {
            InitializeComponent();
        }


        urediKlasa c = new urediKlasa();
        urediclanoveBP u = new urediclanoveBP();

        static string myconnstr = ConfigurationManager.ConnectionStrings["connstrng2"].ConnectionString;
        private void UrediBotun_Click(object sender, EventArgs e)
        {

            if (textBox4.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Neko od obaveznih polja je ostalo prazno. Pokusajte ponovno.");
            }
            else
            {
                bool flag = false;
                int rez = 0;
                flag = int.TryParse(textBox2.Text, out rez);
                if (flag == false)
                {
                    MessageBox.Show("Nije unesen broj.");

                }
                else
                {
                    
                  
                    c.gym_id = int.Parse(textBox2.Text);
                    c.ime = textBox3.Text; 
                    c.prezime = textBox4.Text;
                    c.spol = comboBox1.Text;
                    c.datum_rodenja = dateTimePicker1.Value.ToShortDateString();
                    c.email = textBox5.Text;
                    /*c.datum_placanja = dateTimePicker2.Value.ToShortDateString();
                    c.datum_vrijedi_do = dateTimePicker3.Value.ToShortDateString(); */
                    c.vrsta_treninga = comboBox2.Text;
                   // c.slika = pictureBox1.ToString();
                    bool success = u.Update(c);
                    if (success)
                        MessageBox.Show("Uredeno clanstvo.");
                    else MessageBox.Show("Pogreska pri uredivanju clanstva.");
                }
            }

            urediForm f = new urediForm();
            f.Show();
            this.Hide();
        }


        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = "";
        }

        private void dgv1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            textBox2.Text= dgv1.Rows[rowIndex].Cells[1].Value.ToString();
            textBox3.Text = dgv1.Rows[rowIndex].Cells[2].Value.ToString();
            textBox4.Text = dgv1.Rows[rowIndex].Cells[3].Value.ToString();
            comboBox1.Text=dgv1.Rows[rowIndex].Cells[4].Value.ToString();
            string dateOfBirth= dgv1.Rows[rowIndex].Cells[5].Value.ToString();
            dateTimePicker1.Value = DateTime.Parse(dateOfBirth);
            
            textBox5.Text = dgv1.Rows[rowIndex].Cells[6].Value.ToString();
            comboBox2.Text=dgv1.Rows[rowIndex].Cells[9].Value.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string keywords = textBox1.Text;


            SqlConnection conn = new SqlConnection(myconnstr);
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM tblMembers WHERE gym_id LIKE '%" + keywords + "%' OR ime LIKE '%" + keywords + "%' OR prezime LIKE '%" + keywords + "%'", conn);

            DataTable dt = new DataTable();
            sda.Fill(dt);

            dgv1.DataSource = dt;

            dgv1.Columns[0].Visible = false;
            dgv1.Columns[1].HeaderCell.Value = "Članski broj";
            dgv1.Columns[2].HeaderCell.Value = "Ime";
            dgv1.Columns[3].HeaderCell.Value = "Prezime";
            dgv1.Columns[4].HeaderCell.Value = "Spol";
            dgv1.Columns[5].HeaderCell.Value = "Datum rođenja";
            dgv1.Columns[6].HeaderCell.Value = "Email";
            dgv1.Columns[7].Visible = false;
            dgv1.Columns[8].Visible = false;
            dgv1.Columns[9].HeaderCell.Value = "Vrsta treninga";
            dgv1.Columns[10].Visible = false;


            dgv1.EnableHeadersVisualStyles = false;
            dgv1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 184, 255);
            dgv1.AllowUserToAddRows = false;

            dgv1.AllowUserToDeleteRows = false;
            dgv1.DataSource = dt;
        }

        private void urediForm_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(myconnstr);
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM tblMembers", conn);

            DataTable dt = new DataTable();
            sda.Fill(dt);

            dgv1.DataSource = dt;

            dgv1.Columns[0].Visible = false;
            dgv1.Columns[1].HeaderCell.Value = "Članski broj";
            dgv1.Columns[2].HeaderCell.Value = "Ime";
            dgv1.Columns[3].HeaderCell.Value = "Prezime";
            dgv1.Columns[4].HeaderCell.Value = "Spol";
            dgv1.Columns[5].HeaderCell.Value = "Datum rođenja";
            dgv1.Columns[6].HeaderCell.Value = "Email";
            dgv1.Columns[7].Visible = false;
            dgv1.Columns[8].Visible = false;
            dgv1.Columns[9].HeaderCell.Value = "Vrsta treninga";
            dgv1.Columns[10].Visible = false;


            dgv1.EnableHeadersVisualStyles = false;
            dgv1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 184, 255);
            dgv1.AllowUserToAddRows = false;

            dgv1.AllowUserToDeleteRows = false;
            dgv1.DataSource = dt;

            panel2.Height = buttonInformacije.Height;
            panel2.Top = buttonInformacije.Top;

            dgv1.BorderStyle = BorderStyle.None;
            dgv1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgv1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv1.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dgv1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dgv1.BackgroundColor = Color.Gainsboro;

            dgv1.EnableHeadersVisualStyles = false;
            dgv1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 184, 255);
            dgv1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gainsboro;

            panel1.BackColor = ColorTranslator.FromHtml("#222831");

            //Button button = (Button)sender;
            buttonNaslovna.BackColor = ColorTranslator.FromHtml("#222831");
            buttonClanstvo.BackColor = ColorTranslator.FromHtml("#222831");
            buttonInformacije.BackColor = Color.FromArgb(0, 129, 138);
            buttonZaposlenici.BackColor = ColorTranslator.FromHtml("#222831");
            buttonRaspored.BackColor = ColorTranslator.FromHtml("#222831");
            buttonInventar.BackColor = ColorTranslator.FromHtml("#222831");
        }

        private void buttonNaslovna_Click(object sender, EventArgs e)
        {
            panel2.Height = buttonNaslovna.Height;
            panel2.Top = buttonNaslovna.Top;
            kampusGymHome f = new kampusGymHome();
            f.Show();
            this.Hide();
        }

        private void buttonClanstvo_Click(object sender, EventArgs e)
        {
            panel2.Height = buttonClanstvo.Height;
            panel2.Top = buttonClanstvo.Top;
            clanoviForm f = new clanoviForm();
            f.Show();
            this.Hide();
        }

        private void buttonInformacije_Click(object sender, EventArgs e)
        {
            panel2.Height = buttonInformacije.Height;
            panel2.Top = buttonInformacije.Top;
            urediForm f = new urediForm();
            f.Show();
            this.Hide();
        }

        private void buttonZaposlenici_Click(object sender, EventArgs e)
        {
            panel2.Height = buttonZaposlenici.Height;
            panel2.Top = buttonZaposlenici.Top;
            zaposleniForm f = new zaposleniForm();
            f.Show();
            this.Hide();
        }

        private void buttonRaspored_Click(object sender, EventArgs e)
        {
            panel2.Height = buttonRaspored.Height;
            panel2.Top = buttonRaspored.Top;
            rasporedForm f = new rasporedForm();
            f.Show();
            this.Hide();
        }

        private void buttonInventar_Click(object sender, EventArgs e)
        {
            panel2.Height = buttonInventar.Height;
            panel2.Top = buttonInventar.Top;
            inventarForm f = new inventarForm();
            f.Show();
            this.Hide();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            panel2.Height = buttonExit.Height;
            panel2.Top = buttonExit.Top;
            this.Close();
        }

        private void dgv1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            urediForm f = new urediForm();
            f.Show();
            this.Hide();
        }

        private void textBox1_Leave_1(object sender, EventArgs e)
        {
            string keywords = textBox1.Text;


            SqlConnection conn = new SqlConnection(myconnstr);
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM tblMembers WHERE gym_id LIKE '%" + keywords + "%' OR ime LIKE '%" + keywords + "%' OR prezime LIKE '%" + keywords + "%'", conn);

            DataTable dt = new DataTable();
            sda.Fill(dt);

            dgv1.DataSource = dt;

            dgv1.Columns[0].Visible = false;
            dgv1.Columns[1].HeaderCell.Value = "Članski broj";
            dgv1.Columns[2].HeaderCell.Value = "Ime";
            dgv1.Columns[3].HeaderCell.Value = "Prezime";
            dgv1.Columns[4].HeaderCell.Value = "Spol";
            dgv1.Columns[5].HeaderCell.Value = "Datum rođenja";
            dgv1.Columns[6].HeaderCell.Value = "Email";
            dgv1.Columns[7].Visible = false;
            dgv1.Columns[8].Visible = false;
            dgv1.Columns[9].HeaderCell.Value = "Vrsta treninga";
            dgv1.Columns[10].Visible = false;


            dgv1.EnableHeadersVisualStyles = false;
            dgv1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 184, 255);
            dgv1.AllowUserToAddRows = false;

            dgv1.AllowUserToDeleteRows = false;
            dgv1.DataSource = dt;
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("Članski broj ne možete mijenjati!", "Obavijest");
        }
    }
}
