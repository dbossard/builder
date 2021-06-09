using builder.Models;

namespace builder
{
    public static class Comptes
    {
        public static readonly Account Maladie = new Account { Id = 1, Name = nameof(Maladie) };
        public static readonly Account Teletravail = new Account { Id = 2, Name = nameof(Teletravail) };
        public static readonly Account Cp2020 = new Account { Id = 3, Name = nameof(Cp2020) };
        public static readonly Account Cp2021 = new Account { Id = 4, Name = nameof(Cp2021) };
        public static readonly Account Rtt = new Account { Id = 5, Name = nameof(Rtt) };
        public static readonly Account FormationInterne = new Account { Id = 6, Name = nameof(FormationInterne) };
    }
}
