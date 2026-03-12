using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPenilaianSiswa.Models
{
    internal class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public List<Operator> Users { get; set; } = new List<Operator>();
    }
}
