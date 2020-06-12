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
    class urediclanoveBP
    {
        //Create a static string to connect DB
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
                String sql = "SELECT * FROM tblMembers";

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
        public bool Insert(urediKlasa c)
        {
            //Create a boolean var and set its default value to false
            bool isSuccess = false;
            //Create an object of SqlConnection to connect DB
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //Create a string var to store the insert query
                String sql = "INSERT INTO tblMembers(gym_id,ime,prezime,spol,datum_rodenja,email,datum_placanja,datum_vrijedi_do,vrsta_treninga,slika) VALUES (@gym_id,@ime,@prezime,@spol,@datum_rodenja,@email,@datum_placanja,@datum_vrijedi_do,@vrsta_treninga,@slika)";

                //Create an SQL command to pass the value in our query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Create the paramater to get value from UI and pass it to SQL query above
                cmd.Parameters.AddWithValue("@gym_id", c.gym_id);
                cmd.Parameters.AddWithValue("@ime", c.ime);
                cmd.Parameters.AddWithValue("@prezime", c.prezime);
                cmd.Parameters.AddWithValue("@spol", c.spol);
                cmd.Parameters.AddWithValue("@datum_rodenja", c.datum_rodenja);
                cmd.Parameters.AddWithValue("@email", c.email);
                cmd.Parameters.AddWithValue("@datum_placanja", c.datum_placanja);
                cmd.Parameters.AddWithValue("@datum_vrijedi_do", c.datum_vrijedi_do);
                cmd.Parameters.AddWithValue("@vrsta_treninga", c.vrsta_treninga);
                cmd.Parameters.AddWithValue("@slika", c.slika);

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

        #region UPDATE data in DB(User module)
        public bool Update(urediKlasa c)
        {
            //Create a boolean var and set its default value to false
            bool isSuccess = false;
            //Create an object of SqlConnection to connect DB
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //Create a string var to store the insert query
                String sql = "UPDATE tblMembers SET ime=@ime , prezime=@prezime , spol=@spol , datum_rodenja=@datum_rodenja , email=@email , vrsta_treninga=@vrsta_treninga  WHERE gym_id=@gym_id";
              

                //Create an SQL command to pass the value in our query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Create the paramater to get value from UI and pass it to SQL query above
                cmd.Parameters.AddWithValue("@gym_id", c.gym_id);
                cmd.Parameters.AddWithValue("@ime", c.ime);
                cmd.Parameters.AddWithValue("@prezime", c.prezime);
                cmd.Parameters.AddWithValue("@spol", c.spol);
                cmd.Parameters.AddWithValue("@datum_rodenja", c.datum_rodenja);
                cmd.Parameters.AddWithValue("@email", c.email);
               /* cmd.Parameters.AddWithValue("@datum_placanja", c.datum_placanja);
                cmd.Parameters.AddWithValue("@datum_vrijedi_do", c.datum_vrijedi_do); */
                cmd.Parameters.AddWithValue("@vrsta_treninga", c.vrsta_treninga);
               // cmd.Parameters.AddWithValue("@slika", c.slika);


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
        public bool Delete(urediKlasa c)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                String sql = "DELETE FROM tblMembers WHERE gym_id=@gym_id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", c.id);
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
