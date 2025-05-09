﻿using Aplikasi_Absensi_Perusahaan.Api;
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
        private LoginApiSimulator loginApi = new LoginApiSimulator();

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

            int percobaan = 0;
            while (percobaan < 3)
            {
                Console.Write("email: ");
                string email = Console.ReadLine();
                Console.Write("Password: ");
                string password = Console.ReadLine();

                if (loginApi.Login(email, password))
                {
                    Console.WriteLine("Login berhasil!\nTekan ENTER untuk lanjut...");
                    Console.ReadLine();
                    return true;
                }
                else
                {
                    Console.WriteLine("Login gagal. email atau password salah.\n");
                    percobaan++;
                }
            }

            return false;
        }*/

        public void TampilkanMenu()
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
                        MenuPresensi();
                        break;
                    case "3":
                        jobdeskService.TampilkanMenuJobdesk(daftarKaryawan);
                        break;
                    case "4":
                        mengelolaKaryawan.TampilkanMenukaryawan();
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

        private void MenuPresensi()
        {
            bool kembali = false;
            while (!kembali)
            {
                Console.Clear();
                Console.WriteLine("=== MENU PRESENSI ===");
                Console.WriteLine("1. Tambah Karyawan");
                Console.WriteLine("2. Check-In");
                Console.WriteLine("3. Check-Out");
                Console.WriteLine("4. Tampilkan Log");
                Console.WriteLine("5. Kembali");
                Console.Write("Pilihan Anda: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        TambahKaryawan();
                        break;
                    case "2":
                        var k1 = PilihKaryawan();
                        if (k1 != null) logManager.CheckIn(k1);
                        break;
                    case "3":
                        var k2 = PilihKaryawan();
                        if (k2 != null) logManager.CheckOut(k2);
                        break;
                    case "4":
                        logManager.ShowLogs();
                        break;
                    case "5":
                        kembali = true;
                        break;
                    default:
                        Console.WriteLine("Pilihan tidak valid.");
                        break;
                }

                if (!kembali)
                {
                    Console.WriteLine("\nTekan ENTER untuk melanjutkan...");
                    Console.ReadLine();
                }
            }
        }

        private void TambahKaryawan()
        {
            Console.Write("ID Karyawan: ");
            if (!int.TryParse(Console.ReadLine(), out int idKaryawan))
            {
                Console.WriteLine("ID tidak valid!");
                return;
            }

            Console.Write("Nama: ");
            string nama = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("No. HP: ");
            string phone = Console.ReadLine();

            Console.WriteLine("Role:");
            Console.WriteLine("1. Karyawan");
            Console.WriteLine("2. Manager");
            Console.WriteLine("3. Staff");
            Console.Write("Pilih role (1-3): ");
            if (!int.TryParse(Console.ReadLine(), out int role) || role < 1 || role > 3)
            {
                Console.WriteLine("Role tidak valid!");
                return;
            }

            int status = 1; // default aktif
            int gaji = 0; // default 0

            daftarKaryawan.Add(new Karyawan(idKaryawan, nama, email, phone, role, status, gaji));
            Console.WriteLine("Karyawan ditambahkan!");
        }


        private Karyawan? PilihKaryawan()
        {
            if (daftarKaryawan.Count == 0)
            {
                Console.WriteLine("Tidak ada karyawan terdaftar.");
                return null;
            }

            Console.WriteLine("\nDaftar Karyawan:");
            for (int i = 0; i < daftarKaryawan.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {daftarKaryawan[i]}");
            }

            Console.Write("Pilih nomor karyawan: ");
            if (int.TryParse(Console.ReadLine(), out int pilihan) && pilihan >= 1 && pilihan <= daftarKaryawan.Count)
            {
                return daftarKaryawan[pilihan - 1];
            }

            Console.WriteLine("Pilihan tidak valid.");
            return null;
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

        private void Presensi()
        {
            Console.WriteLine("Presensi dipindahkan ke menu utama opsi 2.");
        }

        private void Penggajihan()
        {
            Console.WriteLine("Fitur Penggajihan belum diimplementasikan.");
        }
    }
}