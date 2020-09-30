using System;
namespace First.DTOs
{
    public class UserToken
    {
        public string Token { get; set; }
        public DateTime expired { get; set; }
    }
}
