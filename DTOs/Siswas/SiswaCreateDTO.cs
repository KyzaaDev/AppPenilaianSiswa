using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPenilaianSiswa.DTOs.Siswas
{
    internal class SiswaCreateDTO
    {
        public string Nisn { get; set; }
        public string NamaSiswa { get; set; }
        public int KelasId { get; set; } = 0;
        public string Picture { get; set; }
    }
}
