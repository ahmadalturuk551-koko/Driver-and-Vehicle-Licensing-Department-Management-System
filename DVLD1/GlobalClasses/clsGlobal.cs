using DataBusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD1.GlobalClasses
{
    public class clsGlobal
    {

        public static clsUser CurrentUser;

        public static string UsernameAndPassFilePath = "credentials.txt";

        public static int ExpirationPeroid = 10;
    }
}
