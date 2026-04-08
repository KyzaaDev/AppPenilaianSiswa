using AppPenilaianSiswa.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPenilaianSiswa.Data
{
    internal class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Data Source = .\\MSSQLSERVER01; Initial Catalog = AppPenilaianSiswa; User id = sa; pwd = admin1234; TrustServerCertificate = True");
        }

        public DbSet<Guru> Gurus { get; set; }
        public DbSet<Jurusan> Jurusans { get; set; }
        public DbSet<Kelas> Kelas { get; set; }
        public DbSet<Mapel> Mapels { get; set; }
        public DbSet<Nilai> Nilais { get; set; }
        public DbSet<Operator> Operators { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Siswa> Siswas { get; set; }

    }
}
