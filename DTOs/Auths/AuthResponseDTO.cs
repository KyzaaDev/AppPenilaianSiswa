using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPenilaianSiswa.DTOs.Auths
{
    internal class AuthResponseDTO
    {
        public int OperatorId { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }
    }
}
