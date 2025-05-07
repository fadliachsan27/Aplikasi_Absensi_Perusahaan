using System.Collections.Generic;
using System.Linq;
using Aplikasi_Absensi_Perusahaan.Models;
using Aplikasi_Absensi_Perusahaan.Services;

namespace Aplikasi_Absensi_Perusahaan.Api
{
    public class LoginApiSimulator
    {
        private List<Karyawan> daftarKaryawan;

        public LoginApiSimulator()
        {
            var karyawanService = new KaryawanService();
            daftarKaryawan = karyawanService.GetSampleKaryawan();
        }

        public bool Login(string email_Karyawan, string password)
        {
            return daftarKaryawan.Any(k => k.Email_Karyawan == email_Karyawan && k.Password == password);
        }
    }
}
