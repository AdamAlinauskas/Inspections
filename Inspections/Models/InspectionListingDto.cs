using System.Collections.Generic;

namespace Inspections.Models
{
    public class InspectionListingDto
    {
        public List<InspectionDto> Inspections { get; set; }

        public InspectionListingDto()
        {
            Inspections = new List<InspectionDto>();
        }
    }

    public class InspectionDto
    {
        public string Name { get; set; }
    }
}