namespace HighwayTransportation.Core.Dtos 
{
    public class GetVehicleDetailDto
    {
        public string? Name { get; set; }
        public string? Plate { get; set; }
        public string? LicenseNumber { get; set; }
        public int ModelYear { get; set; }
        public DateTime TraficLicenseDate { get; set; }

    }
}