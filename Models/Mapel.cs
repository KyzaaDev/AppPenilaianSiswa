using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPenilaianSiswa.Models
{
    internal class Mapel
    {
        [Key]
        public int MapelId { get; set; }

        [Required]
        [StringLength(50)]
        public string NamaMapel { get; set; }


        [Required]
        public int GuruId { get; set; }
        public Guru Guru { get; set; }

        public List<Nilai> Nilais { get; set; } = new List<Nilai> { };
    }
}
