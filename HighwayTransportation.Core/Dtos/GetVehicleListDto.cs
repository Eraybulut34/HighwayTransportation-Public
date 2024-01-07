namespace HighwayTransportation.Core.Dtos
{
    public class GetVehicleListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Plate { get; set; }
        public string LicenseNumber { get; set; }
        public int ModelYear { get; set; }

    }
}