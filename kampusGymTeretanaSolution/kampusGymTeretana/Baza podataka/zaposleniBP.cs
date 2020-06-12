using kampusGymTeretana.Klase;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace kampusGymTeretana.Baza_podataka
{
    class zaposleniBP
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng2"].ConnectionString;

        #region SELECT data from DB
        public DataTable Select()
        {
            //Create an object to connect DB
            SqlConnection conn = new SqlConnection(myconnstrng);

            //Create a DataTable to hold the data from DB
            DataTable dt = new DataTable();

            try
            {
                //Write SQL Query to get data from DB
                String sql = "SELECT * FROM tblZaposlenici";

                //Create SQL command to execute query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Create SQL data adapter to hold the data from DB temporarily
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //Open DB Connection
                conn.Open();

                //Transfer data from SqlData adapter to DataTable
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                //Display error mssg if there is any exceptional errors
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //Close DB connection
                conn.Close();
            }
            return dt;
        }
        #endregion

        #region Insert data into DB from user module
        public bool Insert(zaposleniKlasa c)
        {
            //Create a boolean var and set its default value to false
            bool isSuccess = false;
            //Create an object of SqlConnection to connect DB
            SqlConnection conn = new SqlConnection(myconnstrng);

            if (c.ime != "" && c.prezime != "")
            {
                try
                {
                    //Create a string var to store the insert query
                    String sql = "INSERT INTO tblZaposlenici(ime,prezime,email,mobitel,datum_rodenja,id_zaposlenika) VALUES (@ime,@prezime,@email,@mobitel,@datum_rodenja,@id_zaposlenika)";

                    //Create an SQL command to pass the value in our query
                    SqlCommand cmd = new SqlCommand(sql, conn);


                    //Create the paramater to get value from UI and pass it to SQL query above
                    cmd.Parameters.AddWithValue("@ime", c.ime);
                    cmd.Parameters.AddWithValue("@prezime", c.prezime);
                    cmd.Parameters.AddWithValue("@email", c.email);
                    cmd.Parameters.AddWithValue("@mobitel", c.mobitel);
                    cmd.Parameters.AddWithValue("@datum_rodenja", c.datum_rodenja);
                    //cmd.Parameters.AddWithValue("@slika", c.slika);
                    cmd.Parameters.AddWithValue("@id_zaposlenika", c.id_zaposlenika);

                    //Open DB connection
                    conn.Open();

                    //INT value to hold the value after query is executed
                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        //Query executed successfully
                        isSuccess = true;
                    }
                    else
                    {
                        //Failed to execute query
                        isSuccess = false;
                    }

                }
                catch (Exception ex)
                {
                    //Display error mssg if there is any exceptional errors
                    MessageBox.Show(ex.Message+" BPgreska");
                }
                finally
                {
                    //Close DB connection
                    conn.Close();
                }
                return isSuccess;
            }
            else
            {
                MessageBox.Show("Niste unijeli neko obavezno polje", "Upozorenje!");
                return false;
            }
        }
        #endregion

        #region UPDATE data in DB(User module)
        public bool Update(zaposleniKlasa c)
        {
            //Create a boolean var and set its default value to false
            bool isSuccess = false;
            //Create an object of SqlConnection to connect DB
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //Create a string var to store the insert query
                String sql = "UPDATE tblZaposlenici SET ime=@ime,email=@email,mobitel=@mobitel,prezime=@prezime,datum_rodenja=@datum_rodenja WHERE id_zaposlenika=@id_zaposlenika";


                //Create an SQL command to pass the value in our query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Create the paramater to get value from UI and pass it to SQL query above
                cmd.Parameters.AddWithValue("@ime", c.ime);
                cmd.Parameters.AddWithValue("@prezime", c.prezime);
                cmd.Parameters.AddWithValue("@email", c.email);
                cmd.Parameters.AddWithValue("@mobitel", c.mobitel);
                cmd.Parameters.AddWithValue("@datum_rodenja", c.datum_rodenja);
                //cmd.Parameters.AddWithValue("@slika", c.slika);
                cmd.Parameters.AddWithValue("@id_zaposlenika", c.id_zaposlenika);

                //Open DB connection
                conn.Open();

                //INT value to hold the value after query is executed
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    //Query executed successfully
                    isSuccess = true;
                }
                else
                {
                    //Failed to execute query
                    isSuccess = false;
                }

            }
            catch (Exception ex)
            {
                //Display error mssg if there is any exceptional errors
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //Close DB connection
                conn.Close();
            }
            return isSuccess;
        }
        #endregion

        #region Delete data from DB(User module)
        public bool Delete(zaposleniKlasa c)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                String sql = "DELETE FROM tblZaposlenici WHERE id_zaposlenika=@id_zaposlenika";
                SqlCommand cmd = new SqlCommand(sql, conn);
                //Create the paramater to get value from UI and pass it to SQL query above
                cmd.Parameters.AddWithValue("@ime", c.ime);
                cmd.Parameters.AddWithValue("@prezime", c.prezime);
                cmd.Parameters.AddWithValue("@email", c.email);
                cmd.Parameters.AddWithValue("@mobitel", c.mobitel);
                cmd.Parameters.AddWithValue("@datum_rodenja", c.datum_rodenja);
                //cmd.Parameters.AddWithValue("@slika", c.slika);
                cmd.Parameters.AddWithValue("@id_zaposlenika", c.id_zaposlenika); 

                conn.Open();
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    //Query executed successfully
                    isSuccess = true;
                }
                else
                {
                    //Failed to execute query
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {
                //Display error mssg if there is any exceptional errors
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //Close DB connection
                conn.Close();
            }
            return isSuccess;
        }
        #endregion
    }
}
