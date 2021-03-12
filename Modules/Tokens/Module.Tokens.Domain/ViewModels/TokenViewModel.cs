using Newtonsoft.Json;
using System;

namespace Module.Tokens.Domain
{
    public class TokenViewModel
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }
        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }
        [JsonProperty("user_id")]
        public Guid UserId { get; set; }
       // public UserInfoViewModel UserInfo { get; set; }
    }
}
