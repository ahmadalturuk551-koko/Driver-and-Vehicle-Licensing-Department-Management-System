using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBusinessLayer
{
    public class clsTestType
    {
        public int ID { set; get; }
        public string TypeTitle { set; get; }
        public string TypeDescription { set; get; }
        public int Fees { set; get; }

        public clsTestType(int iD, string typeTitle,string typeDescription, int fees)
        {
            ID = iD;
            TypeTitle = typeTitle;
            TypeDescription = typeDescription;
            Fees = fees;
        }

        public static DataTable GetAllTypes()
        {
            return clsTestTypeDataAccess.GetAllTestTypes();
        }

        public static clsTestType Find(int ID)
        {
            string typeTitle = "";
            string typeDescription = "";
            int fees = 0;

            if (clsTestTypeDataAccess.GetTestTypeInfoByID(ID,ref typeTitle,ref typeDescription,ref fees))
            {
                return new clsTestType(ID, typeTitle, typeDescription, fees);
            }
            else
            {
                return null;
            }

        }

        public bool UpdateTestType()
        {
            return clsTestTypeDataAccess.UpdateTestType(ID, TypeDescription, TypeDescription, Fees);
        }
    }
}
