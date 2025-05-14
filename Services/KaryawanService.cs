using Aplikasi_Absensi_Perusahaan.Models;
using System.Collections.Generic;

namespace Aplikasi_Absensi_Perusahaan.Services
{
    public class KaryawanService
    {
        private List<Karyawan> _karyawanList;

        public KaryawanService()
        {
            _karyawanList = new List<Karyawan>
            {
                new Karyawan(1, "Ahmad Prasetyo", "ahmad@email.com", "081234567890", 1, 1, 0),
                new Karyawan(2, "Budi Santoso", "budi@email.com", "081234567891", 1, 1, 0),
                new Karyawan(3, "Citra Lestari", "citra@email.com", "081234567892", 1, 1, 0),
                new Karyawan(4, "Dewi Kartika", "dewi@email.com", "081234567893", 1, 1, 0),
                new Karyawan(5, "Eko Nugroho", "eko@email.com", "081234567894", 1, 1, 0),
            };
        }

        public List<Karyawan> GetSampleKaryawan()
        {
            return _karyawanList;
        }
    }
}
