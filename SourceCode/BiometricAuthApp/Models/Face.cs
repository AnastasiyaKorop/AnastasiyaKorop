using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiometricAuthApp.Models
{
    public class Face
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] data { get; set; }
    }
}
