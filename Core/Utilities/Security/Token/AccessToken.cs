﻿namespace Core.Utilities.Security.Token
{
    public class AccessToken
    {
        public string Token { get; set; }
        public DateTime Expression { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
    }
}
