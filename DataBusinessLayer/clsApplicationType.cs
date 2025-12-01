using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBusinessLayer
{
    public class clsApplicationType
    {
        public int ID { set; get; }
        public string TypeTitle { set; get; }
        public float Fees { set; get; }

        public clsApplicationType(int iD, string typeTitle, float fees)
        {
            ID = iD;
            TypeTitle = typeTitle;
            Fees = fees;
        }

        public static DataTable GetAllApplications()
        {
            return clsApplicationTypeDataAccess.GetAllApplicationTypes();
        }

        public static clsApplicationType Find(int ID)
        {
            string typeTitle = "";
            float fees = 0;

            if (clsApplicationTypeDataAccess.GetApplicationTypeInfoByID(ID, ref typeTitle, ref fees))
            {
                return new clsApplicationType(ID, typeTitle, fees);
            }
            else
            {

                return null;
            }

        }

        public bool UpdateApplication()
        {
            return clsApplicationTypeDataAccess.UpdateApplicationType(ID,TypeTitle, Fees);
        }

    }
}
