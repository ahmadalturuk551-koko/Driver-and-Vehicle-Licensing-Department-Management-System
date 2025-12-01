using DataAccessSettings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class clsUserData
    {
        // int UserID,int PersonID,string UserName,string  Password,Byte Is active
        public static bool GetUserInfoByID(int UserID,ref int PersonID,ref string UserName,ref string Password,ref bool IsActive )
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Users WHERE UserID = @UserID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    PersonID = (int)reader["PersonID"];
                    UserName = (string)reader["UserName"];
                    Password = (string)reader["Password"];
                    IsActive = (bool)reader["IsActive"];
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

        public static bool GetUserInfoByUsernameAndPassword(string UserName,string Password,ref int UserID,ref int PersonID, ref bool IsActive)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from Users where Password = @Password and UserName = @UserName;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@UserName", UserName);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;
                    PersonID = (int)reader["PersonID"];              
                    UserID = (int)reader["UserID"];              
                    IsActive = (bool)reader["IsActive"];
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

        public static int AddNewUser(int PersonID,string UserName,string Password, bool IsActive)
        {
            // This function will return User ID Number if succeeded and -1 if not.

            int UserID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string qurey = @"                            
                        INSERT INTO [dbo].[Users]
                                 ([PersonID]
                                 ,[UserName]
                                 ,[Password]
                                 ,[IsActive])
                                 VALUES
                                      (@PersonID,@UserName,@Password,@IsActive);
                                        SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(qurey, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);


            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                {
                    UserID = InsertedID;
                }


            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return UserID;

        }

        public static bool DeleteUser(int UserID)
        {
            int AffectedRows = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"DELETE Users  WHERE UserID = @UserID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);

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

        public static bool UpdateUser(int UserID,int PersonID,string UserName,string Password, bool IsActive)
        {
            int AffectedRows = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"
                            UPDATE Users SET
                                PersonID = @PersonID,
                                UserName = @UserName,
                                Password = @Password,
                                IsActive = @IsActive                               
                            WHERE UserID = @UserID";

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@UserID", UserID);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@IsActive", IsActive);          

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

        public static DataTable GetAllUsers()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT    Users.*,People.FirstName + ' ' + 
                            People.SecondName + ' ' +  ISNULL(People.ThirdName, '')+ People.LastName As FullName
                            FROM         Users INNER JOIN
                            People ON Users.PersonID = People.PersonID;";

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

        public static bool IsUserExist(int UserID)
        {
            bool IsExist = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT Found = 1 FROM Users WHERE UserID = @UserID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                IsExist = reader.HasRows;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return IsExist;
        }

        public static bool IsUserExistByPersonID(int PersonID)
        {
            bool IsExist = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT Found = 1 FROM Users WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                IsExist = reader.HasRows;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return IsExist;
        }

    }
}
