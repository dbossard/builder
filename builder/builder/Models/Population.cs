using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace builder.Models
{
    public class Population
    {
        public IReadOnlyCollection<int> LegalEntityIds { get; set; }
        public IReadOnlyCollection<int> DepartmentIds { get; set; }
        public IReadOnlyCollection<int> ProfileIds { get; set; }

        public int ReglementaireId { get; set; }
    }
}
