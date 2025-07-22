﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReview.Core.DTO
{
    public class AuthResponseDto
    {
        public string Id { get; set; } = null!;
        public string Token { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhotoUrl { get; set; } = null!;
    }
}
