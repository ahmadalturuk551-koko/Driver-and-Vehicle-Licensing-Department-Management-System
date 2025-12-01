using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBusinessLayer
{
    public class clsInternationalLicense : clsApplication
    {
        public int InternationalLicenseID { get; set; }
        public int DriverID { get; set; }
        public clsDriver DriverInfo;
        public int IssuedUsingLocalLicenseID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }
        public string IsActiveTxt
        {
            get
            {
                if (IsActive)
                    return "Yes";
                else
                    return "No";
            }
        }


        public enum enMode { AddNew = 1, Update = 2 };
        public enMode Mode;

        public clsInternationalLicense()
        {
            this.Mode = enMode.AddNew;
            this.InternationalLicenseID = 0;
            this.DriverID = 0;
            this.IssuedUsingLocalLicenseID = 0;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now.AddYears(1);
            this.IsActive = true;
            this.DriverInfo = null;
            this.clsPersonInfo = null;
        }

        private clsInternationalLicense(
            int InternationalLicenseID, int ApplicationID, int DriverID,
            int IssuedUsingLocalLicenseID, DateTime IssueDate,
            DateTime ExpirationDate, bool IsActive, int CreatedByUserID,
            DateTime ApplicationDate, int ApplicationTypeID,
            enApplicationStatus ApplicationStatus, DateTime LastStatusDate,
            float PaidFees
        )
        {
            this.InternationalLicenseID = InternationalLicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.IssuedUsingLocalLicenseID = IssuedUsingLocalLicenseID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.IsActive = IsActive;
            this.CreatedByUserID = CreatedByUserID;

            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;

            this.CreatedByUser = clsUser.Find(CreatedByUserID);
            this.ApplicationType = clsApplicationType.Find(ApplicationTypeID);
            this.DriverInfo = clsDriver.Find(DriverID);
            this.clsPersonInfo = clsPerson.Find(ApplicantPersonID);
            Mode = enMode.Update;
        }

        public static DataTable GetAllInternationalLicenses()
        {
            return clsInternationalLicenseData.GetAllLicenses();
        }

        public static clsInternationalLicense Find(int InternationalLicenseID)
        {
            int ApplicationID = -1, DriverID = -1, IssuedUsingLocalLicenseID = -1, CreatedByUserID = -1;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
            bool IsActive = false;

            bool IsFound = clsInternationalLicenseData.GetLicenseInfoByID(
                InternationalLicenseID, ref ApplicationID, ref DriverID,
                ref IssuedUsingLocalLicenseID, ref IssueDate,
                ref ExpirationDate, ref IsActive, ref CreatedByUserID);

            if (IsFound)
            {
                clsApplication Application = clsApplication.FindBaseApplication(ApplicationID);

                return new clsInternationalLicense(
                    InternationalLicenseID, ApplicationID, DriverID, IssuedUsingLocalLicenseID,
                    IssueDate, ExpirationDate, IsActive, CreatedByUserID,
                    Application.ApplicationDate, Application.ApplicationTypeID,
                    (enApplicationStatus)Application.ApplicationStatus,
                    Application.LastStatusDate, Application.PaidFees
                );
            }
            else
                return null;
        }

        public bool Delete()
        {
            bool IsInternationalDeleted = clsInternationalLicenseData.DeleteLicense(this.InternationalLicenseID);

            if (IsInternationalDeleted)
            {
                return clsApplication.DeleteApplication(this.ApplicationID);
            }

            return false;
        }

        private bool _AddNewInternationalLicense()
        {
            this.InternationalLicenseID = clsInternationalLicenseData.AddNewLicense(
                this.ApplicationID, this.DriverID, this.IssuedUsingLocalLicenseID,
                this.IssueDate, this.ExpirationDate, this.IsActive, this.CreatedByUserID);

            return (this.InternationalLicenseID != -1);
        }

        private bool _UpdateInternationalLicense()
        {
            return clsInternationalLicenseData.UpdateLicense(
                this.InternationalLicenseID, this.ApplicationID, this.DriverID,
                this.IssuedUsingLocalLicenseID, this.IssueDate,
                this.ExpirationDate, this.IsActive, this.CreatedByUserID);
        }

        public bool Save()
        {
            base.Mode = (clsApplication.enMode)Mode;
            if (!base.Save())
                return false;

            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewInternationalLicense())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:
                    return _UpdateInternationalLicense();
            }

            return false;
        }

        public static bool IsDriverHaveAnInternationalLicesne(int DriverID)
        {
            return clsInternationalLicenseData.IsDriverHaveAnInternationalLicesne(DriverID);
        }

        public static int GetActiveInternationalLicenseIDByDriverID(int DriverID)
        {

            return clsInternationalLicenseData.GetActiveInternationalLicenseIDByDriverID(DriverID);

        }

        public static DataTable GetDriverInternationalLicenses(int DriverID)
        {
            return clsInternationalLicenseData.GetDriverInternationalLicenses(DriverID);
        }
    }

}
