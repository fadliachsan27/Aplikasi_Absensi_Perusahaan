using Aplikasi_Absensi_Perusahaan.Models;
using Aplikasi_Absensi_Perusahaan.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aplikasi_Absensi_Perusahaan
{
    public class MengelolaKaryawan
    {
        private MengelolaData<Karyawan> kelolaData;
        private readonly KaryawanService karyawanService = new KaryawanService();

        private static readonly Dictionary<int, string> StatusMap = new Dictionary<int, string>
        {
            { 1, "Pending" },
            { 2, "Hadir" },
            { 3, "Cuti" },
            { 4, "Alpa" },
            { 5, "Sakit" }
        };

        public MengelolaKaryawan()
        {
            var dataAwal = karyawanService.GetSampleKaryawan();
            kelolaData = new MengelolaData<Karyawan>(dataAwal);
        }

        public void TampilkanMenukaryawan()
        {
            bool kembaliKeMenu = false;

            while (!kembaliKeMenu)
            {
                Console.Clear();
                Console.WriteLine("=== MENU MENGELOLA KARYAWAN ===");
                Console.WriteLine("1. Lihat Daftar Karyawan");
                Console.WriteLine("2. Tambah Karyawan");
                Console.WriteLine("3. Edit Karyawan");
                Console.WriteLine("4. Hapus Karyawan");
                Console.WriteLine("5. Kembali");
                Console.Write("Pilih menu: ");
                var input = Console.ReadLine();

                var menuActions = new Dictionary<string, Action>
                {
                    { "1", TampilkanDaftarKaryawan },
                    { "2", TambahKaryawan },
                    { "3", EditKaryawan },
                    { "4", HapusKaryawan },
                    { "5", () => kembaliKeMenu = true }
                };

                if (menuActions.ContainsKey(input))
                {
                    menuActions[input].Invoke();

                    if (input != "5")
                    {
                        Console.WriteLine("\nTekan ENTER untuk melanjutkan...");
                        Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("Pilihan tidak valid!");
                    Console.ReadLine();
                }
            }
        }

        private string GetStatusText(int status)
        {
            return StatusMap.ContainsKey(status) ? StatusMap[status] : "Tidak Diketahui";
        }

        private void TampilkanDaftarKaryawan()
        {
            Console.WriteLine("\n--- Daftar Karyawan (Role 1) ---");
            kelolaData.TampilkanData(k =>
            {
                if (k.Role != 2)
                {
                    Console.WriteLine($"{k.Id_Karyawan}. {k.Nama_Karyawan} - {k.Email_Karyawan} - {k.Phone_Karyawan} - Status: {GetStatusText(k.Status)}");
                }
            });
        }

        private void TambahKaryawan()
        {
            Console.WriteLine("\n--- Tambah Karyawan Baru ---");
            var semua = kelolaData.GetSemuaData();
            int id = semua.Any() ? semua.Max(k => k.Id_Karyawan) + 1 : 1;

            Console.Write("Nama: ");
            string nama = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Telepon: ");
            string telepon = Console.ReadLine();
            Console.Write("Role (angka): ");

            if (!int.TryParse(Console.ReadLine(), out int role))
            {
                Console.WriteLine("Role tidak valid. Harus berupa angka.");
                return;
            }

            if (role == 2)
            {
                Console.WriteLine("Role 2 tidak diperbolehkan. Role ini hanya untuk staff dan tidak dapat ditambahkan.");
                return;
            }

            if (role == 3)
            {
                Console.WriteLine("Role 3 tidak diperbolehkan. Role ini hanya untuk manager dan tidak dapat ditambahkan.");
                return;
            }


            var karyawanBaru = new Karyawan(id, nama, email, telepon, role, 1, 0);
            kelolaData.TambahData(karyawanBaru);
            Console.WriteLine("Karyawan berhasil ditambahkan.");
        }

        private void EditKaryawan()
        {
            TampilkanDaftarKaryawan();
            Console.Write("\nMasukkan ID karyawan yang ingin diedit: ");
            int id = int.Parse(Console.ReadLine());

            kelolaData.UpdateData(k => k.Id_Karyawan == id, karyawan =>
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
                if (int.TryParse(Console.ReadLine(), out int role))
                {
                    if (role == 2)
                    {
                        Console.WriteLine("Role 2 tidak diperbolehkan untuk diedit. Role ini hanya untuk staff.");
                    }
                    else
                    {
                        karyawan.Role = role;
                    }
                }

                Console.WriteLine("Status Baru:");
                foreach (var pair in StatusMap)
                {
                    Console.WriteLine($"{pair.Key}. {pair.Value}");
                }
                Console.Write("Pilih status (angka): ");
                if (int.TryParse(Console.ReadLine(), out int status)) karyawan.Status = status;

                Console.WriteLine("Karyawan berhasil diupdate.");
            });

            if (kelolaData.CariData(k => k.Id_Karyawan == id) == null)
            {
                Console.WriteLine("Karyawan tidak ditemukan.");
            }
        }

        private void HapusKaryawan()
        {
            TampilkanDaftarKaryawan();
            Console.Write("\nMasukkan ID karyawan yang ingin dihapus: ");
            int id = int.Parse(Console.ReadLine());

            var ditemukan = kelolaData.CariData(k => k.Id_Karyawan == id);
            if (ditemukan != null)
            {
                kelolaData.HapusData(k => k.Id_Karyawan == id);
                Console.WriteLine("Karyawan berhasil dihapus.");
            }
            else
            {
                Console.WriteLine("Karyawan tidak ditemukan.");
            }
        }
    }
}
