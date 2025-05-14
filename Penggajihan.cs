using Aplikasi_Absensi_Perusahaan.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aplikasi_Absensi_Perusahaan.Services
{
    public class Penggajihan
    {
        private enum State
        {
            MenuUtama,
            Keluar
        }

        private State currentState;
        private List<Karyawan> dataKaryawan;

        public Penggajihan(KaryawanService karyawanService)
        {
            dataKaryawan = karyawanService.GetSampleKaryawan(); // gunakan referensi
            currentState = State.MenuUtama;
        }

        public void TampilkanMenuUtama()
        {
            while (currentState != State.Keluar)
            {
                Console.Clear();
                Console.WriteLine("=== MENU PENGGAJIHAN ===");
                Console.WriteLine("1. Kelola Gaji Karyawan");
                Console.WriteLine("2. Keluar");
                Console.Write("Pilihan: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        KelolaKaryawan();
                        break;
                    case "2":
                        currentState = State.Keluar;
                        break;
                    default:
                        Console.WriteLine("Pilihan tidak valid.");
                        break;
                }
            }
        }

        private void KelolaKaryawan()
        {
            bool lanjut = true;
            while (lanjut)
            {
                Console.Clear();
                Console.WriteLine("=== MENU PENGGAJIHAN KARYAWAN ===");
                Console.WriteLine("1. Lihat Gaji");
                Console.WriteLine("2. Edit Gaji");
                Console.WriteLine("3. Hapus Gaji");
                Console.WriteLine("4. Kembali");
                Console.Write("Pilihan: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        TampilkanData();
                        break;
                    case "2":
                        EditGaji();
                        break;
                    case "3":
                        HapusGaji();
                        break;
                    case "4":
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

        private void TampilkanData()
        {
            Console.WriteLine("=== DAFTAR GAJI KARYAWAN ===");
            foreach (var k in dataKaryawan)
            {
                Console.WriteLine($"ID: {k.Id_Karyawan} | Nama: {k.Nama_Karyawan} | Gaji: Rp {k.Gaji:N0}");
            }
        }

        private void EditGaji()
        {
            Console.Write("Masukkan ID Karyawan: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var karyawan = dataKaryawan.FirstOrDefault(k => k.Id_Karyawan == id);

                if (karyawan != null)
                {
                    Console.WriteLine($"Gaji Saat Ini: Rp {karyawan.Gaji:N0}");
                    Console.Write("Masukkan Gaji Baru: Rp ");
                    if (int.TryParse(Console.ReadLine(), out int nilaiBaru))
                    {
                        karyawan.Gaji = nilaiBaru;
                        Console.WriteLine("Gaji berhasil diperbarui.");
                    }
                    else
                    {
                        Console.WriteLine("Input gaji tidak valid.");
                    }
                }
                else
                {
                    Console.WriteLine("Data tidak ditemukan.");
                }
            }
            else
            {
                Console.WriteLine("ID tidak valid.");
            }
        }

        private void HapusGaji()
        {
            Console.Write("Masukkan ID Karyawan: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var karyawan = dataKaryawan.FirstOrDefault(k => k.Id_Karyawan == id);

                if (karyawan != null)
                {
                    Console.WriteLine($"Gaji Saat Ini: Rp {karyawan.Gaji:N0}");
                    Console.Write("Yakin ingin menghapus? (y/n): ");
                    if (Console.ReadLine().ToLower() == "y")
                    {
                        karyawan.Gaji = 0;
                        Console.WriteLine("Gaji berhasil dihapus.");
                    }
                }
                else
                {
                    Console.WriteLine("Data tidak ditemukan.");
                }
            }
            else
            {
                Console.WriteLine("ID tidak valid.");
            }
        }
    }
}
