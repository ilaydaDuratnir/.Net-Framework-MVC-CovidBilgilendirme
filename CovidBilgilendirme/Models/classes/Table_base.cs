using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CovidBilgilendirme.Models.classes
{
    public class Table_base
    {
        public List<Table> Positives { get; set; }

        public List<Table> Negatives { get; set; }

        public List<Table> TeenPositive { get; set; }

        public List<Table> OldPositive { get; set; }
    }
}