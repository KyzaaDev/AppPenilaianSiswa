using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPenilaianSiswa.DTOs.Siswas
{
    internal class SiswaResponseDTO
    {
        public int SiswaId { get; set; }
        public string Nisn { get; set; }
        public string NamaSiswa { get; set; }
        public string Kelas { get; set; }
        public string Jurusan { get; set; }
        public string Picture { get; set; }
    }
}
