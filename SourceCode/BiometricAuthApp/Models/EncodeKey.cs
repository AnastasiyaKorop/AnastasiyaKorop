﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiometricAuthApp.Models
{
    public class EncodeKey
    {
        public int Id { get; set; }
        public byte[] Key { get; set; }
        public byte[] Vi { get; set; }
    }
}
