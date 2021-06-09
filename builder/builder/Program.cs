using builder.Builders;
using builder.Models;
using System;

namespace builder
{
    class Program
    {
        static void Main(string[] args)
        {
            var regul =
    new RegulBuilder()
        .ComptesImpactants(Comptes.Maladie, Comptes.Teletravail)
        .CompteCible(Comptes.Cp2020)
        .CompteCible(Comptes.Cp2021)
        .CompteCible(Comptes.Rtt)
        .ComptesImpactants(Comptes.FormationInterne)
        .Build();
        }
    }
}
