using AppPenilaianSiswa.DTOs.Jurusans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPenilaianSiswa.DTOs.Kelas
{
    internal class KelasResponseDTO
    {
        public int KelasId { get; set; }
        public string KelasName { get; set; }
        public JurusanResponseDTO Jurusan { get; set; }
    }
}
