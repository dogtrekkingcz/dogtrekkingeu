﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Entities.Dogs
{
    public sealed record GetDogRequest
    {
        public string Chip { get; set; }
    }
}
