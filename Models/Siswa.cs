using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPenilaianSiswa.Models
{
    internal class Siswa
    {
        [Key]
        public int SiswaId { get; set; }

        [Required]
        [StringLength(10)]
        public string Nisn { get; set; }

        [Required]
        [StringLength(50)]
        public string NamaSiswa { get; set; }

        [Required]
        [StringLength(20)]
        public string Kelas { get; set; }

        [Required]
        [StringLength(50)]
        public string Jurusan { get; set; }

        [StringLength(255)]
        public string SiswaPicture { get; set; }

        public List<Nilai> Nilais { get; set; } = new List<Nilai> { };
    }
}
