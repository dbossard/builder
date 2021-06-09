using builder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace builder.Builders
{
    public class RegulBuilder
    {
        private IReadOnlyCollection<Account> _inputAccounts;
        private Account _targetAccount;

        public RegulBuilder ComptesImpactants(params Account[] inputAccounts)
        {
            _inputAccounts = inputAccounts.ToArray();
            return this;
        }

        public RegulBuilder CompteCible(Account targetAccount)
        {
            _targetAccount = targetAccount;
            return this;
        }

        public RegularizationRule Build()
        {
            return new RegularizationRule
            {
                InputAccounts = _inputAccounts,
                TargetAccount = _targetAccount
            };
        }
    }
}
