﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leadership.Domain.Models.Dto
{
    public class AuthResponseDto
    {
        public string Token { get; set; }           
        public DateTime ExpiresAt { get; set; }     
        public string Email { get; set; }          
        public string FullName { get; set; }
    }
}
