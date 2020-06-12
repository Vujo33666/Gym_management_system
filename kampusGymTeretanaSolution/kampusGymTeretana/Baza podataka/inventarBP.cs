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
    class inventarBP
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
                String sql = "SELECT * FROM tblInvertar";

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
        public bool Insert(inventarKlasa c)
        {
            //Create a boolean var and set its default value to false
            bool isSuccess = false;
            //Create an object of SqlConnection to connect DB
            SqlConnection conn = new SqlConnection(myconnstrng);

            if (c.sprava != "" && c.kolicina != 0)
            {
                try
                {
                    //Create a string var to store the insert query
                    String sql = "INSERT INTO tblInvertar(sprava,kolicina) VALUES (@sprava,@kolicina)";

                    //Create an SQL command to pass the value in our query
                    SqlCommand cmd = new SqlCommand(sql, conn);


                    //Create the paramater to get value from UI and pass it to SQL query above
                    cmd.Parameters.AddWithValue("@sprava", c.sprava);
                    cmd.Parameters.AddWithValue("@kolicina", c.kolicina);

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
            else
            {
                MessageBox.Show("Niste unijeli ili naziv opreme ili količinu", "Upozorenje!");
                return false;
            }
        }
        #endregion

        #region UPDATE data in DB(User module)
        public bool Update(inventarKlasa c)
        {
            //Create a boolean var and set its default value to false
            bool isSuccess = false;
            //Create an object of SqlConnection to connect DB
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //Create a string var to store the insert query
                String sql = "UPDATE tblInvertar SET kolicina=@kolicina WHERE sprava=@sprava";


                //Create an SQL command to pass the value in our query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Create the paramater to get value from UI and pass it to SQL query above
                cmd.Parameters.AddWithValue("@sprava", c.sprava);
                cmd.Parameters.AddWithValue("@kolicina", c.kolicina);


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
        public bool Delete(inventarKlasa c)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                String sql = "DELETE FROM tblInvertar WHERE sprava=@sprava AND kolicina=@kolicina";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@sprava", c.sprava);
                cmd.Parameters.AddWithValue("@kolicina", c.kolicina);
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
