using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class Class1
    {
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["MJuarezPT"].ConnectionString.ToString();
        }
    }
}
