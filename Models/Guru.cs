using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPenilaianSiswa.Models
{
    internal class Guru
    {
        [Key]
        public int GuruId { get; set; }

        [Required]
        [StringLength(50)]
        public string GuruName { get; set; }

        public List<Mapel> Mapels { get; set; } = new List<Mapel>();
    }
}
