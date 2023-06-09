using System;
using System.Collections.Generic;
using System.Text;

namespace KyivRP.Domain.Constants
{
    public class Errors
    {
        public static readonly string UserAlreadyRegistered = nameof(UserAlreadyRegistered); 
        public static readonly string UserDoesNotExist = nameof(UserDoesNotExist); 
        public static readonly string InvalidPassword = nameof(InvalidPassword); 
    }
}
