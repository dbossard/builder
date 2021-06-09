using builder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace builder.Builders.Populations
{
    public class PopulationBuilder : 
        IRoot,
        IWithProfiles, IWithProfilesResult,
        IBuild
    {
        private readonly int _reglementaireId;
        private IReadOnlyCollection<int> _departmentIds = Array.Empty<int>();
        private IReadOnlyCollection<int> _legalEntityIds = Array.Empty<int>();
        private IReadOnlyCollection<int> _profileIds = Array.Empty<int>();

        private PopulationBuilder(int reglementaireId)
        {
            _reglementaireId = reglementaireId;
        }

        public static IRoot OnReglementaire(int reglementaireId)
        {
            return new PopulationBuilder(reglementaireId);
        }

        public IWithProfilesResult WithProfiles(int profileId, params int[] profileIds)
        {
            _profileIds = new[] { profileId }.Concat(profileIds).ToArray();
            return this;
        }


        public Population Build()
        {
            return new Population
            {
                ReglementaireId = _reglementaireId,
                DepartmentIds = _departmentIds,
                LegalEntityIds = _legalEntityIds,
                ProfileIds = _profileIds
            };
        }
    }

    public interface IRoot : IWithProfiles
    {
    }

    public interface IBuild
    {
        Population Build();
    }

    public interface IWithProfiles
    {
        IWithProfilesResult WithProfiles(int profileId, params int[] profileIds);
    }

    public interface IWithProfilesResult: IBuild
    {
    }
}
