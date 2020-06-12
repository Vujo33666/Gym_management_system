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
    public partial class inventarForm : Form
    {
        public inventarForm()
        {
            InitializeComponent();
        }

        inventarBP i = new inventarBP();
        inventarKlasa k = new inventarKlasa();

        static string myconnstr = ConfigurationManager.ConnectionStrings["connstrng2"].ConnectionString;

        #region datagridview i form_loadovi
        private void inventarForm_Load(object sender, EventArgs e)
        {
            panel2.Height = buttonInventar.Height;
            panel2.Top = buttonInventar.Top;
            loadFormAgain();
        }

        private void dgvInventar_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            textBox2.Text = dgvInvertar.Rows[rowIndex].Cells[1].Value.ToString();
            string pomocna = dgvInvertar.Rows[rowIndex].Cells[2].Value.ToString();
            numericUpDown1.Value = decimal.Parse(pomocna);

        }

        public void loadFormAgain() //metoda samo za ponovno ucitavanje
        {
            SqlConnection conn = new SqlConnection(myconnstr);
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM tblInvertar", conn);

            DataTable dt = new DataTable();
            sda.Fill(dt);

            dgvInvertar.DataSource = dt;

            dgvInvertar.Columns[0].Visible = false;
            dgvInvertar.Columns[1].HeaderCell.Value = "Oprema";
            dgvInvertar.Columns[2].HeaderCell.Value = "Kolicina";



            dgvInvertar.EnableHeadersVisualStyles = false;
           // dgvInvertar.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 184, 255);
            dgvInvertar.AllowUserToAddRows = false;

            dgvInvertar.AllowUserToDeleteRows = false;
            /*
            dgvInvertar.BorderStyle = BorderStyle.None;
            dgvInvertar.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro;
            //dgvInvertar.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(117, 143, 132); 
            dgvInvertar.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvInvertar.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 150, 0); 
            //dgvInvertar.DefaultCellStyle.SelectionBackColor = Color.MediumPurple; 251, 229, 109 - ZUTA
            dgvInvertar.DefaultCellStyle.SelectionForeColor = Color.FromArgb(34,36,49);
            //dgvInvertar.BackgroundColor = Color.FromArgb(117, 143, 132); //siva ova
            dgvInvertar.BackgroundColor = Color.Gainsboro;

            dgvInvertar.EnableHeadersVisualStyles = false;
            dgvInvertar.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvInvertar.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 129, 138);
            dgvInvertar.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(34,36,49); */

            dgvInvertar.BorderStyle = BorderStyle.None;
            dgvInvertar.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgvInvertar.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvInvertar.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dgvInvertar.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dgvInvertar.BackgroundColor = Color.Gainsboro;

            dgvInvertar.EnableHeadersVisualStyles = false;
            dgvInvertar.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvInvertar.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 184, 255);
            dgvInvertar.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gainsboro;

            // za panel i buttone na izborniku

            panel1.BackColor = ColorTranslator.FromHtml("#222831");

            //Button button = (Button)sender;
            buttonNaslovna.BackColor = ColorTranslator.FromHtml("#222831");
            buttonClanstvo.BackColor = ColorTranslator.FromHtml("#222831");
            buttonInformacije.BackColor = ColorTranslator.FromHtml("#222831");
            buttonZaposlenici.BackColor = ColorTranslator.FromHtml("#222831");
            buttonRaspored.BackColor = ColorTranslator.FromHtml("#222831");
            buttonInventar.BackColor = Color.FromArgb(0, 129, 138);

        }

        #endregion

        #region textbox pretrazi
        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = "";
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string keywords = textBox1.Text;


            SqlConnection conn = new SqlConnection(myconnstr);
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM tblInvertar WHERE sprava LIKE '%" + keywords + "%' OR kolicina LIKE '%" + keywords + "%'", conn);

            DataTable dt = new DataTable();
            sda.Fill(dt);

            dgvInvertar.DataSource = dt;

            dgvInvertar.Columns[0].Visible = false;
            dgvInvertar.Columns[1].HeaderCell.Value = "Oprema";
            dgvInvertar.Columns[2].HeaderCell.Value = "Kolicina";



            dgvInvertar.EnableHeadersVisualStyles = false;
            dgvInvertar.AllowUserToAddRows = false;

            dgvInvertar.AllowUserToDeleteRows = false;

            dgvInvertar.BorderStyle = BorderStyle.None;
            dgvInvertar.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgvInvertar.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvInvertar.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dgvInvertar.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dgvInvertar.BackgroundColor = Color.Gainsboro;

            dgvInvertar.EnableHeadersVisualStyles = false;
            dgvInvertar.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvInvertar.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 184, 255);
            dgvInvertar.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gainsboro;
        }

        #endregion

        #region 3 botuna 
        private void button3_Click(object sender, EventArgs e)
        {
            
             k.sprava = textBox2.Text;
            k.kolicina = Convert.ToInt32(numericUpDown1.Value);

            //za vadenje podataka iz baze -> LINQ
            DataClasses2DataContext db2 = new DataClasses2DataContext();

            var varijabla = from s in db2.tblInvertars select s.sprava;
            string[] name = varijabla.ToArray();

            var varijabla2 = from s in db2.tblInvertars select s.kolicina;
            int[] broj = varijabla2.ToArray();

            string korisnikov_unos = textBox2.Text;
            int korisnikova_kolicina = Convert.ToInt32(numericUpDown1.Value);

            bool temp = true;

            if (korisnikova_kolicina > 0)
            {
                for (int j = 0; j < name.Count(); j++)
                {
                    if (korisnikov_unos == name[j])
                    {
                        if (korisnikova_kolicina > broj[j])
                        {
                            MessageBox.Show("Unijeli ste količinski iznos veći nego što je u bazi!", "Upozorenje");
                            temp = false;
                            break;
                        }
                        else if (korisnikova_kolicina == broj[j])
                        {
                            var result = MessageBox.Show("Jeste li sigurni da želite obrisati opremu?", "Obavijest", MessageBoxButtons.YesNo);
                            if (result == DialogResult.Yes)
                            {
                                bool success = i.Delete(k);
                                if (success)
                                {
                                    MessageBox.Show("Uređena oprema.", "Obavijest");
                                    temp = false;
                                    loadFormAgain();

                                }
                                else MessageBox.Show("Pogreška pri uređivanju opreme.", "Upozorenje");
                            }
                            else
                            {
                                temp = false;
                                break;
                            }

                        }
                        else
                        {
                            var result = MessageBox.Show("Jeste li sigurni da želite obrisati opremu?", "Obavijest", MessageBoxButtons.YesNo);
                            if (result == DialogResult.Yes)
                            {
                                k.kolicina = broj[j] - korisnikova_kolicina;
                                bool success2 = i.Update(k);
                                if (success2)
                                {
                                    MessageBox.Show("Uredena oprema.", "Obavijest");
                                    temp = false;
                                    loadFormAgain();
                                    break;
                                }
                            }
                            else
                            {
                                temp = false;
                                break;
                            }
                        }
                    }
                }

                if (temp)
                {
                    var result = MessageBox.Show("Jeste li sigurni da želite obrisati opremu?", "Obavijest", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        bool success = i.Delete(k);
                        if (success)
                        {
                            MessageBox.Show("Oprema uspjesno izbrisana.", "Obavijest");
                            loadFormAgain();
                        }
                        else MessageBox.Show("Pogreska pri brisanju opreme.", "Upozorenje");
                    }
                }
            }
            else
            {
                MessageBox.Show("Količina ne može biti jednaka 0", "Obavijest");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
                if (textBox2.Text == "" || numericUpDown1.Value == 0)
                {
                    MessageBox.Show("Neko od obaveznih polja je ostalo prazno. Pokusajte ponovno.","Obavijest");
                }
                else
                {
                    bool flag = Convert.ToBoolean(numericUpDown1.Value);

                    if (flag == false)
                    {
                        MessageBox.Show("Nije unesen broj.", "Obavijest");

                    }
                    else
                    {
                        var result = MessageBox.Show("Jeste li sigurni da želite dodati novu opremu?", "Obavijest", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            k.sprava = textBox2.Text;
                            k.kolicina = decimal.ToInt32(numericUpDown1.Value);

                            bool success = i.Update(k);
                            if (success)
                            {
                                MessageBox.Show("Uređena oprema.", "Obavijest");
                                //invertarForm nova = new invertarForm();
                                loadFormAgain();

                            }
                            else
                            {
                                MessageBox.Show("Pogreška pri uređivanju opreme.", "Upozorenje");
                            }
                        }
                        else
                        {
                            loadFormAgain();
                        }
                    }
                }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                k.sprava = textBox2.Text;
                k.kolicina = decimal.ToInt32(numericUpDown1.Value);

            //za vadenje podataka iz baze -> LINQ
            DataClasses2DataContext db2 = new DataClasses2DataContext();

            var varijabla = from s in db2.tblInvertars select s.sprava;
            string[] name = varijabla.ToArray();

            var varijabla2 = from s in db2.tblInvertars select s.kolicina;
            int[] broj = varijabla2.ToArray();

            string korisnikov_unos = textBox2.Text;
            int korisnikova_kolicina = Convert.ToInt32(numericUpDown1.Value);

            bool temp = false;

            if (korisnikova_kolicina > 0)
            {
                for (int j = 0; j < name.Count(); j++)
                {
                    if (korisnikov_unos == name[j])
                    {
                        var result = MessageBox.Show("Jeste li sigurni da želite dodati novu opremu?", "Obavijest", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            k.kolicina = broj[j] + korisnikova_kolicina;
                            bool success1 = i.Update(k);
                            if (success1)
                            {
                                MessageBox.Show("Uređena oprema.", "Obavijest");
                                temp = false;
                                loadFormAgain();
                                break;
                            }
                        }
                        else
                        {
                            loadFormAgain();
                        }
                    }
                    else
                    {
                        temp = true;
                    }
                }

                if (temp)
                {
                    var result = MessageBox.Show("Jeste li sigurni da želite dodati novu opremu?", "Obavijest", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        bool success = i.Insert(k);

                        if (success)
                        {

                            MessageBox.Show("Uspješno dodana nova oprema.", "Obavijest");
                            loadFormAgain();
                        }
                        else
                        {
                            MessageBox.Show("Nešto je pošlo po krivu", "Upozorenje");
                        }
                    }
                    else
                    {
                        loadFormAgain();
                    }
                }
            }
            else
            {

                MessageBox.Show("Količina ne može biti jednaka 0","Obavijest");
                loadFormAgain();
            }
        }
        #endregion

        #region Naslovna traka
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


        #endregion

        private void dgvInvertar_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            loadFormAgain();
        }

        private void dgvInvertar_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            inventarForm f = new inventarForm();
            f.Show();
            this.Hide();
        }
    }
}
