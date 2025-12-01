using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBusinessLayer
{
    public class clsTestAppointment
    {
        enum enMode { AddNew = 1,Update = 2};
        enMode _Mode;

        public int TestAppointmentID { get; set; }
        public int TestTypeID { get; set; }
        public int LocalDrivingLicenseApplicationID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public float PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public clsUser CreatedByUserInfo;

        public bool IsLocked { get; set; }

        public clsTestAppointment(int testAppointmentID, int testTypeID, int localDrivingLicenseApplicationID, DateTime appointmentDate, float paidFees, int createdByUserID, bool isLocked)
        {
            TestAppointmentID = testAppointmentID;
            TestTypeID = testTypeID;
            LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            AppointmentDate = appointmentDate;
            PaidFees = paidFees;
            CreatedByUserID = createdByUserID;
            IsLocked = isLocked;
            _Mode = enMode.Update;
            CreatedByUserInfo = clsUser.Find(createdByUserID);
        }

        public clsTestAppointment()
        {
            TestAppointmentID = -1;
            TestTypeID = -1;
            LocalDrivingLicenseApplicationID = -1;
            AppointmentDate = DateTime.Now;
            PaidFees = 0;
            CreatedByUserID = -1;
            IsLocked = false;
            _Mode = enMode.AddNew;
            CreatedByUserInfo = null;
        }

        public static DataTable GetAllAppiontments(int TestTypeID,int LocalDrivingLicenseApplicationID)
        {
            return clsTestAppointmentsData.GetAllTestAppointments(TestTypeID, LocalDrivingLicenseApplicationID);
        }

        private bool _AddNewTestApp()
        {
            this.TestAppointmentID = clsTestAppointmentsData.AddNewTestAppointment(TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked);

            return (this.TestAppointmentID != -1);
        }

        private bool _UpdateTestApp()
        {
            return clsTestAppointmentsData.UpdateTestAppiontment(TestAppointmentID,TestTypeID,LocalDrivingLicenseApplicationID,AppointmentDate,PaidFees,CreatedByUserID,IsLocked);
        }

        public static bool DeleteTestAppointment(int TestAppointmentID)
        {
            return clsTestAppointmentsData.DeleteTestAppointment(TestAppointmentID);
        }

        public static bool IsAnActiveTestAppExist(int TestTypeID,int LocalDrivingLicenseApplicationID)
        {
            return clsTestAppointmentsData.IsAnActiveTestAppExist(TestTypeID, LocalDrivingLicenseApplicationID);
        }

        public static clsTestAppointment Find(int TestAppointmentID)
        {
            int testTypeID = -1, localDrivingLicenseApplicationID = -1;
            DateTime appointmentDate = DateTime.Now; 
            float paidFees = 0;
            int createdByUserID = -1;
            bool isLocked  =false;

            if (clsTestAppointmentsData.GetTestAppointmentInfoByID(TestAppointmentID, ref testTypeID, ref localDrivingLicenseApplicationID, ref appointmentDate, ref paidFees, ref createdByUserID, ref isLocked))
                return new clsTestAppointment(TestAppointmentID, testTypeID, localDrivingLicenseApplicationID, appointmentDate, paidFees, createdByUserID, isLocked);

            else
                return null;
        }



        public bool Save()
        {


            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTestApp())
                    {

                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateTestApp();

            }


            return false;
        }
    }
}
