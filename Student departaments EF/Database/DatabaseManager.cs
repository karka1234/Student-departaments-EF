using Student_departaments_EF.Database.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_departaments_EF.Database
{
    internal class DatabaseManager
    {
        private readonly DatabaseConfig _config;
        public DatabaseManager(DatabaseConfig config)
        {
            _config = config;
        }


        //manageris kuris leis prideti dalykus i db
    }
}
