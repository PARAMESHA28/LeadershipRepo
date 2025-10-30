using Leadership.Domain.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leadership.Service.ServiceImpl
{
    public class PasswordService
    {
        private readonly PasswordHasher<User> _hasher = new();

        public string HashPassword(string password)
            => _hasher.HashPassword(null, password);

        public bool VerifyPassword(string hash, string password)
            => _hasher.VerifyHashedPassword(null, hash, password) != PasswordVerificationResult.Failed;
    }
}
