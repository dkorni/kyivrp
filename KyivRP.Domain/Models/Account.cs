﻿using System;
using System.Collections.Generic;
using System.Text;

namespace KyivRP.Domain.Models
{
    public class Account
    {
        public Guid Id { get; set; }

        public string Username { get; set; }

        public int Group { get; set; }

        public string PasswordHash { get; set; }
    }
}