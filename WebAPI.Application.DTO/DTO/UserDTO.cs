﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Application.DTO.DTO
{
    public class UserDTO
    {
        public int? Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool isAdmin { get; set; }
        public bool Active { get; set; }
        public DateTime DateInsert { get; set; }
        public DateTime? DateUpdate { get; set; }
    }
}
