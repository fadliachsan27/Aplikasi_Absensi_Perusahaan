using Aplikasi_Absensi_Perusahaan.Models;
using Aplikasi_Absensi_Perusahaan.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aplikasi_Absensi_Perusahaan
{
    public class MengelolaKaryawan
    {
        private List<Karyawan> daftarKaryawan;
        private readonly KaryawanService karyawanService = new KaryawanService();

        public MengelolaKaryawan()
        {
            daftarKaryawan = karyawanService.GetSampleKaryawan();
        }

        private static readonly Dictionary<int, string> StatusMap = new Dictionary<int, string>
        {
            { 1, "Pending" },
            { 2, "Hadir" },
            { 3, "Cuti" },
            { 4, "Alpa" },
            { 5, "Sakit" }
        };

        private string GetStatusText(int status)
        {
            return StatusMap.ContainsKey(status) ? StatusMap[status] : "Tidak Diketahui";
        }

        private Dictionary<string, Action> menuActions => new Dictionary<string, Action>
        {
            { "1", TampilkanDaftarKaryawan },
            { "2", TambahKaryawan },
            { "3", EditKaryawan },
            { "4", HapusKaryawan },
            { "5", () => Environment.Exit(0) }
        };

        public void TampilkanMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== MENU MENGELOLA KARYAWAN ===");
                Console.WriteLine("1. Lihat Daftar Karyawan");
                Console.WriteLine("2. Tambah Karyawan");
                Console.WriteLine("3. Edit Karyawan");
                Console.WriteLine("4. Hapus Karyawan");
                Console.WriteLine("5. Keluar");
                Console.Write("Pilih menu: ");
                var input = Console.ReadLine();

                if (menuActions.ContainsKey(input))
                {
                    menuActions[input].Invoke();
                    Console.WriteLine("\nTekan ENTER untuk melanjutkan...");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Pilihan tidak valid!");
                    Console.ReadLine();
                }
            }
        }

        private void TampilkanDaftarKaryawan()
        {
            Console.WriteLine("\n--- Daftar Karyawan ---");
            foreach (var k in daftarKaryawan)
            {
                Console.WriteLine($"{k.Id_Karyawan}. {k.Nama_Karyawan} - {k.Email_Karyawan} - {k.Phone_Karyawan} - Status: {GetStatusText(k.Status)}");
            }
        }

        private void TambahKaryawan()
        {
            Console.WriteLine("\n--- Tambah Karyawan Baru ---");
            int id = daftarKaryawan.Any() ? daftarKaryawan.Max(k => k.Id_Karyawan) + 1 : 1;
            Console.Write("Nama: ");
            string nama = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Telepon: ");
            string telepon = Console.ReadLine();
            Console.Write("Role (angka): ");
            int role = int.Parse(Console.ReadLine());

            Console.WriteLine("Status Karyawan:");
            foreach (var pair in StatusMap)
            {
                Console.WriteLine($"{pair.Key}. {pair.Value}");
            }
            Console.Write("Pilih status (angka): ");
            int status = int.Parse(Console.ReadLine());

            var karyawanBaru = new Karyawan(id, nama, email, telepon, role, status, 0); // gaji = 0
            daftarKaryawan.Add(karyawanBaru);
            Console.WriteLine("Karyawan berhasil ditambahkan.");
        }

        private void EditKaryawan()
        {
            TampilkanDaftarKaryawan();
            Console.Write("\nMasukkan ID karyawan yang ingin diedit: ");
            int id = int.Parse(Console.ReadLine());

            var karyawan = daftarKaryawan.FirstOrDefault(k => k.Id_Karyawan == id);
            if (karyawan != null)
            {
                Console.Write("Nama Baru (kosongkan jika tidak diubah): ");
                string nama = Console.ReadLine();
                if (!string.IsNullOrEmpty(nama)) karyawan.Nama_Karyawan = nama;

                Console.Write("Email Baru: ");
                string email = Console.ReadLine();
                if (!string.IsNullOrEmpty(email)) karyawan.Email_Karyawan = email;

                Console.Write("Telepon Baru: ");
                string telepon = Console.ReadLine();
                if (!string.IsNullOrEmpty(telepon)) karyawan.Phone_Karyawan = telepon;

                Console.Write("Role Baru (angka): ");
                if (int.TryParse(Console.ReadLine(), out int role)) karyawan.Role = role;

                Console.WriteLine("Status Baru:");
                foreach (var pair in StatusMap)
                {
                    Console.WriteLine($"{pair.Key}. {pair.Value}");
                }
                Console.Write("Pilih status (angka): ");
                if (int.TryParse(Console.ReadLine(), out int status)) karyawan.Status = status;

                Console.WriteLine("Karyawan berhasil diupdate.");
            }
            else
            {
                Console.WriteLine("Karyawan tidak ditemukan.");
            }
        }

        private void HapusKaryawan()
        {
            TampilkanDaftarKaryawan();
            Console.Write("\nMasukkan ID karyawan yang ingin dihapus: ");
            int id = int.Parse(Console.ReadLine());

            var karyawan = daftarKaryawan.FirstOrDefault(k => k.Id_Karyawan == id);
            if (karyawan != null)
            {
                daftarKaryawan.Remove(karyawan);
                Console.WriteLine("Karyawan berhasil dihapus.");
            }
            else
            {
                Console.WriteLine("Karyawan tidak ditemukan.");
            }
        }
    }
}
