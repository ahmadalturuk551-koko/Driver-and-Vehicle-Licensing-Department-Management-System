using System;
using System.Data;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using DataAccessLayer;

namespace DataBusinessLayer
{
    public class clsPerson
    {
        public int ID { get; set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public short Gendor { get; set; }

        public string GenforTxt
        {
            get
            {
                if(Gendor == 0)
                {
                    return "Male";
                }
                else
                {
                    return "Female";

                }
            }
        }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int NationalityCountryID { get; set; }
        public string ImageBath { get; set; }

        public string FullName 
        {
            get { return FirstName + " " + SecondName + " " + ThirdName + " " + LastName; }
            
        }

        public enum enMode { AddNew = 1, Update = 2 }

        private enMode Mode = enMode.AddNew;

        clsPerson(int iD, string firstName, string secondName, string thirdName,
            string lastName, string nationalNo, DateTime dateOfBirth, short gendor, string address,
            string phone, string email, int nationalityCountryID, string imageBath)
        {
            this.ID = iD;
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.ThirdName = thirdName;
            this.LastName = lastName;
            this.DateOfBirth = dateOfBirth;
            this.Gendor = gendor;
            this.Address = address;
            this.Phone = phone;
            this.Email = email;
            this.NationalityCountryID = nationalityCountryID;
            this.ImageBath = imageBath;
            this.NationalNo = nationalNo;
          

            Mode = enMode.Update;
        }

        public clsPerson()
        {
            this.ID = -1;         
            this.FirstName = "";
            this.SecondName = "";
            this.ThirdName = "";
            this.LastName = "";
            this.DateOfBirth = DateTime.MinValue;
            this.Gendor = 0;
            this.Address = "";
            this.Phone = "";
            this.Email = "";
            this.NationalityCountryID = -1;
            this.ImageBath = "";
            this.NationalNo = "";          
            Mode = enMode.AddNew;
        }

        public static clsPerson Find(int ID)
        {
            string nationalNo = ""; string firstName = ""; string secondName = ""; string thirdName = "";
            string lastName = ""; DateTime dateOfBirth = DateTime.MinValue; short gendor = 0; string address = "";
            string phone = ""; string email = ""; int nationalCountryID = 0; string imageBath = "";

            if (clsPersonData.GetPersonInfoByID(ID,ref firstName, ref secondName, ref thirdName, ref lastName,
                ref nationalNo, ref dateOfBirth, ref gendor, ref address, ref phone, ref email,ref nationalCountryID,ref imageBath))
            {
                return new clsPerson(ID,  firstName,
                                    secondName, thirdName, lastName,nationalNo, dateOfBirth,
                                    gendor, address, phone, email,nationalCountryID, imageBath);
            }
            else
            {
                return null;
            }
        }

         public static clsPerson Find(string NationalNo)
        {
            string firstName = ""; string secondName = ""; string thirdName = "";
            string lastName = ""; DateTime dateOfBirth = DateTime.MinValue; short gendor = 0; string address = "";
            string phone = ""; string email = ""; int nationalCountryID = 0; string imageBath = "";
            int personID = 0;

            if (clsPersonData.GetPersonInfoByNationalNo(NationalNo,ref personID, ref firstName, ref secondName,ref thirdName,ref lastName,ref dateOfBirth
                ,ref gendor,ref address,ref phone, ref email, ref nationalCountryID, ref imageBath))
            {
                return new clsPerson(personID,  firstName,
                                    secondName, thirdName, lastName, NationalNo, dateOfBirth,
                                    gendor, address, phone, email,nationalCountryID, imageBath);
            }
            else
            {
                return null;
            }
        }

        public static bool DeletePerson(int ID)
        {
            return clsPersonData.DeletePerson(ID);
        }

        public static bool IsPersonExist(int ID)
        {
            return clsPersonData.IsPersonExist(ID);
        }
        public static bool IsPersonExist(string NationalNo)
        {
            return clsPersonData.IsPersonExist(NationalNo);
        }

        private bool _UpdatePerson()
        {
            
            return clsPersonData.UpdatePerson(this.ID , this.NationalNo, this.FirstName, this.SecondName, this.ThirdName,
            this.LastName, this.DateOfBirth, this.Gendor, this.Address, this.Phone, this.Email, this.NationalityCountryID, this.ImageBath);

        }

        private bool _AddNewPerson()
        {
            this.ID = clsPersonData.AddNewPerson(this.NationalNo, this.FirstName, this.SecondName, this.ThirdName,
            this.LastName, this.DateOfBirth, this.Gendor, this.Address, this.Phone, this.Email, this.NationalityCountryID, this.ImageBath);

            return (this.ID != -1);
        }

        public static DataTable GetAllPeople()
        {
            return clsPersonData.GetAllPeople();
        }

        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPerson())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdatePerson();

            }


            return false;
        }
    }
}
