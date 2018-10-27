using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OperasWebSites.Models
{
    public class OperasInitializer : DropCreateDatabaseAlways<OperasDB>
    {

        protected override void Seed(OperasDB context)
        {
            base.Seed(context);

            var operas = new List<Opera> { new Opera { Title = "Cosi Fan Tutte", Year = 1790, Composer = "Mozart" } };

            operas.ForEach(o => context.Operas.Add(o));

            context.SaveChanges();
        }


    }
}