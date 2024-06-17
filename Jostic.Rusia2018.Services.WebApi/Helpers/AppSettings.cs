namespace Jostic.Rusia2018.Services.WebApi.Helpers
{
    public class AppSettings
    {
        public string OriginCors { get; set; } = string.Empty;
        public string Secret { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public string ExpiredTimeToken { get; set; } = string.Empty;
        public string ExpiredTimeRefreshToken { get; set;} = string.Empty;
    }
}
