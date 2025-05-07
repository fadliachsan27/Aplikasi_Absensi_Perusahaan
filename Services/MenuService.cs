using System;
using Aplikasi_Absensi_Perusahaan.Services;

namespace Aplikasi_Absensi_Perusahaan
{
    class MenuService
    {
        private readonly KaryawanService karyawanService = new KaryawanService();
        private readonly JobdeskService jobdeskService = new JobdeskService();

        public void TampilkanMenu()
        {
            var daftarKaryawan = karyawanService.GetSampleKaryawan();
            bool lanjut = true;

            while (lanjut)
            {
                Console.Clear();
                Console.WriteLine("=== SISTEM Etos Kerja ===");
                Console.WriteLine("1. Melihat Jobdesk");
                Console.WriteLine("2. Melakukan Presensi");
                Console.WriteLine("3. Mengelola Jobdesk Karyawan");
                Console.WriteLine("4. Mengelola Data Karyawan");
                Console.WriteLine("5. Penggajihan");
                Console.WriteLine("Keluar");
                Console.Write("Pilihan Anda: ");
                string pilihan = Console.ReadLine();

                switch (pilihan)
                {
                    case "1":
                        jobdeskService.TampilkanMenuJobdesk(daftarKaryawan);
                        break;
                    case "2":
                        lanjut = false;
                        break;
                    default:
                        Console.WriteLine("Pilihan tidak valid.");
                        break;
                }

                if (lanjut)
                {
                    Console.WriteLine("\nTekan ENTER untuk kembali ke menu utama...");
                    Console.ReadLine();
                }
            }
        }
    }
}
