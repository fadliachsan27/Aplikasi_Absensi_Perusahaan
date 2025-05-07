using Aplikasi_Absensi_Perusahaan.Api;
using System;

namespace Aplikasi_Absensi_Perusahaan.Services
{
    internal class Menu
    {
        //private JobdeskApiSimulator jobdeskApi = new JobdeskApiSimulator();
        private LoginApiSimulator loginApi = new LoginApiSimulator();

        public void Mulai()
        {
            if (Login())
            {
                TampilkanMenu();
            }
            else
            {
                Console.WriteLine("Login gagal sebanyak 3 kali. Program berhenti.");
            }
        }

        private bool Login()
        {
            Console.Clear();
            Console.WriteLine("=== LOGIN SISTEM ABSENSI ===");

            int percobaan = 0;
            while (percobaan < 3)
            {
                Console.Write("Username: ");
                string username = Console.ReadLine();
                Console.Write("Password: ");
                string password = Console.ReadLine();

                if (loginApi.Login(username, password))
                {
                    Console.WriteLine("Login berhasil!\nTekan ENTER untuk lanjut...");
                    Console.ReadLine();
                    return true;
                }
                else
                {
                    Console.WriteLine("Login gagal. Username atau password salah.\n");
                    percobaan++;
                }
            }

            return false;
        }

        private void TampilkanMenu()
        {
            bool lanjut = true;
            while (lanjut)
            {
                Console.Clear();
                Console.WriteLine("=== SISTEM JOBDESK KARYAWAN ===");
                Console.WriteLine("1. Melihat Jobdesk (via API)");
                Console.WriteLine("2. Melakukan Presensi");
                Console.WriteLine("3. Mengelola Jobdesk Karyawan");
                Console.WriteLine("4. Mengelola Data Karyawan");
                Console.WriteLine("5. Keluar");
                Console.Write("Pilihan Anda: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        LihatJobdeskViaApi();
                        break;
                    case "2":
                        Console.WriteLine("Fitur presensi belum diimplementasi.");
                        break;
                    case "3":
                        Console.WriteLine("Fitur kelola jobdesk belum diimplementasi.");
                        break;
                    case "4":
                        TampilkanInnerMenu();
                        break;
                    case "5":
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

        private void LihatJobdeskViaApi()
        {
            //Console.Clear();
            //Console.WriteLine("=== DAFTAR JOBDESK (DARI API) ===");
            //var jobdesks = jobdeskApi.GetJobdesks();

            //if (jobdesks.Count == 0)
            //{
            //    Console.WriteLine("Tidak ada jobdesk tersedia.");
            //}
            //else
            //{
            //    int nomor = 1;
            //    foreach (var jobdesk in jobdesks)
            //    {
            //        Console.WriteLine($"{nomor++}. {jobdesk}");
            //    }
            //}
        }

        public void TampilkanInnerMenu()
        {
            Console.WriteLine("Fitur inner menu belum diimplementasi.");
        }
    }
}
