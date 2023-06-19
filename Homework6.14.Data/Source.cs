using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework6._14.Data
{
    public class Source
    {
        public int Id { get; set; }
        public string IncomeSource { get; set; }

        public List<Income> Incomes { get; set; }
    }
}
