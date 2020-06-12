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
    class rasporedBP
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng2"].ConnectionString;

        public bool loginCheck(rasporedKlasa r)
        {
            bool isSuccess = false;

            //connectiong to db
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                string sql = "SELECT * FROM tblRaspored WHERE botunIme=@botunIme AND botunText=@botunText";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@botunIme", r.botunIme);
                cmd.Parameters.AddWithValue("@botunText", r.botunText);

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
                String sql = "SELECT * FROM tblRaspored";

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
        public bool Insert(rasporedKlasa r)
        {
            //Create a boolean var and set its default value to false
            bool isSuccess = false;
            //Create an object of SqlConnection to connect DB
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //Create a string var to store the insert query
                String sql = "INSERT INTO tblRaspored(botunIme,botunText) VALUES (@botunIme,@botunText)";

                //Create an SQL command to pass the value in our query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Create the paramater to get value from UI and pass it to SQL query above
                cmd.Parameters.AddWithValue("@botunIme", r.botunIme);
                cmd.Parameters.AddWithValue("@botunText", r.botunText);

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
        public bool Update(rasporedKlasa r)
        {
            //Create a boolean var and set its default value to false
            bool isSuccess = false;
            //Create an object of SqlConnection to connect DB
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //Create a string var to store the insert query
                String sql = "UPDATE tblRaspored SET botunText=@botunText WHERE botunIme=@botunIme";


                //Create an SQL command to pass the value in our query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Create the paramater to get value from UI and pass it to SQL query above
                cmd.Parameters.AddWithValue("@botunIme", r.botunIme);
                cmd.Parameters.AddWithValue("@botunText", r.botunText);


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
        public bool Delete(rasporedKlasa r)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                String sql = "DELETE FROM tblRaspored WHERE botunIme=@botunIme";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@botunIme", r.botunIme);
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
