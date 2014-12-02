using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Achievments;
//using Achievments.AchievmentProperties;


namespace DataLayer
{
        public class AchievmentContext : DbContext
        {
            public DbSet<Achievment> Achievments { get; set; }

            public DbSet<AchievmentPropertyType> PropertyTypes { get; set; }

            //public DbSet<EnumPropertyType> EnumPropertyTypes { get; set; } 
        }
}
