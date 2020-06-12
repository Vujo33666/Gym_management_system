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
    public partial class clanoviForm : Form
    {
        public clanoviForm()
        {
            InitializeComponent();
        }

        static string myconnstr = ConfigurationManager.ConnectionStrings["connstrng2"].ConnectionString;

        private void clanoviForm_Load(object sender, EventArgs e)
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
            dgv1.Columns[4].Visible = false;
            dgv1.Columns[5].Visible = false;
            dgv1.Columns[6].Visible = false;

            dgv1.Columns[7].HeaderCell.Value = "Datum plačanja";
            dgv1.Columns[8].HeaderCell.Value = "Vrijedi do";
            dgv1.Columns[9].Visible = false;
            dgv1.Columns[10].Visible = false;



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

            panel1.BackColor = ColorTranslator.FromHtml("#222831");

            //Button button = (Button)sender;
            buttonNaslovna.BackColor = ColorTranslator.FromHtml("#222831");
            buttonClanstvo.BackColor = Color.FromArgb(0, 129, 138);
            buttonInformacije.BackColor = ColorTranslator.FromHtml("#222831");
            buttonZaposlenici.BackColor = ColorTranslator.FromHtml("#222831");
            buttonRaspored.BackColor = ColorTranslator.FromHtml("#222831");
            buttonInventar.BackColor = ColorTranslator.FromHtml("#222831");


        }

        #region Textbox Pretrazi
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
            dgv1.Columns[4].Visible = false;
            dgv1.Columns[5].Visible = false;
             dgv1.Columns[6].Visible = false;

            dgv1.Columns[7].HeaderCell.Value = "Datum plačanja";
            dgv1.Columns[8].HeaderCell.Value = "Vrijedi do";
            dgv1.Columns[9].Visible = false;
            dgv1.Columns[10].Visible = false; 



            dgv1.EnableHeadersVisualStyles = false;
            dgv1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 184, 255);
            dgv1.AllowUserToAddRows = false;

            dgv1.AllowUserToDeleteRows = false;
            dgv1.DataSource = dt;
        }


        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = "";
        }
        #endregion

        #region Naslovna traka
        // buttoni i odlazak na druge forme

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

        private void dgv1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            clanoviForm f = new clanoviForm(); // hmm moram se posavjetovat
            f.Show();
            this.Hide();
        }

        #endregion
    }
}
