using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiometricAuthApp.Models
{
    public class FilesKey
    {
        [DisplayName("ID")] public int Id { get; set; }
        [DisplayName("Key")] public byte[] Key { get; set; }
        [DisplayName("Vi")] public byte[] Vi { get; set; }

    }
}
