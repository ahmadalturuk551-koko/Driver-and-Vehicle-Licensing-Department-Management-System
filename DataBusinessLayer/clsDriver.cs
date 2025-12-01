using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBusinessLayer
{
    public class clsDriver
    {
        public enum enMode { AddNew = 1,Update = 2};
        public  enMode Mode = enMode.AddNew;

        public int ID { get; set; }               // DriverID
        public int PersonID { get; set; }
        public clsPerson PersonInfo;
        public int CreatedByUserID { get; set; }
        public DateTime CreatedDate { get; set; }

        public clsDriver()
        {
            this.ID = -1;
            this.PersonID = -1;
            this.CreatedByUserID = -1;
            this.CreatedDate = DateTime.MinValue;
            this.PersonInfo = null;
            Mode = enMode.AddNew;
        }

        private clsDriver(int id, int personID, int createdByUserID, DateTime createdDate)
        {
            this.ID = id;
            this.PersonID = personID;
            this.CreatedByUserID = createdByUserID;
            this.CreatedDate = createdDate;
            this.PersonInfo = clsPerson.Find(personID);
            Mode = enMode.Update;
        }

        private bool _AddNewDriverPerson()
        {
            this.ID = clsDriverPersonData.AddNewDriver(this.PersonID, this.CreatedByUserID, this.CreatedDate);
            return (this.ID != -1);
        }

        private bool _UpdateDriverPerson()
        {
            return clsDriverPersonData.UpdateDriver(this.ID, this.PersonID, this.CreatedByUserID, this.CreatedDate);
        }

        public static clsDriver Find(int ID)
        {
            int personID = -1;
            int createdByUserID = -1;
            DateTime createdDate = DateTime.MinValue;

            if (clsDriverPersonData.GetDriverInfoByID(ID, ref personID, ref createdByUserID, ref createdDate))
                return new clsDriver(ID, personID, createdByUserID, createdDate);
            else
                return null;
        }

        public static clsDriver FindByPersonID(int personID)
        {
            int driverID = -1;
            int createdByUserID = -1;
            DateTime createdDate = DateTime.MinValue;

            if (clsDriverPersonData.GetDriverInfoByPersonID(personID,ref driverID,ref createdByUserID, ref createdDate))
                return new clsDriver(driverID, personID, createdByUserID, createdDate);
            else
                return null;
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewDriverPerson())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _UpdateDriverPerson();

                default:
                    return false;
            }
        }

        public static DataTable GetAll()
        {
            return clsDriverPersonData.GetAllDrivers();
        }

        public static bool Delete(int ID)
        {
            return clsDriverPersonData.DeleteDriver(ID);
        }

        public static bool IsExist(int ID)
        {
            return clsDriverPersonData.IsDriverExist(ID);
        }
        public static bool IsExistByPersonID(int PersonID)
        {
            return clsDriverPersonData.IsDriverExistByPersonID(PersonID);
        }
    }
}
