using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPenilaianSiswa.Models
{
    internal class Kelas
    {
        [Key]
        public int KelasId { get; set; }

        [Required]
        public int JurusanId { get; set; }
        public Jurusan Jurusan { get; set; }

        [Required]
        [StringLength(50)]
        public string NamaKelas { get; set; }
        public List<Siswa> Siswas { get; set; } = new List<Siswa>();
    }
}
