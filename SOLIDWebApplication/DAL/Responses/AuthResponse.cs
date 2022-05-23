using SOLIDWebApplication.Models;

namespace SOLIDWebApplication.DAL.Responses
{
    internal sealed class AuthResponse
    {
        public string Password { get; set; }
        public RefreshToken LatestRefreshToken { get; set; }
    }
}
