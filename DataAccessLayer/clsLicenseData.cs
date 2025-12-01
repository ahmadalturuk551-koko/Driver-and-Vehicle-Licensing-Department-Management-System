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
    public class clsLicenseData
    {
        public static bool GetLicenseInfoByID(int ID, ref int ApplicationID,ref int DriverID,ref int LicenseClass,ref DateTime IssueDate,
            ref DateTime ExpirationDate,ref string Notes, ref float PaidFees,ref bool IsActive, ref byte IssueReason,ref int CreatedByUserID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Licenses WHERE LicenseID = @LicenseID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", ID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    ApplicationID = (int)reader["ApplicationID"];
                    DriverID =(int)reader["DriverID"];
                    LicenseClass =  (int)reader["LicenseClassID"] ;
                    IssueDate = (DateTime)reader["IssueDate"] ;

                    if (reader["Notes"] == DBNull.Value)
                        Notes = "";
                    else

                        Notes = (string)reader["Notes"];
                    PaidFees =  Convert.ToSingle(reader["PaidFees"]) ;
                    IsActive =  Convert.ToBoolean(reader["IsActive"]) ;
                    IssueReason = Convert.ToByte(reader["IssueReason"]);
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];

                }

                reader.Close();
            }
            catch (Exception)
            {
               
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

     
        public static int AddNewLicense(int ApplicationID,int DriverID,int LicenseClassID, DateTime IssueDate,DateTime ExpirationDate,string Notes, float PaidFees,bool IsActive,byte IssueReason,int CreatedByUserID)
        {
            int newLicenseID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"
            INSERT INTO Licenses
                (ApplicationID, DriverID, LicenseClassID, IssueDate, ExpirationDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserID)
            VALUES
                (@ApplicationID, @DriverID, @LicenseClassID, @IssueDate, @ExpirationDate, @Notes, @PaidFees, @IsActive, @IssueReason, @CreatedByUserID);
            SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);

            if (string.IsNullOrEmpty(Notes))
                command.Parameters.AddWithValue("@Notes", DBNull.Value);
            else
                command.Parameters.AddWithValue("@Notes", Notes);

            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@IssueReason", IssueReason);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    newLicenseID = insertedID;
                }
            }
            catch (Exception)
            {
                // optional: log ex.Message
            }
            finally
            {
                connection.Close();
            }

            return newLicenseID;
        }

        public static bool UpdateLicense(int LicenseID, int ApplicationID,int DriverID, int LicenseClassID, DateTime IssueDate, DateTime? ExpirationDate, string Notes, float PaidFees, bool IsActive, byte IssueReason, int CreatedByUserID)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

         
            string query = @"
            UPDATE Licenses
            SET ApplicationID = @ApplicationID,
                DriverID = @DriverID,
                LicenseClassID = @LicenseClassID,
                IssueDate = @IssueDate,
                ExpirationDate = @ExpirationDate,
                Notes = @Notes,
                PaidFees = @PaidFees,
                IsActive = @IsActive,
                IssueReason = @IssueReason,
                CreatedByUserID = @CreatedByUserID
            WHERE LicenseID = @LicenseID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);

            if (string.IsNullOrEmpty(Notes))
                command.Parameters.AddWithValue("@Notes", DBNull.Value);
            else
                command.Parameters.AddWithValue("@Notes", Notes);

            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@IssueReason", IssueReason);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

        public static DataTable GetAllLicenses()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Licenses ORDER BY IssueDate DESC";

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
            catch (Exception)
            {
                // optional: log ex.Message
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }


        public static DataTable GetLocalLicensesOfPerson(int PersonID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT    Licenses.LicenseID, Licenses.ApplicationID, LicenseClasses.ClassName, Licenses.IssueDate, Licenses.ExpirationDate, Licenses.IsActive
                      FROM         Licenses INNER JOIN
                      LicenseClasses ON Licenses.LicenseClassID = LicenseClasses.LicenseClassID INNER JOIN
                      Drivers ON Licenses.DriverID = Drivers.DriverID 

					  WHERE Drivers.PersonID = @PersonID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

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
            catch (Exception)
            {
                // optional: log ex.Message
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }

        public static DataTable GetInternationalLicensesOfPerson(int PersonID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT    InternationalLicenses.InternationalLicenseID, InternationalLicenses.ApplicationID, LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID, InternationalLicenses.IssueDate, 
                      InternationalLicenses.ExpirationDate,InternationalLicenses.IsActive
                      FROM         InternationalLicenses INNER JOIN
                      LocalDrivingLicenseApplications ON LocalDrivingLicenseApplications.ApplicationID = InternationalLicenses.ApplicationID INNER JOIN
                      Applications ON InternationalLicenses.ApplicationID = Applications.ApplicationID AND LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID
					  
					  where ApplicantPersonID = @ApplicantPersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicantPersonID", PersonID);

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
            catch (Exception)
            {
                // optional: log ex.Message
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }

        public static bool DeleteLicense(int LicenseID)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"DELETE FROM Licenses WHERE LicenseID = @LicenseID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                // optional: log ex.Message
            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

        public static bool IsLicenseExist(int ApplicationID, int LicenseClassID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Found = 1 FROM Licenses WHERE ApplicationID = @ApplicationID AND LicenseClassID = @LicenseClassID AND IsActive = 1";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                isFound = reader.HasRows;
                reader.Close();
            }
            catch (Exception)
            {
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }



        // i should to check it if its true or not
        public static bool GetLicenseInfoByDriverID(int DriverID, ref int LicenseID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT TOP 1 LicenseID FROM Licenses WHERE DriverID = @DriverID ORDER BY IssueDate ASC";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DriverID", DriverID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                  isFound = true;
                    LicenseID = (int)reader["LicenseID"];
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

        public static bool GetLicenseInfoByApplicationID(int ApplicationID, ref int LicenseID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT LicenseID FROM Licenses WHERE ApplicationID = @ApplicationID ";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    LicenseID = (int)reader["LicenseID"];
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
