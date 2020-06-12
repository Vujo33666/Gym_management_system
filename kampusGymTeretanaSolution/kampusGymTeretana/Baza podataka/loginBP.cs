using kampusGymTeretana.Klase;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kampusGymTeretana.Baza_podataka
{
    class loginBP
    {
        static string myconnstrng2 = ConfigurationManager.ConnectionStrings["connstrng2"].ConnectionString;

        public bool loginCheck(loginKlasa l)
        {
            bool isSuccess = false;

            //connectiong to db
            SqlConnection conn = new SqlConnection(myconnstrng2);

            try
            {
                string sql = "SELECT * FROM tblLogin WHERE username=@username AND password=@password";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@username", l.username);
                cmd.Parameters.AddWithValue("@password", l.password);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    //login ok
                    isSuccess = true;
                }
                else
                {
                    //login failed
                    isSuccess = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return isSuccess;
        }
    }
}
