using System;
using System.Collections.Generic;
using System.Linq;
using builder.Models;

namespace builder.Builders.Regul
{
    public class RegulBuilder :
        IRoot,
        IComptesImpactants, IComptesImpactantsResult,
        ICompteCible, ICompteCibleResult,
        IPopulation, IPopulationResult,
        ISeuil, ISeuilResult,
        IPlafond, IPlafondResult,
        IParametrageConsecutivite, IParametrageConsecutiviteResult,
        IParametrageModeDeCalcul, IParametrageModeDeCalculResult,
        IBuild
    {
        private readonly int _reglementaireId;
        private IReadOnlyCollection<Account> _inputAccounts = new[] { Comptes.Maladie };
        private Account _targetAccount = Comptes.Cp2020;
        private Func<Populations.IRoot, Populations.IBuild> _populationBuilderConfigure;
        private int _seuil;
        private int _plafond;
        private bool _consecutivite;
        private ModeDeCalcul _modeDeCalcul;

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

        public ISeuilResult Seuil(int seuil)
        {
            _seuil = seuil;
            return this;
        }

        public IPlafondResult Plafond(int plafond)
        {
            _plafond = plafond;
            return this;
        }

        public IParametrageModeDeCalculResult ModeDeCalcul(ModeDeCalcul modeDeCalcul)
        {
            _modeDeCalcul = modeDeCalcul;
            return this;
        }

        public IParametrageConsecutiviteResult Consecutif()
        {
            _consecutivite = true;
            return this;
        }

        public IParametrageConsecutiviteResult NonConsecutif()
        {
            _consecutivite = false;
            return this;
        }
    }

    public interface IPopulation
    {
        IPopulationResult Population(Func<Populations.IRoot, Populations.IBuild> populationBuilderConfigure);
    }

    public interface IPopulationResult : ISeuil, IPlafond, IBuild
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

    public interface ISeuil
    {
        ISeuilResult Seuil(int seuil);
    }

    public interface IPlafond
    {
        IPlafondResult Plafond(int plafond);
    }

    public interface ISeuilResult : IParametrageConsecutivite, IPlafond
    {
    }

    public interface IPlafondResult : IParametrageConsecutivite
    {
    }

    public interface IParametrageConsecutivite
    {
        IParametrageConsecutiviteResult Consecutif();
        IParametrageConsecutiviteResult NonConsecutif();
    }

    public interface IParametrageConsecutiviteResult : IParametrageModeDeCalcul, IBuild
    {
    }

    public interface IParametrageModeDeCalcul
    {
        IParametrageModeDeCalculResult ModeDeCalcul(ModeDeCalcul modeDeCalcul);
    }

    public interface IParametrageModeDeCalculResult : IBuild
    {
    }
}
