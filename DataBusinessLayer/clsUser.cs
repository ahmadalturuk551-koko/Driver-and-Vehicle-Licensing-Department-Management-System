using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;


namespace DataBusinessLayer
{
    public class clsUser
    {
      

        public enum enMode { AddNew = 0,Update = 1};
        private enMode _Mode = enMode.AddNew;

        public int UserID { set; get; }
        public int PersonID { set; get; }
        public string UserName { set; get; }
        public string Password { set; get; }
        public bool IsActive { set; get; }

        public clsPerson Person;

        public clsUser(int userID, int personID, string userName, string password, bool isActive)
        {
            _Mode = enMode.Update;
            UserID = userID;
            PersonID = personID;
            UserName = userName;
            Password = password;
            IsActive = isActive;
            
        }

        public clsUser()
        {
            _Mode = enMode.AddNew;
            UserID = -1;
            PersonID = -1;
            UserName = "";
            Password = "";
            IsActive = false;
           
        }

        public static clsUser Find(int UserID)
        {
            int personID = 0;string userName = ""; string password = ""; bool isActive = false;

            if(clsUserData.GetUserInfoByID(UserID, ref personID, ref userName, ref password, ref isActive))
            {
                return new clsUser(UserID, personID, userName, password, isActive); 
            }
            return null;
        }

        public static clsUser FindByUsernameAndPassword(string username,string password)
        {
            int personID = 0, userID = 0;
            bool isActive = false;

            if (clsUserData.GetUserInfoByUsernameAndPassword(username, password, ref userID, ref personID, ref isActive))
                return new clsUser(userID, personID, username, password, isActive);
            else
                return null;
            
            
        }

        public static bool DeleteUser(int UserID)
        {
            return clsUserData.DeleteUser(UserID);
        }

        private  bool _AddNewUser()
        {

             UserID = clsUserData.AddNewUser(this.PersonID, this.UserName, this.Password, this.IsActive);
            return (UserID != -1);
        }

        private  bool _UpdateUser()
        {
            return clsUserData.UpdateUser(this.UserID, this.PersonID, this.UserName, this.Password, this.IsActive);
        }


        public bool Save()
        {
            switch(_Mode)
            {
                case enMode.AddNew:
                    
                        if(_AddNewUser())
                        {
                            _Mode = enMode.Update;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                        
                case enMode.Update:

                    return _UpdateUser();
               

            }
                return false;
        }
       
        public static DataTable GetAllUsers()
        {
            return clsUserData.GetAllUsers();
        }

        public static bool IsUserExist(int UserID)
        {
            return clsUserData.IsUserExist(UserID);
        }

        public static bool IsUserExistByPersonID(int PersonID)
        {
            return clsUserData.IsUserExistByPersonID(PersonID);
        }

    }


}
