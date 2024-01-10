using HighwayTransportation.Domain.Enums;

namespace HighwayTransportation.Core.Dtos
{
    public class UpdateProjectDto
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

    }
}