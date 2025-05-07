using System;

namespace Aplikasi_Absensi_Perusahaan.Models
{
    public class Karyawan
    {
        public string NIK { get; set; }
        public string Nama { get; set; }
        public Role Role { get; set; }

        // Updated constructor to accept 3 arguments
        public Karyawan(string nik, string nama, Role role)
        {
            NIK = nik;
            Nama = nama;
            Role = role;
        }

        public override string ToString()
        {
            return $"{Nama} ({NIK}) - {Role}";
        }
    }
}
