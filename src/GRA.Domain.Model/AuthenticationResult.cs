﻿using System.Collections.Generic;

namespace GRA.Domain.Model
{
    public class AuthenticationResult
    {
        public bool FoundUser { get; set; }
        public bool PasswordIsValid { get; set; }
        public string Message { get; set; }
        public string[] Arguments { get; set; }
        public User User { get; set; }
        public IEnumerable<string> PermissionNames { get; set; }
    }
}
