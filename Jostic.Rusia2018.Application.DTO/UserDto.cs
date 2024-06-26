﻿namespace Jostic.Rusia2018.Application.DTO
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public string inactivityExpiration { get; set; } = string.Empty;
        public string refresh_token { get; set; } = string.Empty;
    }
}
