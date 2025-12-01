using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBusinessLayer
{
    public class clsApplication
    {
        public enum enMode { AddNew = 1, Update = 2 };
        public enMode Mode;
        public enum enApplicationType
        {
            NewDrivingLicense = 1, RenewDrivingLicense = 2, ReplaceLostDrivingLicense = 3,
            ReplaceDamagedDrivingLicense = 4, ReleaseDetainedDrivingLicsense = 5, NewInternationalLicense = 9, RetakeTest = 6
        };

       

        public int ApplicationID { get; set; }
       
        public int ApplicantPersonID { get; set; }
        public clsPerson clsPersonInfo;
        public DateTime ApplicationDate { get; set; }
        public DateTime LastStatusDate { get; set; }
        public int ApplicationTypeID { get; set; }

        public clsApplicationType ApplicationType;
        public float PaidFees { get; set; }
        public int CreatedByUserID { get; set; }

        public clsUser CreatedByUser;
        public enum enApplicationStatus { New = 1, Cancelled = 2, Completed = 3 };
        public enApplicationStatus ApplicationStatus { set; get; }

        public string FullName { get; set; }

        public string ApplicantFullName
        {
            
            get
            {
                return clsPerson.Find(ApplicantPersonID).FullName;
            }
            
        }

        public string StatusText
        {
            get
            {
                switch (ApplicationStatus)
                {
                    case enApplicationStatus.New:
                        return "New";
                        break;
                    case enApplicationStatus.Cancelled:
                        return "Cancelled";
                        break;

                    case enApplicationStatus.Completed:
                        return "Completed";
                        break;
                    default:
                        return "New";
                }
            }
        }

        public clsApplication(int applicantPersonID, DateTime applicationDate, int applicationTypeID,
              byte applicationStatus, DateTime lastStatusDate, float paidFees, int createdByUserID)
        {

            this.ApplicantPersonID = applicantPersonID;
            this.ApplicationDate = applicationDate;
            this.ApplicationTypeID = applicationTypeID;
            this.ApplicationType = clsApplicationType.Find(ApplicationTypeID);
            this.ApplicationStatus = (enApplicationStatus)applicationStatus;
            this.LastStatusDate = lastStatusDate;
            this.PaidFees = paidFees;
            this.CreatedByUserID = createdByUserID;
            this.CreatedByUser = clsUser.Find(createdByUserID);
            this.clsPersonInfo = clsPerson.Find(applicantPersonID);
      
            Mode = enMode.Update;
        }

        public clsApplication()
        {
            this.ApplicantPersonID = 0;
            this.ApplicationDate = DateTime.MinValue;
            this.ApplicationTypeID = 0;
            this.ApplicationStatus = enApplicationStatus.New;
            this.LastStatusDate = DateTime.MinValue;
            this.PaidFees = 0;
            this.CreatedByUserID = 0;
            this.CreatedByUser = null;
            Mode = enMode.AddNew;
            this.ApplicationTypeID = 0;
            this.clsPersonInfo = null;
         
        }

        public static DataTable GetAllApplications()
        {
            return clsApplicationData.GetAllApplications();
        }

        public static bool DeleteApplication(int ID)
        {
            return clsApplicationData.DeleteApplication(ID);
        }

        public static clsApplication FindBaseApplication(int ID)
        {
            int applicantPersonID = 0; DateTime applicationDate = DateTime.MinValue; int ApplicationTypeID = 0; byte ApplicationStatus = 1;
            DateTime LastStatusDate = DateTime.MinValue; float PaidFees = 0; int CreatedByUserID = 0;

            if (clsApplicationData.GetApplicationInfoByID(ID, ref applicantPersonID, ref applicationDate, ref ApplicationTypeID, ref ApplicationStatus, ref LastStatusDate, ref PaidFees, ref CreatedByUserID))
            {
                return new clsApplication(applicantPersonID, applicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID);
            }
            else
            {
                return null;
            }
        }

        private bool _AddNewLocalDrivingLicenseApp()
        {
            this.ApplicationID = clsApplicationData.AddNewApplication(ApplicantPersonID, ApplicationDate, ApplicationTypeID, (byte)ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID);

            return (this.ApplicationID != -1);
        }

        private bool _UpdateLocalDrivingLicenseApp()
        {
            return clsApplicationData.UpdateApplicationType(ApplicationID, ApplicantPersonID, ApplicationDate, ApplicationTypeID, (byte)ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID);
        }


        public bool Save()
        {

            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewLocalDrivingLicenseApp())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateLocalDrivingLicenseApp();


            }
            return false;

        }

        public static bool CancelApplication(int ApplicationID)
        {
            return clsApplicationData.CancelApplication(ApplicationID);
        }

    }
}
