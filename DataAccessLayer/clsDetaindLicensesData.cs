using System;
using System.Data.SqlClient;
using System.Data;
using DataAccessSettings;
using System.ComponentModel;

namespace DataAccessLayer
{
    public class clsDetaindLicensesData
    {
        public static bool GetDetainedLicenseInfoByID(int LicenseID, ref int DetainID, ref DateTime DetainDate,
            ref float FineFees, ref int CreatedByUserID, ref bool IsReleased,
            ref DateTime ReleaseDate, ref int ReleasedByUserID, ref int ReleaseApplicationID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM DetainedLicenses WHERE LicenseID = @LicenseID AND IsReleased = 0;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;

                    DetainID = (int)reader["DetainID"];
                    DetainDate = (DateTime)reader["DetainDate"];
                    FineFees = Convert.ToSingle(reader["FineFees"]);
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IsReleased = (bool)reader["IsReleased"];

                    // Handle Nullable Fields
                    if (reader["ReleaseDate"] != DBNull.Value)
                        ReleaseDate = (DateTime)reader["ReleaseDate"];
                    else
                        ReleaseDate = DateTime.MinValue;

                    if (reader["ReleasedByUserID"] != DBNull.Value)
                        ReleasedByUserID = (int)reader["ReleasedByUserID"];
                    else
                        ReleasedByUserID = -1;

                    if (reader["ReleaseApplicationID"] != DBNull.Value)
                        ReleaseApplicationID = (int)reader["ReleaseApplicationID"];
                    else
                        ReleaseApplicationID = -1;
                }
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

        public static int AddNewDetainedLicense(int LicenseID, DateTime DetainDate, float FineFees, int CreatedByUserID)
        {
            int DetainID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"INSERT INTO DetainedLicenses 
                         (LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased)
                         VALUES 
                         (@LicenseID, @DetainDate, @FineFees, @CreatedByUserID, 0);
                         SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@DetainDate", DetainDate);
            command.Parameters.AddWithValue("@FineFees", FineFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    DetainID = insertedID;
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return DetainID;
        }

        public static bool UpdateDetainedLicense(int ID, int LicenseID, DateTime DetainDate, float FineFees,
                                                 bool IsReleased, DateTime? ReleaseDate,
                                                 int? ReleasedByUserID, int? ReleaseApplicationID)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"UPDATE DetainedLicenses
                         SET LicenseID = @LicenseID,
                             DetainDate = @DetainDate,
                             FineFees = @FineFees,
                             IsReleased = @IsReleased,
                             ReleaseDate = @ReleaseDate,
                             ReleasedByUserID = @ReleasedByUserID,
                             ReleaseApplicationID = @ReleaseApplicationID
                         WHERE DetainID = @DetainID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DetainID", ID);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@DetainDate", DetainDate);
            command.Parameters.AddWithValue("@FineFees", FineFees);
            command.Parameters.AddWithValue("@IsReleased", IsReleased);

            // Handle Nullable Parameters
            command.Parameters.AddWithValue("@ReleaseDate", (object)ReleaseDate ?? DBNull.Value);
            command.Parameters.AddWithValue("@ReleasedByUserID", (object)ReleasedByUserID ?? DBNull.Value);
            command.Parameters.AddWithValue("@ReleaseApplicationID", (object)ReleaseApplicationID ?? DBNull.Value);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

        public static DataTable GetAllDetainedLicenses()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM DetainedLicenses ORDER BY DetainDate DESC";
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
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }

        public static bool DeleteDetainedLicense(int ID)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"DELETE DetainedLicenses 
                         WHERE DetainID = @DetainID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DetainID", ID);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

        public static bool IsLicenseDetained(int LicenseID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT Found=1 FROM DetainedLicenses WHERE LicenseID = @LicenseID AND IsReleased = 0";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);

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
    }
}

