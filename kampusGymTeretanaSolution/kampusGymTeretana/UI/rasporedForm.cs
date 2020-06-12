using kampusGymTeretana.Baza_podataka;
using kampusGymTeretana.Klase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kampusGymTeretana.UI
{
    public partial class rasporedForm : Form
    {
        public rasporedForm()
        {
            InitializeComponent();
        }

        rasporedKlasa r = new rasporedKlasa();
        rasporedBP b = new rasporedBP();



        static string myconnstr = ConfigurationManager.ConnectionStrings["connstrng2"].ConnectionString;

        private void Button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (radioButton1.Checked == true)
            {
                button.Text = radioButton1.Text;
                button.BackColor = Color.MediumPurple;
                //SpremajOdmah();
                r.botunIme = button.Name;
                r.botunText = button.Text;

                bool success = b.Insert(r);
                loadFormAgain();

            }
            else if (radioButton2.Checked == true)
            {
                button.Text = radioButton2.Text;
                button.BackColor = Color.MediumSeaGreen;
                r.botunIme = button.Name;
                r.botunText = button.Text;

                bool success = b.Insert(r);
                loadFormAgain();
            }
            else if (radioButton3.Checked == true)
            {
                button.Text = radioButton3.Text;
                button.BackColor = Color.Orange;
                r.botunIme = button.Name;
                r.botunText = button.Text;

                bool success = b.Insert(r);
                loadFormAgain();
            }
            else if (radioButton4.Checked == true)
            {
                button.Text = "";
                button.BackColor = Color.Gainsboro;
                r.botunIme = button.Name;
                r.botunText = button.Text;

                bool success = b.Insert(r);
                loadFormAgain();
            }
            else
            {
                MessageBox.Show("Odaberite vrstu treninga koju želite upisati u raspored", "Upozorenje");
                loadFormAgain();
            }
        }

        private void rasporedForm_Load(object sender, EventArgs e)
        {
            loadFormAgain();
        }

        public void loadFormAgain()
        {
            panel2.Height = buttonRaspored.Height;
            panel2.Top = buttonRaspored.Top;

            panel1.BackColor = ColorTranslator.FromHtml("#222831");

            //Button button = (Button)sender;
            buttonNaslovna.BackColor = ColorTranslator.FromHtml("#222831");
            buttonClanstvo.BackColor = ColorTranslator.FromHtml("#222831");
            buttonInformacije.BackColor = ColorTranslator.FromHtml("#222831");
            buttonZaposlenici.BackColor = ColorTranslator.FromHtml("#222831");
            buttonRaspored.BackColor = Color.FromArgb(0, 129, 138);
            buttonInventar.BackColor = ColorTranslator.FromHtml("#222831");

            #region inicijalizacija buttona
            Button[] btn = new Button[78];
            btn[0] = a1b1;
            btn[1] = a1b2;
            btn[2] = a1b3;
            btn[3] = a1b4;
            btn[4] = a1b5;
            btn[5] = a1b6;
            btn[6] = a2b1;
            btn[7] = a2b2;
            btn[8] = a2b3;
            btn[9] = a2b4;
            btn[10] = a2b5;
            btn[11] = a2b6;
            btn[12] = a3b1;
            btn[13] = a3b2;
            btn[14] = a3b3;
            btn[15] = a3b4;
            btn[16] = a3b5;
            btn[17] = a3b6;
            btn[18] = a4b1;
            btn[19] = a4b2;
            btn[20] = a4b3;
            btn[21] = a4b4;
            btn[22] = a4b5;
            btn[23] = a4b6;
            btn[24] = a5b1;
            btn[25] = a5b2;
            btn[26] = a5b3;
            btn[27] = a5b4;
            btn[28] = a5b5;
            btn[29] = a5b6;
            btn[30] = a6b1;
            btn[31] = a6b2;
            btn[32] = a6b3;
            btn[33] = a6b4;
            btn[34] = a6b5;
            btn[35] = a6b6;
            btn[36] = a7b1;
            btn[37] = a7b2;
            btn[38] = a7b3;
            btn[39] = a7b4;
            btn[40] = a7b5;
            btn[41] = a7b6;
            btn[42] = a8b1;
            btn[43] = a8b2;
            btn[44] = a8b3;
            btn[45] = a8b4;
            btn[46] = a8b5;
            btn[47] = a8b6;
            btn[48] = a9b1;
            btn[49] = a9b2;
            btn[50] = a9b3;
            btn[51] = a9b4;
            btn[52] = a9b5;
            btn[53] = a9b6;
            btn[54] = a10b1;
            btn[55] = a10b2;
            btn[56] = a10b3;
            btn[57] = a10b4;
            btn[58] = a10b5;
            btn[59] = a10b6;
            btn[60] = a11b1;
            btn[61] = a11b2;
            btn[62] = a11b3;
            btn[63] = a11b4;
            btn[64] = a11b5;
            btn[65] = a11b6;
            btn[66] = a12b1;
            btn[67] = a12b2;
            btn[68] = a12b3;
            btn[69] = a12b4;
            btn[70] = a12b5;
            btn[71] = a12b6;
            btn[72] = a13b1;
            btn[73] = a13b2;
            btn[74] = a13b3;
            btn[75] = a13b4;
            btn[76] = a13b5;
            btn[77] = a13b6;
            #endregion

            DataClasses1DataContext db = new DataClasses1DataContext();

            var varijabla = from s in db.tblRasporeds select s.botunIme;
            string[] name = varijabla.ToArray();

            var varijabla2 = from s in db.tblRasporeds select s.botunText;
            string[] text = varijabla2.ToArray();

            string[] sva_polja =
          {
                "a1b1","a1b2","a1b3","a1b4","a1b5","a1b6",
                "a2b1", "a2b2", "a2b3", "a2b4", "a2b5", "a2b6",
                "a3b1","a3b2","a3b3","a3b4","a3b5","a3b6",
                "a4b1","a4b2","a4b3","a4b4","a4b5","a4b6",
                "a5b1","a5b2","a5b3","a5b4","a5b5","a5b6",
                "a6b1","a6b2","a6b3","a6b4","a6b5","a6b6",
                "a7b1","a7b2","a7b3","a7b4","a7b5","a7b6",
                "a8b1","a8b2","a8b3","a8b4","a8b5","a8b6",
                "a9b1","a9b2","a9b3","a9b4","a9b5","a9b6",
                "a10b1","a10b2","a10b3","a10b4","a10b5","a10b6",
                "a11b1","a11b2","a11b3","a11b4","a11b5","a11b6",
                "a12b1","a12b2","a12b3","a12b4","a12b5","a12b6",
                "a13b1","a13b2","a13b3","a13b4","a13b5","a13b6"
            };

            /*for ( int i=0;i<78; i++)
            {
                btn[i].Name = sva_polja[i]; 
                btn[i]=sva_polja[i]  //NE RADI logicno nijedno
            }*/

            for (int i = 0; i < sva_polja.Count(); i++)
            {
                for (int j = 0; j < name.Count(); j++)
                {
                    if (sva_polja[i] == name[j])
                    {
                        btn[i].Text = text[j];


                        if (text[j] == "Kružni trening")
                        {
                            btn[i].BackColor = Color.MediumPurple;
                        }
                        else if (text[j] == "Kickbox")
                        {
                            btn[i].BackColor = Color.MediumSeaGreen;
                        }
                        else if (text[j] == "Privatni trening")
                        {
                            btn[i].BackColor = Color.Orange;
                        }
                        else
                        {
                            btn[i].BackColor = Color.White;
                            //btn[i].BackColor = Color.FromArgb(251, 229, 109);
                        }
                    }
                }
            }
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
    }
}
