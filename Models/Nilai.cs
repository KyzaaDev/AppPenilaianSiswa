using Azure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPenilaianSiswa.Models
{
    internal class Nilai
    {
        [Key]
        public int NilaiId { get; set; }

        [Required]
        public int SiswaId { get; set; }
        public Siswa Siswa { get; set; }

        [Required]
        public int MapelId { get; set; }
        public Mapel Mapel { get; set; }

        [Required]
        public int OperatorId { get; set; }
        public Operator Operator { get; set; }

        [Required]
        public int NilaiSiswa { get; set; }
    }
}
