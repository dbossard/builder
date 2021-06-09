using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace builder.Models
{
    public class RegularizationRule
    {
        public int Id { get; set; }
        public Account TargetAccount { get; set; }
        public IReadOnlyCollection<Account> InputAccounts { get; set; }
        public Population Population { get; set; }

    }
}
