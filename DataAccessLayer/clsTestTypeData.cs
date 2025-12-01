using DataAccessSettings;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class clsTestTypeDataAccess
    {
        public static DataTable GetAllTestTypes()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT [TestTypeID]
                            ,[TestTypeTitle]
                            ,[TestTypeDescription]
                            ,[TestTypeFees]
                            FROM [dbo].[TestTypes]";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }

                reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return dt;
        }

        public static bool UpdateTestType(int TestTypeID, string TestTypeTitle,string TestTypeDescription, int TestTypeFees)
        {
            int AffectedRows = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"
                           UPDATE TestTypes
                           SET TestTypeTitle = @TestTypeTitle ,
                               TestTypeDescription = @TestTypeDescription ,
                               TestTypeFees = @TestTypeFees
                         WHERE TestTypeID = @TestTypeID";
                        
            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@TestTypeTitle", TestTypeTitle);
            command.Parameters.AddWithValue("@TestTypeDescription", TestTypeDescription);
            command.Parameters.AddWithValue("@TestTypeFees", TestTypeFees);


            try
            {
                connection.Open();

                AffectedRows = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return (AffectedRows > 0);
        }

        public static bool GetTestTypeInfoByID(int TestTypeID,ref string TestTypeTitle,ref string TestTypeDescription,ref int TestTypeFees)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM TestTypes WHERE TestTypeID = @TestTypeID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    TestTypeFees = Convert.ToInt32(reader["TestTypeFees"]);
                    TestTypeDescription = (string)reader["TestTypeDescription"];
                    TestTypeTitle = (string)reader["TestTypeTitle"];
                }


                reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }


    }
}
