using Aplikasi_Absensi_Perusahaan.Models;
using System;
using System.Collections.Generic;
using AljabarLibrary;
using Aplikasi_Absensi_Perusahaan.Models;
using Aplikasi_Absensi_Perusahaan.Services; // atau Models, tergantung letaknya



namespace Aplikasi_Absensi_Perusahaan.Services
{
    internal class Menu
    {
        private List<Karyawan> daftarKaryawan = new();
        private LogManager<Karyawan> logManager = new();
        MengelolaKaryawan mengelolaKaryawan = new MengelolaKaryawan();
        JobdeskService jobdeskService = new JobdeskService();
        Penggajihan penggajihan = new Penggajihan();

        //private JobdeskApiSimulator jobdeskApi = new JobdeskApiSimulator();
        /*private LoginApiSimulator loginApi = new LoginApiSimulator();*/

       /* public void Mulai()
        {
            if (Login())
            {
                TampilkanMenu();
            }
            else
            {
                Console.WriteLine("Login gagal sebanyak 3 kali. Program berhenti.");
            }
        }*/

/*        private bool Login()
        {
            Console.Clear();
            Console.WriteLine("=== LOGIN SISTEM ABSENSI ===");

        public void TampilkanMenu()
        {
            bool lanjut = true;

            var kelola = new MengelolaKaryawan<Karyawan>();

            while (lanjut)
            {
                Console.Clear();
                Console.WriteLine("=== SISTEM JOBDESK KARYAWAN ===");
                Console.WriteLine("1. Melihat Jobdesk (via API)");
                Console.WriteLine("2. Melakukan Presensi");
                Console.WriteLine("3. Mengelola Jobdesk Karyawan");
                Console.WriteLine("4. Mengelola Data Karyawan");
                Console.WriteLine("5. Mengelola Penggajihan");
                Console.WriteLine("6. Keluar");
                Console.Write("Pilihan Anda: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        //LihatJobdeskViaApi();
                        break;
                    case "2":
                        KaryawanService service = new KaryawanService();
                        daftarKaryawan = service.GetSampleKaryawan();
                        Presensi presensi = new Presensi(daftarKaryawan);
                        presensi.PilihMenuPresensi();
                        break;
                    case "3":
                        jobdeskService.TampilkanMenuJobdesk(daftarKaryawan);
                        break;
                    case "4":
                        kelola.TampilkanMenukaryawan();
                        break;
                    case "5":
                        penggajihan.TampilkanMenuPenggajihan();
                        break;
                    case "6":
                        lanjut = false;
                        break;
                    default:
                        Console.WriteLine("Pilihan tidak valid.");
                        break;
                }

                if (lanjut)
                {
                    Console.WriteLine("\nTekan ENTER untuk kembali ke menu...");
                    Console.ReadLine();
                }
            }
        }

        public void TampilkanInnerMenu()
        {
            bool lanjut = true;
            while (lanjut)
            {
                Console.Clear();
                Console.WriteLine("=== MENU DATA TAMBAHAN ===");
                Console.WriteLine("1. Mengelola Presensi (alias tidak dipakai lagi)");
                Console.WriteLine("2. Mengelola Penggajihan");
                Console.WriteLine("3. Kembali");
                Console.Write("Pilihan Anda: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.WriteLine("Fitur sudah dipindahkan ke menu utama.");
                        break;
                    case "2":
                        Penggajihan();
                        break;
                    case "3":
                        lanjut = false;
                        break;
                    default:
                        Console.WriteLine("Pilihan tidak valid.");
                        break;
                }

                if (lanjut)
                {
                    Console.WriteLine("\nTekan ENTER untuk kembali...");
                    Console.ReadLine();
                }
            }
        }

        // Dummy methods placeholder
        private void TambahJobdesk()
        {
            Console.WriteLine("Fitur Tambah Jobdesk belum diimplementasikan.");
        }

        private void TampilkanJobdesk()
        {
            Console.WriteLine("Fitur Tampilkan Jobdesk belum diimplementasikan.");
        }

        private void HapusJobdesk()
        {
            Console.WriteLine("Fitur Hapus Jobdesk belum diimplementasikan.");
        }

        private void Penggajihan()
        {
            Console.WriteLine("Fitur Penggajihan belum diimplementasikan.");
        }
    }
}