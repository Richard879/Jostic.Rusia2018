namespace Jostic.Rusia2018.Application.DTO
{
    public class UserTokenDto
    {
        public string token { get; set; } = string.Empty;
        public string inactivityExpiration { get; set; } = string.Empty;
        public string refresh_token { get; set; } = string.Empty;
    }
}
