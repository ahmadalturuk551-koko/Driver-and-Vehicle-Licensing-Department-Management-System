using DataAccessSettings;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Security.Policy;

namespace DataAccessLayer
{

    public static class clsTestsData
    {
        public static DataTable GetAllTests()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Tests;";
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
                // log ex
            }


            return dt;
        }

        public static bool GetTestInfoByID(int TestID, ref int TestAppointmentID, ref bool TestResult, ref string Notes, ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Tests WHERE TestID = @TestID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestID", TestID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    TestAppointmentID = (int)reader["TestAppointmentID"];
                    TestResult = (bool)reader["TestResult"];
                    if (reader["Notes"] != DBNull.Value)
                    {
                        Notes = (string)reader["Notes"];
                    }
                    else
                    {
                        Notes = "";
                    }
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                // log ex
            }


            return isFound;
        }

        public static int AddNewTest(int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {
            int TestID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Tests (TestAppointmentID, TestResult, Notes, CreatedByUserID)
                             VALUES (@TestAppointmentID, @TestResult, @Notes, @CreatedByUserID);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("@TestResult", TestResult);

            if (Notes != "" && Notes != null)
                command.Parameters.AddWithValue("@Notes", Notes);
            else
                command.Parameters.AddWithValue("@Notes", System.DBNull.Value);

            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    TestID = insertedID;
                }
            }
            catch (Exception ex)
            {
                // log ex
            }


            return TestID;
        }

        public static bool UpdateTest(int TestID, int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE Tests SET
                             TestAppointmentID = @TestAppointmentID,
                             TestResult = @TestResult,
                             Notes = @Notes,
                             CreatedByUserID = @CreatedByUserID
                             WHERE TestID = @TestID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestID", TestID);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("@TestResult", TestResult);

            if (Notes != "" && Notes != null)
                command.Parameters.AddWithValue("@Notes", Notes);
            else
                command.Parameters.AddWithValue("@Notes", System.DBNull.Value);

            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // log ex
            }


            return (rowsAffected > 0);
        }

        public static bool DeleteTest(int TestID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"DELETE FROM Tests WHERE TestID = @TestID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestID", TestID);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // log ex
            }


            return (rowsAffected > 0);
        }

        public static int TestTrails(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {

            int Trails = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            string query = @"select   COUNT(*) As Trails 
                      FROM         Tests INNER JOIN
                      TestAppointments ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID INNER JOIN
                      LocalDrivingLicenseApplications ON TestAppointments.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID

					  Where  TestAppointments.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID AND TestAppointments.TestTypeID = @TestTypeID ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);


            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int trails))
                {
                    Trails = trails;
                }


            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return Trails;

        }

        public static bool WillRetakeTest(int LocalDrivingLicenseApplicationID,int TestTypeID)
        {
            bool WillRetakeTest = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"
        
                              SELECT  top 1 Tests.TestResult
 FROM         Tests INNER JOIN
 TestAppointments ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID INNER JOIN
 LocalDrivingLicenseApplications ON TestAppointments.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID

 where  TestAppointments.IsLocked = 1 AND LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID AND TestAppointments.TestTypeID = @TestTypeID
 order by TestAppointments.TestAppointmentID ASC";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();


                SqlDataReader reader = command.ExecuteReader();

                if(reader.Read())
                {
                    WillRetakeTest = reader.HasRows;
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

            return WillRetakeTest;
        }

        public static bool IsPassedTheTest(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            bool IsPasssed = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"
                      SELECT    Passed = 1
                      FROM         LocalDrivingLicenseApplications INNER JOIN
                      TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN
                      Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                      WHERE TestAppointments.TestTypeID = @TestTypeID AND LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID AND TestResult = 1";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsPasssed = reader.HasRows;
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

            return IsPasssed;
        }

        public static bool IsTookTest(int TestTypeID, int LocalDrivingLicenseApplicationID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            string query = @"SELECT Found = 1 FROM TestAppointments
                             WHERE TestAppointments.IsLocked  = '1' AND TestAppointments.TestTypeID = @TestTypeID AND TestAppointments.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID;";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

                reader.Close();
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static int PassedTestsCountPerClassType(int LocalDrivingLicenseApplicationID,int LicenseClassID)
        {
            int Count = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @" 	  SELECT    COUNT(dbo.Tests.TestID) AS PassedTestCount
                            FROM         dbo.Tests INNER JOIN
                                                   dbo.TestAppointments ON dbo.Tests.TestAppointmentID = dbo.TestAppointments.TestAppointmentID INNER JOIN
												    dbo.LocalDrivingLicenseApplications ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = dbo.TestAppointments.LocalDrivingLicenseApplicationID
                            WHERE      (dbo.TestAppointments.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID) AND (dbo.Tests.TestResult = 1) AND LocalDrivingLicenseApplications.LicenseClassID = @LicenseClassID";

           

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Count = (int)reader[0];
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

            return Count;

        }

    }


}
