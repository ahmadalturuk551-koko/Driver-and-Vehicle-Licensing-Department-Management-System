using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DataBusinessLayer
{
    public class clsTest
    {
        enum enMode { AddNew = 1, Update = 2 }
        enMode _Mode;

        public int TestID { get; set; }
        public int TestAppointmentID { get; set; }
        public bool TestResult { get; set; }     
        public string TestResultText
        {
            get
            {
                return (TestResult ? "Passed" : "Failed");
            }
        }

        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }
        public clsUser CreatedByUserInfo;

        

        public clsTest(int testID, int testAppointmentID, bool testResult, string notes, int createdByUserID)
        {
            TestID = testID;
            TestAppointmentID = testAppointmentID;
            TestResult = testResult;
            Notes = notes;
            CreatedByUserID = createdByUserID;
            _Mode = enMode.Update;
            CreatedByUserInfo = clsUser.Find(CreatedByUserID);
        }

        public clsTest()
        {
            TestID = -1;
            TestAppointmentID = -1;
            TestResult = false;
            Notes = "";
            CreatedByUserID = -1;
            _Mode = enMode.AddNew;
            CreatedByUserInfo = null;
        }

        public static DataTable GetAllTests()
        {
            return clsTestsData.GetAllTests();
        }

        private bool _AddNewTest()
        {
            this.TestID = clsTestsData.AddNewTest(TestAppointmentID, TestResult, Notes, CreatedByUserID);
            return (this.TestID != -1);
        }

        private bool _UpdateTest()
        {
            return clsTestsData.UpdateTest(TestID, TestAppointmentID, TestResult, Notes, CreatedByUserID);
        }

        public static bool DeleteTest(int TestID)
        {
            return clsTestsData.DeleteTest(TestID);
        }

        public static clsTest Find(int TestID)
        {
            int testAppointmentID = -1;
            bool testResult = false;
            string notes = "";
            int createdByUserID = -1;

            if (clsTestsData.GetTestInfoByID(TestID, ref testAppointmentID, ref testResult, ref notes, ref createdByUserID))
                return new clsTest(TestID, testAppointmentID, testResult, notes, createdByUserID);

            else
                return null;
        }

        public static int TestTrails(int LocalDrivingLicenseApplicationID,int TestTypeID)
        {
            return clsTestsData.TestTrails(LocalDrivingLicenseApplicationID, TestTypeID);
        }

        public static bool WillRetakeTest(int LocalDrivingLicenseApplicationID,int TestTypeID)
        {
            return clsTestsData.WillRetakeTest(LocalDrivingLicenseApplicationID, TestTypeID);
        }

        public static bool IsPassedVisionTest(int LocalDrivingLicenseApplicationID)
        {
            return clsTestsData.IsPassedTheTest(LocalDrivingLicenseApplicationID, 1);
        }

        public static bool IsPassedWrittenTest(int LocalDrivingLicenseApplicationID)
        {
            return clsTestsData.IsPassedTheTest(LocalDrivingLicenseApplicationID, 2);
        }

        public static bool IsPassedStreetTest(int LocalDrivingLicenseApplicationID)
        {
            return clsTestsData.IsPassedTheTest(LocalDrivingLicenseApplicationID, 3);
        }

        public static bool IsPassedAllTests(int LocalDrivingLicenseApplicationID)
        {
            return IsPassedVisionTest(LocalDrivingLicenseApplicationID) && IsPassedWrittenTest(LocalDrivingLicenseApplicationID) && IsPassedStreetTest(LocalDrivingLicenseApplicationID);
        }

        public static bool IsPassedTest(int LocalDrivingLicenseApplicationID,int TestTypeID)
        {
            return clsTestsData.IsPassedTheTest(LocalDrivingLicenseApplicationID, TestTypeID);
        }

        public static int PassedTestsCountPerClassType(int LocalDrivingLicenseApplicationID,int LicenseClassID)
        {
            return clsTestsData.PassedTestsCountPerClassType(LocalDrivingLicenseApplicationID,LicenseClassID);

        }

        public static bool IsTookTest(int TestTypeID, int LocalDrivingLicenseApplicationID)
        {
            return clsTestsData.IsTookTest(TestTypeID, LocalDrivingLicenseApplicationID);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTest())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateTest();
            }

            return false;
        }
    }

}
