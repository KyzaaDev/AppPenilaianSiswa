using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPenilaianSiswa.Models
{
    internal class Jurusan
    {
        [Key]
        public int JurusanId { get; set; }

        [Required]
        [StringLength(50)]
        public string NamaJurusan { get; set; }

        public List<Kelas> Kelas { get; set; } = new List<Kelas>();

    }
}
