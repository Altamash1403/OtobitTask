﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace loginwebapi2.Models
{
    public class Singup
    {

        public int Id { get; set; }        public string FirstName { get; set; }        public string LastName { get; set; }        public string UserName { get; set; }        public string Email { get; set; }        public string Gender { get; set; }        public string Password { get; set; }        public int Active { get; set; }

    }
}