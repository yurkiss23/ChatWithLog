﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Photo { get; set; }
    }
}
