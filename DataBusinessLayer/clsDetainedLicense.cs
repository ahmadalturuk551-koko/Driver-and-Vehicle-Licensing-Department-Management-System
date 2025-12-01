using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBusinessLayer
{

    public class clsDetainedLicense
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int ID { set; get; }
        public int LicenseID { set; get; }
        public DateTime DetainDate { set; get; }
        public float FineFees { set; get; }
        public int CreatedByUserID { set; get; }
        public bool IsReleased { set; get; }
        public DateTime ReleaseDate { set; get; }
        public int ReleasedByUserID { set; get; }
        public int ReleaseApplicationID { set; get; }

        public clsDetainedLicense()
        {
            this.ID = -1;
            this.LicenseID = -1;
            this.DetainDate = DateTime.MinValue;
            this.FineFees = 0;
            this.CreatedByUserID = -1;
            this.IsReleased = false;
            this.ReleaseDate = DateTime.MinValue;
            this.ReleasedByUserID = -1;
            this.ReleaseApplicationID = -1;

            Mode = enMode.AddNew;
        }

        private clsDetainedLicense(int ID, int LicenseID, DateTime DetainDate, float FineFees,
                                   int CreatedByUserID, bool IsReleased, DateTime ReleaseDate,
                                   int ReleasedByUserID, int ReleaseApplicationID)
        {
            this.ID = ID;
            this.LicenseID = LicenseID;
            this.DetainDate = DetainDate;
            this.FineFees = FineFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsReleased = IsReleased;
            this.ReleaseDate = ReleaseDate;
            this.ReleasedByUserID = ReleasedByUserID;
            this.ReleaseApplicationID = ReleaseApplicationID;

            Mode = enMode.Update;
        }

        private bool _AddNewDetainedLicense()
        {
            //call DataAccess Layer 
            this.ID = clsDetaindLicensesData.AddNewDetainedLicense(this.LicenseID, this.DetainDate, this.FineFees, this.CreatedByUserID);
            return (this.ID != -1);
        }

        private bool _UpdateDetainedLicense()
        {
            //call DataAccess Layer 
            return clsDetaindLicensesData.UpdateDetainedLicense(this.ID, this.LicenseID, this.DetainDate, this.FineFees,
                                                                this.IsReleased, this.ReleaseDate, this.ReleasedByUserID,
                                                                this.ReleaseApplicationID);
        }

        public static clsDetainedLicense Find(int LicenseID)
        {
            int DetainID = -1;
            DateTime DetainDate = DateTime.MinValue;
            float FineFees = 0;
            int CreatedByUserID = -1;
            bool IsReleased = false;
            DateTime ReleaseDate = DateTime.MinValue;
            int ReleasedByUserID = -1;
            int ReleaseApplicationID = -1;

            if (clsDetaindLicensesData.GetDetainedLicenseInfoByID(LicenseID, ref DetainID, ref DetainDate, ref FineFees,
                ref CreatedByUserID, ref IsReleased, ref ReleaseDate, ref ReleasedByUserID, ref ReleaseApplicationID))
            {
                return new clsDetainedLicense(DetainID, LicenseID, DetainDate, FineFees, CreatedByUserID,
                                              IsReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID);
            }
            else
            {
                return null;
            }
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewDetainedLicense())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateDetainedLicense();
            }

            return false;
        }

        public static DataTable GetAllDetainedLicenses()
        {
            return clsDetaindLicensesData.GetAllDetainedLicenses();
        }

        public static bool DeleteDetainedLicense(int ID)
        {
            return clsDetaindLicensesData.DeleteDetainedLicense(ID);
        }

        public static bool IsLicenseDetained(int ID)
        {
            return clsDetaindLicensesData.IsLicenseDetained(ID);
        }
    }
}
