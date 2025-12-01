using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataBusinessLayer
{
    public enum enMode { AddNew = 0, Update = 1 }

    public class clsLicense
    {
        public enMode Mode = enMode.AddNew;
       // 1-FirstTime, 2-Renew, 3-Replacement for Damaged, 4- Replacement for Lost.

        public enum enIssueReason {FirstTime = 1,Renew = 2, ReplacementForDamaged = 3,ReplacementForLost = 4};
        enIssueReason eIssueReason = enIssueReason.FirstTime;
        public string IssueReasonTxt
        {
            get
            {
                switch(IssueReason)
                {
                    case 1:
                        return "FirstTime";
                        break;
                    case 2:
                        return "Renew";
                        break;
                    case 3:
                        return "Replacement for Damaged";
                        break;

                    case 4:
                        return "Replacement for Lost";
                        break;
                }
                return "";
            }
        }
        public int ID { get; set; }                     // LicenseID
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public clsDriver Driver;
        public int LicenseClassID { get; set; }
        public clsLicenseClass LicenseClassInfo;
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }  
        public string Notes { get; set; }               // nullable
        public float PaidFees { get; set; }           // smallmoney/decimal
        public bool IsActive { get; set; }

        public bool IsLiceneseDetained
        {
            get
            {
                return clsDetainedLicense.IsLicenseDetained(ID);
            }
        }
        public string ActiveMode
        {
            get
            {
                if(IsActive)
                {
                    return "Yes";
                }
                else
                {
                    return "No";
                }
            }
        }
        public byte IssueReason { get; set; }           // tinyint
        public int CreatedByUserID { get; set; }

        public clsLicense()
        {
            this.ID = -1;
            this.ApplicationID = -1;
            this.DriverID = -1;
            this.LicenseClassID = -1;
            this.IssueDate = DateTime.MinValue;
            this.ExpirationDate = DateTime.MinValue;
            this.Notes = "";
            this.PaidFees = 0;
            this.IsActive = false;
            this.IssueReason = 0;
            this.CreatedByUserID = -1;
            this.LicenseClassInfo = null;
            this.Driver = null;
            Mode = enMode.AddNew;
            eIssueReason = enIssueReason.Renew;
        }

        // private constructor used by Find factory methods
        private clsLicense(int id,int applicationID,int driverID,int licenseClass,DateTime issueDate,DateTime expirationDate,string notes, float paidFees,bool isActive,byte issueReason,int createdByUserID)
        {
            this.ID = id;
            this.ApplicationID = applicationID;
            this.DriverID = driverID;
            this.LicenseClassID = licenseClass;
            this.IssueDate = issueDate;
            this.ExpirationDate = expirationDate;
            this.Notes = notes;
            this.PaidFees = paidFees;
            this.IsActive = isActive;
            this.IssueReason = issueReason;
            this.CreatedByUserID = createdByUserID;
            this.LicenseClassInfo = clsLicenseClass.Find(LicenseClassID);
            this.Driver = clsDriver.Find(driverID);
            Mode = enMode.Update;
            eIssueReason = (enIssueReason)issueReason;
        }

        // Calls DAL to insert and updates this.ID
        private bool _AddNewLicense()
        {
            // Expect clsLicenseData.AddNewLicense(...) returns inserted LicenseID or -1
            int newID = clsLicenseData.AddNewLicense(this.ApplicationID,this.DriverID,this.LicenseClassID,this.IssueDate,
                     this.ExpirationDate,this.Notes,this.PaidFees,this.IsActive,this.IssueReason,this.CreatedByUserID);
            
                this.ID = newID;
            
            return this.ID != -1;
        }

        // Calls DAL to update
        private bool _UpdateLicense()
        {
            return clsLicenseData.UpdateLicense(this.ID,this.ApplicationID ,this.DriverID,this.LicenseClassID,this.IssueDate,this.ExpirationDate,this.Notes, this.PaidFees,this.IsActive,this.IssueReason, this.CreatedByUserID);
        }

        // Factory: find by LicenseID
        public static clsLicense Find(int id)
        {
            // prepare refs for DAL call
            int applicationID = -1;
            int driverID = -1;
            int licenseClass = -1;
            DateTime issueDate = DateTime.MinValue;
            DateTime expirationDate = DateTime.MinValue;
            string notes = null;
            float paidFees = 0;
            bool isActive = false;
            byte issueReason = 0;
            int createdByUserID = -1;

            if (clsLicenseData.GetLicenseInfoByID(id, ref applicationID, ref driverID, ref licenseClass, ref issueDate, ref expirationDate, ref notes, ref paidFees, ref isActive, ref issueReason, ref createdByUserID))
            {
                return new clsLicense(id, applicationID, driverID, licenseClass, issueDate, expirationDate, notes, paidFees, isActive, issueReason, createdByUserID);
            }
            else
                return null;
        }

        // Helper: find latest license for a driver (if DAL provides GetLicenseInfoByDriverID)
        public static clsLicense FindByApplicationID(int ApplicationID)
        {
            int licenseID = -1;
            if (clsLicenseData.GetLicenseInfoByApplicationID(ApplicationID, ref licenseID))
                return Find(licenseID);

            else
                return null;
        }

        public static DataTable GetLocalLicensesOfPerson(int PersonID)
        {
            return clsLicenseData.GetLocalLicensesOfPerson(PersonID);
        }

        public static DataTable GetInternationalLicensesOfPerson(int PersonID)
        {
            return clsLicenseData.GetInternationalLicensesOfPerson(PersonID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewLicense())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateLicense();

                default:
                    return false;
            }
        }

        public bool IsExpired()
        {
            return (ExpirationDate < DateTime.Now);
        }

        public static DataTable GetAllLicenses()
        {
            return clsLicenseData.GetAllLicenses();
        }

        public static bool DeleteLicense(int ID)
        {
            return clsLicenseData.DeleteLicense(ID);
        }

        public static bool IsLicenseExist(int ApplicationID, int LicenseClassID)
        {
            return clsLicenseData.IsLicenseExist(ApplicationID, LicenseClassID);
        }
    }

}
