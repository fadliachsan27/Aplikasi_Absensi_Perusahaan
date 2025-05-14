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
        private List<object> dataKaryawan;

        public Penggajihan()
        {
            dataKaryawan = new KaryawanService().GetSampleKaryawan()?.Cast<object>().ToList() ?? new List<object>();
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
                Console.WriteLine("=== MENU PENGAJIHAN KARYAWAN ===");
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
            foreach (var item in dataKaryawan)
            {
                var type = item.GetType();
                var id = type.GetProperty("Id_Karyawan")?.GetValue(item);
                var nama = type.GetProperty("Nama_Karyawan")?.GetValue(item);
                var gaji = type.GetProperty("gaji")?.GetValue(item) ?? 0;
                Console.WriteLine($"ID: {id} | Nama: {nama} | Gaji: Rp {Convert.ToInt32(gaji):N0}");
            }
        }

        private void EditGaji()
        {
            Console.Write("Masukkan ID Karyawan: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var item = dataKaryawan.FirstOrDefault(d =>
                    (int?)d.GetType().GetProperty("Id_Karyawan")?.GetValue(d) == id);

                if (item != null)
                {
                    var gajiSaatIni = Convert.ToInt32(item.GetType().GetProperty("gaji")?.GetValue(item) ?? 0);
                    Console.WriteLine($"Gaji Saat Ini: Rp {gajiSaatIni:N0}");
                    Console.Write("Masukkan Gaji Baru: Rp ");
                    if (int.TryParse(Console.ReadLine(), out int nilaiBaru))
                    {
                        item.GetType().GetProperty("gaji")?.SetValue(item, nilaiBaru);
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
                var item = dataKaryawan.FirstOrDefault(d =>
                    (int?)d.GetType().GetProperty("Id_Karyawan")?.GetValue(d) == id);

                if (item != null)
                {
                    var gajiSaatIni = Convert.ToInt32(item.GetType().GetProperty("gaji")?.GetValue(item) ?? 0);
                    Console.WriteLine($"Gaji Saat Ini: Rp {gajiSaatIni:N0}");
                    Console.Write("Yakin ingin menghapus? (y/n): ");
                    if (Console.ReadLine().ToLower() == "y")
                    {
                        item.GetType().GetProperty("gaji")?.SetValue(item, 0);
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