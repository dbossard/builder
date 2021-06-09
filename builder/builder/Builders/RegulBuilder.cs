using System.Collections.Generic;
using System.Linq;
using builder.Models;

namespace builder.Builders
{
    public class RegulBuilder : IRoot, IComptesImpactants, IComptesImpactantsResult, ICompteCibleResult, IBuild
    {
        private IReadOnlyCollection<Account> _inputAccounts = new[] {Comptes.Maladie};
        private Account _targetAccount = Comptes.Cp2020;

        private RegulBuilder()
        {
        }

        public static IRoot Create()
        {
            return new RegulBuilder();
        }

        public IComptesImpactantsResult ComptesImpactants(params Account[] inputAccounts)
        {
            _inputAccounts = inputAccounts.ToArray();
            return this;
        }

        public ICompteCibleResult CompteCible(Account targetAccount)
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

    public interface IRoot : IComptesImpactants, ICompteCible, IBuild
    {
    }

    public interface IComptesImpactants
    {
        IComptesImpactantsResult ComptesImpactants(params Account[] inputAccounts);
    }

    public interface IComptesImpactantsResult : ICompteCible, IBuild
    {
    }

    public interface ICompteCible
    {
        ICompteCibleResult CompteCible(Account targetAccount);
    }

    public interface ICompteCibleResult : IBuild
    {
    }
}
