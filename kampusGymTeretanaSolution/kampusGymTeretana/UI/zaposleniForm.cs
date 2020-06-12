using kampusGymTeretana.Baza_podataka;
using kampusGymTeretana.Klase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kampusGymTeretana.UI
{
    public partial class zaposleniForm : Form
    {
        public zaposleniForm()
        {
            InitializeComponent();
        }
        static string myconnstr = ConfigurationManager.ConnectionStrings["connstrng2"].ConnectionString;
        public int temp = 0;
        
        zaposleniKlasa z = new zaposleniKlasa();
        zaposleniBP b = new zaposleniBP();
        private void zaposleniForm_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(myconnstr);
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM tblZaposlenici", conn);

            DataTable dt = new DataTable();
            sda.Fill(dt);

            dgv1.DataSource = dt;
            dgv1.Columns[0].Visible = false;
            dgv1.Columns[1].HeaderCell.Value = "Ime";

            dgv1.Columns[2].HeaderCell.Value = "Prezime";
            dgv1.Columns[3].HeaderCell.Value = "Email";
            dgv1.Columns[4].HeaderCell.Value = "Mobitel";
            dgv1.Columns[5].HeaderCell.Value = "Datum rođenja";
            dgv1.Columns[6].Visible = false;
            dgv1.Columns[7].HeaderCell.Value = "Broj zaposlenika";


            dgv1.EnableHeadersVisualStyles = false;
            dgv1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 184, 255);
            dgv1.AllowUserToAddRows = false;

            dgv1.AllowUserToDeleteRows = false;
            dgv1.DataSource = dt;

            panel2.Height = buttonClanstvo.Height;
            panel2.Top = buttonClanstvo.Top;

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

            panel2.Height = buttonZaposlenici.Height;
            panel2.Top = buttonZaposlenici.Top;


            panel1.BackColor = ColorTranslator.FromHtml("#222831");

            //Button button = (Button)sender;
            buttonNaslovna.BackColor = ColorTranslator.FromHtml("#222831");
            buttonClanstvo.BackColor = ColorTranslator.FromHtml("#222831");
            buttonInformacije.BackColor = ColorTranslator.FromHtml("#222831");
            buttonZaposlenici.BackColor = Color.FromArgb(0, 129, 138);
            buttonRaspored.BackColor = ColorTranslator.FromHtml("#222831");
            buttonInventar.BackColor = ColorTranslator.FromHtml("#222831");
        }

        private void buttonNaslovna_Click(object sender, EventArgs e)
        {
            kampusGymHome n = new kampusGymHome();
            n.Show();
            this.Hide();
            panel2.Height = buttonNaslovna.Height;
            panel2.Top = buttonNaslovna.Top;
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

        private void dgv1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            textBox1.Text = dgv1.Rows[rowIndex].Cells[1].Value.ToString();
            textBox2.Text = dgv1.Rows[rowIndex].Cells[2].Value.ToString();
            textBox3.Text = dgv1.Rows[rowIndex].Cells[3].Value.ToString();
            textBox4.Text = dgv1.Rows[rowIndex].Cells[4].Value.ToString();
            string dateOfBirth = dgv1.Rows[rowIndex].Cells[5].Value.ToString();
            dateTimePicker1.Value = DateTime.Parse(dateOfBirth);
            textBox5.Text = dgv1.Rows[rowIndex].Cells[7].Value.ToString();
            temp = Convert.ToInt32(textBox5.Text);
            
            // pictureBox2 treba rrijesitiiii
        }

        private void button2_Click(object sender, EventArgs e) // Dodaj botun
        {
            DataClasses4DataContext db4 = new DataClasses4DataContext();
            //sprema u public varijablu broj zaposlenika
            var varijabla4 = from s in db4.tblZaposlenicis select s.id_zaposlenika;
            int[] number = varijabla4.ToArray();


            bool temp = false;
            bool temp2 = false;
            bool temp3 = true;
            int rez = 0;
            temp2 = int.TryParse(textBox4.Text, out rez);
            rez = 0;
            temp = int.TryParse(textBox5.Text, out rez);

            for (int i=0;i<number.Length;i++) // Provjera da li postoji isti broj tj id_korisnika u bazi 
            {
                if(rez==number[i])
                {
                    temp3 = false;
                }
            }

            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Prvo unesite podatke.", "Obavijest");
            }
            else if(temp==false)
            {
                MessageBox.Show("Niste unijeli ispravan broj zaposlenika.", "Obavijest");
            }
            else if(temp3==false)
            {
                MessageBox.Show("Unijeli ste broj zaposlenika koji se već koristi.", "Obavijest");
            }
            else
            {
                z.ime = textBox1.Text;
                z.prezime = textBox2.Text;
                z.email = textBox3.Text;
                if (temp2 == false)
                {
                    z.mobitel = 0;
                }
                else
                    z.mobitel = int.Parse(textBox4.Text);

                z.datum_rodenja = dateTimePicker1.Value.ToShortDateString();
                z.id_zaposlenika = int.Parse(textBox5.Text);
                //z.slika = "";

                if (temp)
                {
                    var result = MessageBox.Show("Jeste li sigurni da želite dodati novog zaposlenika?", "Obavijest", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        bool success = b.Insert(z);

                        if (success)
                        {

                            MessageBox.Show("Uspješno dodan novi zaposlenik.", "Obavijest");
                            loadFormAgain();
                        }
                        else
                            MessageBox.Show("Nešto je pošlo po krivu", "Upozorenje");
                    }
                    else
                        loadFormAgain();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e) //Uredi botun
        {
            
            if (textBox5.Text == "" || textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Neko od obaveznih polja je ostalo prazno. Pokusajte ponovno.", "Obavijest");
            }
            else
            {
                bool flag = false;
                bool flag2 = false;
                int rez = 0;
                flag = int.TryParse(textBox5.Text, out rez);
                rez = 0;
                flag2 = int.TryParse(textBox4.Text, out rez);

                if (flag == false)
                {
                    MessageBox.Show("Nije unešen pravilan broj zaposlenika", "Obavijest");

                }
                else
                {
                    z.ime = textBox1.Text;
                    z.prezime = textBox2.Text;
                    z.email = textBox3.Text;
                    if (flag2 == false)
                    {
                        z.mobitel = 0;
                    }
                    else
                        z.mobitel = int.Parse(textBox4.Text);

                    z.datum_rodenja = dateTimePicker1.Value.ToShortDateString();
                    z.id_zaposlenika = int.Parse(textBox5.Text);
                    //z.slika = "";
                    if (z.id_zaposlenika == temp)
                    {
                        bool success = b.Update(z);
                        if (success)
                        {
                            MessageBox.Show("Uređeni podatci.", "Obavijest");
                            loadFormAgain();

                        }
                        else { MessageBox.Show("Pogreška pri uređivanju podataka zaposlenika.", "Upozorenje"); }
                    }
                    else
                    {
                        MessageBox.Show("Prilikom uređivanja podataka zaposlenika ne možete mijenjati broj zaposlenika.", "Upozorenje");
                    }
                }
            }
        }

        public void loadFormAgain()
        {
            zaposleniForm f = new zaposleniForm();
            f.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Prvo odaberite kojeg zaposlenika želite brisati klikom na prvi stupac tablice", "Obavijest");
            }
            else
            {
                z.ime = textBox1.Text;
                z.prezime = textBox2.Text;
                z.email = textBox3.Text;
                z.mobitel = int.Parse(textBox4.Text);
                z.datum_rodenja = dateTimePicker1.Value.ToShortDateString();
                z.id_zaposlenika = int.Parse(textBox5.Text);
                //z.slika = "";

                //za vadenje podataka iz baze -> LINQ
                DataClasses4DataContext db4 = new DataClasses4DataContext();

               /* var varijabla = from s in db4.tblZaposlenicis select s.ime;
                string[] name = varijabla.ToArray();

                var varijabla2 = from s in db4.tblZaposlenicis select s.id_zaposlenika;
                int[] broj = varijabla2.ToArray(); */   // TREBAT CE KASNIJE

                    var result = MessageBox.Show("Jeste li sigurni da želite obrisati zaposlenika?", "Obavijest", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        bool success = b.Delete(z);
                        if (success)
                        {
                            MessageBox.Show("Zaposlenik uspješno izbrisan.", "Obavijest");
                            loadFormAgain();
                        }
                        else MessageBox.Show("Pogreška pri brisanju zaposlenika.", "Upozorenje");
                    }
                    else
                        loadFormAgain();
            }
        }

        private void dgv1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            zaposleniForm f = new zaposleniForm();
            f.Show();
            this.Hide();
        }
    }
}
