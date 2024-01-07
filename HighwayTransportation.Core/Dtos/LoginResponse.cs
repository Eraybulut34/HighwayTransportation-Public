namespace HighwayTransportation.Core.Dtos
{
    public class LoginResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public string Token { get; set; }
        public AppUserDto User { get; set; }
    }
}