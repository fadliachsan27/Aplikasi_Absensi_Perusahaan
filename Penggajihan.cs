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
            Keluar,
            Karyawan_Lihat,
            Karyawan_Tambah,
            Karyawan_Edit,
            Karyawan_Hapus,
            Staff_Lihat,
            Staff_Tambah,
            Staff_Edit,
            Staff_Hapus
        }

        private State currentState;
        private List<object> dataKaryawan;
        private List<object> dataStaff;

        public Penggajihan()
        {
            dataKaryawan = new KaryawanService().GetSampleKaryawan().Cast<object>().ToList();
            dataStaff = new StaffService().GetSampleStaff().Cast<object>().ToList();
            currentState = State.MenuUtama;
        }

        public void TampilkanMenuUtama()
        {
            while (currentState != State.Keluar)
            {
                Console.Clear();
                Console.WriteLine("=== MENU PENGGAJIHAN ===");
                Console.WriteLine("1. Kelola Gaji Karyawan");
                Console.WriteLine("2. Kelola Gaji Staff");
                Console.WriteLine("3. Keluar");
                Console.Write("Pilihan: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1": KelolaEntity("Karyawan"); break;
                    case "2": KelolaEntity("Staff"); break;
                    case "3": currentState = State.Keluar; break;
                    default: currentState = State.MenuUtama; break;
                }
            }
        }

        private void KelolaEntity(string tipe)
        {
            bool lanjut = true;
            while (lanjut)
            {
                Console.Clear();
                Console.WriteLine($"=== MENU {tipe.ToUpper()} ===");
                Console.WriteLine("1. Lihat Gaji");
                Console.WriteLine("2. Tambah Gaji");
                Console.WriteLine("3. Edit Gaji");
                Console.WriteLine("4. Hapus Gaji");
                Console.WriteLine("5. Kembali");
                Console.Write("Pilihan: ");
                string input = Console.ReadLine();

                var data = tipe == "Karyawan" ? dataKaryawan : dataStaff;
                string idField = tipe == "Karyawan" ? "Id_Karyawan" : "Id_Staff";
                string namaField = tipe == "Karyawan" ? "Nama_Karyawan" : "Nama_Staff";
                string gajiField = "gaji";

                switch (input)
                {
                    case "1": TampilkanData(data, idField, namaField, gajiField); break;
                    case "2": TambahGaji(data, idField, namaField, gajiField); break;
                    case "3": EditGaji(data, idField, namaField, gajiField); break;
                    case "4": HapusGaji(data, idField, namaField, gajiField); break;
                    case "5": lanjut = false; break;
                    default: break;
                }

                if (lanjut)
                {
                    Console.WriteLine("\nTekan ENTER untuk kembali...");
                    Console.ReadLine();
                }
            }
        }

        private void TampilkanData(List<object> data, string idField, string namaField, string gajiField)
        {
            Console.WriteLine($"=== DAFTAR GAJI ===");
            foreach (var item in data)
            {
                var type = item.GetType();
                var id = type.GetProperty(idField)?.GetValue(item);
                var nama = type.GetProperty(namaField)?.GetValue(item);
                var gaji = type.GetProperty(gajiField)?.GetValue(item);
                Console.WriteLine($"ID: {id} | Nama: {nama} | Gaji: Rp {gaji:N0}");
            }
        }

        private void TambahGaji(List<object> data, string idField, string namaField, string gajiField)
        {
            Console.Write("Masukkan ID: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var item = data.FirstOrDefault(d => (int)d.GetType().GetProperty(idField)?.GetValue(d) == id);
                if (item != null)
                {
                    var gaji = (int)item.GetType().GetProperty(gajiField)?.GetValue(item);
                    if (gaji > 0)
                    {
                        Console.WriteLine("Gaji sudah ada. Gunakan menu Edit.");
                        return;
                    }

                    Console.Write("Masukkan Gaji: Rp ");
                    if (int.TryParse(Console.ReadLine(), out int nilai))
                    {
                        item.GetType().GetProperty(gajiField)?.SetValue(item, nilai);
                        Console.WriteLine("Gaji ditambahkan.");
                    }
                    else Console.WriteLine("Input tidak valid.");
                }
                else Console.WriteLine("Data tidak ditemukan.");
            }
            else Console.WriteLine("ID tidak valid.");
        }

        private void EditGaji(List<object> data, string idField, string namaField, string gajiField)
        {
            Console.Write("Masukkan ID: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var item = data.FirstOrDefault(d => (int)d.GetType().GetProperty(idField)?.GetValue(d) == id);
                if (item != null)
                {
                    Console.WriteLine($"Gaji Saat Ini: Rp {item.GetType().GetProperty(gajiField)?.GetValue(item):N0}");
                    Console.Write("Masukkan Gaji Baru: Rp ");
                    if (int.TryParse(Console.ReadLine(), out int nilai))
                    {
                        item.GetType().GetProperty(gajiField)?.SetValue(item, nilai);
                        Console.WriteLine("Gaji diperbarui.");
                    }
                    else Console.WriteLine("Input tidak valid.");
                }
                else Console.WriteLine("Data tidak ditemukan.");
            }
            else Console.WriteLine("ID tidak valid.");
        }

        private void HapusGaji(List<object> data, string idField, string namaField, string gajiField)
        {
            Console.Write("Masukkan ID: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var item = data.FirstOrDefault(d => (int)d.GetType().GetProperty(idField)?.GetValue(d) == id);
                if (item != null)
                {
                    var gaji = (int)item.GetType().GetProperty(gajiField)?.GetValue(item);
                    Console.WriteLine($"Gaji Saat Ini: Rp {gaji:N0}");
                    Console.Write("Yakin ingin menghapus? (y/n): ");
                    if (Console.ReadLine().ToLower() == "y")
                    {
                        item.GetType().GetProperty(gajiField)?.SetValue(item, 0);
                        Console.WriteLine("Gaji dihapus.");
                    }
                }
                else Console.WriteLine("Data tidak ditemukan.");
            }
            else Console.WriteLine("ID tidak valid.");
        }
    }
}