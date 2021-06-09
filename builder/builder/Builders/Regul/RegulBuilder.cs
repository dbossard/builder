using System;
using System.Collections.Generic;
using System.Linq;
using builder.Models;

namespace builder.Builders.Regul
{
    public class RegulBuilder :
        IRoot,
        IComptesImpactants, IComptesImpactantsResult, 
        ICompteCibleResult,
        IPopulation, IPopulationResult,
        IBuild
    {
        private readonly int _reglementaireId;
        private IReadOnlyCollection<Account> _inputAccounts = new[] { Comptes.Maladie };
        private Account _targetAccount = Comptes.Cp2020;
        private Func<Populations.IRoot, Populations.IBuild> _populationBuilderConfigure;

        private RegulBuilder(int reglemetaireId)
        {
            _reglementaireId = reglemetaireId;
        }

        public static IRoot OnReglementaire(int reglementaireId)
        {
            return new RegulBuilder(reglementaireId);
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

        public IPopulationResult Population(Func<Populations.IRoot, Populations.IBuild> populationBuilderConfigure)
        {
            _populationBuilderConfigure = populationBuilderConfigure;
            return this;
        }

        public RegularizationRule Build()
        {
            return new RegularizationRule
            {
                ReglementaireId = _reglementaireId,
                InputAccounts = _inputAccounts,
                TargetAccount = _targetAccount,
                Population = _populationBuilderConfigure(Populations.PopulationBuilder.OnReglementaire(_reglementaireId)).Build()
            };
        }
    }

    public interface IPopulation
    {
        IPopulationResult Population(Func<Populations.IRoot, Populations.IBuild> populationBuilderConfigure);
    }

    public interface IPopulationResult : IBuild
    {
    }

    public interface IRoot : IComptesImpactants, ICompteCible, IPopulation
    {
    }

    public interface IComptesImpactants
    {
        IComptesImpactantsResult ComptesImpactants(params Account[] inputAccounts);
    }

    public interface IComptesImpactantsResult : ICompteCible, IPopulation
    {
    }

    public interface ICompteCible
    {
        ICompteCibleResult CompteCible(Account targetAccount);
    }

    public interface ICompteCibleResult : IPopulation
    {
    }
}
