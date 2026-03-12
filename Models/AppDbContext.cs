using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPenilaianSiswa.Models
{
    internal class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = .\\SQLEXPRESS; Initial Catalog= AppPenilaianSiswa; User id = kyzaadev; pwd = 982003; TrustServerCertificate = true");
        }

        // public db set

        public DbSet<Nilai> Nilais { get; set; }
        public DbSet<Siswa> Siswas { get; set; }
        public DbSet<Mapel> Mapels { get; set; }
        public DbSet<Operator> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Guru> Gurus { get; set; }
        public DbSet<Kelas> Kelas { get; set; }
        public DbSet<Jurusan> Jurusans { get; set; }
    }
}
