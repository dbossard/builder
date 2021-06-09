using builder.Builders.Populations;
using builder.Builders.Regul;
using builder.Models;
using System;

namespace builder
{
    class Program
    {
        static void Main(string[] args)
        {
            //var regul =
            //    new RegulBuilder()
            //        .ComptesImpactants(Comptes.Maladie, Comptes.Teletravail)
            //        .CompteCible(Comptes.Cp2020)
            //        .CompteCible(Comptes.Cp2021)
            //        .CompteCible(Comptes.Rtt)
            //        .ComptesImpactants(Comptes.FormationInterne)
            //        .Build();

            var rule = RegulBuilder.OnReglementaire(1)
                .ComptesImpactants(Comptes.Maladie, Comptes.Teletravail)
                .CompteCible(Comptes.Rtt)
                .Population(pop => pop.WithProfiles(1))
                .Build();

            //RegulBuilder.Create().Population(pop => pop.WithProfiles()).Build();

        }
    }
}
