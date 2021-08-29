using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDentalClinicWebAPI.Database
{
    public class Data
    {
        public static void Seed(eDentalClinicContext context)
        {
            context.Database.Migrate();
        }
    }
}
