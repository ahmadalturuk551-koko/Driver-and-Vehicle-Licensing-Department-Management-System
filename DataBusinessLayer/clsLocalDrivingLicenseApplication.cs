using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static DataBusinessLayer.clsApplication;

namespace DataBusinessLayer
{
    public class clsLocalDrivingLicenseApplication : clsApplication
    {
     
        public int LocalDrivingLicenseApplicationID { get; set; }
        public int LicenseClassID { get; set; }

        public clsLicenseClass LicenseClassInfo;
  

        public enum enMode { AddNew = 1,Update = 2};
        public enMode Mode;

        public clsLocalDrivingLicenseApplication()
        {
            this.Mode = enMode.AddNew;
            this.LocalDrivingLicenseApplicationID = 0;
            this.LicenseClassID = 0;
            this.LicenseClassInfo = null;

        }

        private clsLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID, int ApplicationID, int ApplicantPersonID,
           DateTime ApplicationDate, int ApplicationTypeID,
            enApplicationStatus ApplicationStatus, DateTime LastStatusDate,
            float PaidFees, int CreatedByUserID, int LicenseClassID)

        {
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.ApplicationID = ApplicationID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = (int)ApplicationTypeID;
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.LicenseClassID = LicenseClassID;
            this.LicenseClassInfo = clsLicenseClass.Find(LicenseClassID);
            this.CreatedByUser = clsUser.Find(CreatedByUserID);
            this.ApplicationType = clsApplicationType.Find(ApplicationTypeID);
            Mode = enMode.Update;
        }

        public static DataTable GetAllLocalApplications()
        {
            return clsLocalDrivingLicenseApplicationData.GetAllLocalDrivingApplications();        
        }

        public static bool IsThereAnActiveLocalDrivingLicenseApp(string ApplicantNationalNo,string AppClassName)
        {
            return clsLocalDrivingLicenseApplicationData.IsThereAnActiveLocalDrivingLicenseApp(ApplicantNationalNo, AppClassName);
        }

        public static bool IsThereLocalDrivingLicenseApp(string ApplicantNationalNo,string AppClassName)
        {
            return clsLocalDrivingLicenseApplicationData.IsThereLocalDrivingLicenseApp(ApplicantNationalNo, AppClassName);
        }

       
        public static clsLocalDrivingLicenseApplication Find(int LocalDrivingLicenseApplicationID)
        {
            // 
            int ApplicationID = -1, LicenseClassID = -1;

            bool IsFound = clsLocalDrivingLicenseApplicationData.GetLocalDrivingLicenseApplicationInfoByID(LocalDrivingLicenseApplicationID,ref ApplicationID,ref LicenseClassID);  

            if (IsFound)
            {
                //now we find the base application
                clsApplication Application = clsApplication.FindBaseApplication(ApplicationID);

                //we return new object of that person with the right data
                return new clsLocalDrivingLicenseApplication(
                    LocalDrivingLicenseApplicationID, ApplicationID,
                    Application.ApplicantPersonID,
                                     Application.ApplicationDate, Application.ApplicationTypeID,
                                    (enApplicationStatus)Application.ApplicationStatus, Application.LastStatusDate,
                                     Application.PaidFees, Application.CreatedByUserID, LicenseClassID);
            }
            else
                return null;


        }

        public static clsLocalDrivingLicenseApplication FindByApplicationID(int ApplicationID)
        {
            int LocalDrivingLicenseApplicationID = -1, LicenseClassID = -1;

            bool IsFound = clsLocalDrivingLicenseApplicationData.GetLocalDrivingLicenseApplicationInfoByApplicationID(ApplicationID, ref LocalDrivingLicenseApplicationID, ref LicenseClassID);

            if (IsFound)
            {
                //now we find the base application
                clsApplication Application = clsApplication.FindBaseApplication(ApplicationID);

                //we return new object of that person with the right data
                return new clsLocalDrivingLicenseApplication(
                    LocalDrivingLicenseApplicationID, ApplicationID,
                    Application.ApplicantPersonID,
                                     Application.ApplicationDate, Application.ApplicationTypeID,
                                    (enApplicationStatus)Application.ApplicationStatus, Application.LastStatusDate,
                                     Application.PaidFees, Application.CreatedByUserID, LicenseClassID);
            }
            else
                return null;

        }

        public  bool Delete()
        {

            bool IsLocalApplicationDeleted = false;

            IsLocalApplicationDeleted = clsLocalDrivingLicenseApplicationData.DeleteLocalDrivingLicenseApplication(this.LocalDrivingLicenseApplicationID);

            if(IsLocalApplicationDeleted)
            {
                return clsApplication.DeleteApplication(this.ApplicationID);
            }
            {
                return false;
            }

           
        }

        private bool _AddNewLocalDrivingLicenseApplication()
        {

            this.LocalDrivingLicenseApplicationID = clsLocalDrivingLicenseApplicationData.AddNewLocalDrivingLicenseApplication(ApplicationID, LicenseClassID);
            return this.LocalDrivingLicenseApplicationID != -1;
           
          
        }

        private bool _UpdateLocalDrivingLicenseApplication()
        {


            return clsLocalDrivingLicenseApplicationData.UpdateLocalDrivingLicenseApplication(LocalDrivingLicenseApplicationID, ApplicationID, LicenseClassID);

            
        }

        //public static bool Cancel()
        //{
        //   return 
        //}

        public bool Save()
        {

            base.Mode = (clsApplication.enMode)Mode;
            if (!base.Save())
                return false;

            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewLocalDrivingLicenseApplication())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateLocalDrivingLicenseApplication();


            }
            return false;

        }
    }

}
