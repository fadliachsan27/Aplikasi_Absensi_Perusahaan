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
            TampilkanGaji,
            TambahGaji,
            EditGaji,
            HapusGaji,
            Keluar
        }

        private State currentState;
        private readonly KaryawanService karyawanService;
        private List<Karyawan> daftarKaryawan;
        private Dictionary<State, Action> stateHandlers;

        public Penggajihan()
        {
            karyawanService = new KaryawanService();
            daftarKaryawan = karyawanService.GetSampleKaryawan();
            InitStateHandlers();
            currentState = State.MenuUtama;
        }

        private void InitStateHandlers()
        {
            stateHandlers = new Dictionary<State, Action>
            {
                { State.MenuUtama, TampilkanMenuPenggajihan },
                { State.TampilkanGaji, TampilkanDataGaji },
                { State.TambahGaji, TambahGaji },
                { State.EditGaji, EditGaji },
                { State.HapusGaji, HapusGaji },
                { State.Keluar, () => Console.WriteLine("Keluar dari aplikasi...") }
            };
        }

        public void Jalankan()
        {
            while (currentState != State.Keluar)
            {
                Console.Clear();
                stateHandlers[currentState].Invoke();

                if (currentState != State.Keluar)
                {
                    Console.WriteLine("\nTekan ENTER untuk melanjutkan...");
                    Console.ReadLine();
                    currentState = State.MenuUtama;
                }
            }
        }

        public void TampilkanMenuPenggajihan()
        {
            Console.WriteLine("=== MENU PENGGAJIHAN ===");
            Console.WriteLine("1. Lihat Data Gaji");
            Console.WriteLine("2. Tambah Gaji");
            Console.WriteLine("3. Edit Gaji");
            Console.WriteLine("4. Hapus Gaji");
            Console.WriteLine("5. Keluar");
            Console.Write("Pilihan Anda: ");
            string input = Console.ReadLine();

            currentState = input switch
            {
                "1" => State.TampilkanGaji,
                "2" => State.TambahGaji,
                "3" => State.EditGaji,
                "4" => State.HapusGaji,
                "5" => State.Keluar,
                _ => State.MenuUtama
            };
        }

        private void TampilkanDataGaji()
        {
            Console.WriteLine("=== DAFTAR GAJI KARYAWAN ===");
            foreach (var k in daftarKaryawan)
            {
                Console.WriteLine($"ID: {k.Id_Karyawan} | Nama: {k.Nama_Karyawan} | Gaji: Rp {k.Gaji:N0}");
            }
        }

        private void TambahGaji()
        {
            Console.Write("Masukkan ID Karyawan: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var karyawan = daftarKaryawan.FirstOrDefault(k => k.Id_Karyawan == id);
                if (karyawan != null)
                {
                    if (karyawan.Gaji > 0)
                    {
                        Console.WriteLine("Karyawan ini sudah memiliki gaji. Gunakan menu Edit jika ingin mengubah.");
                        return;
                    }

                    Console.Write($"Masukkan gaji untuk {karyawan.Nama_Karyawan}: Rp ");
                    if (int.TryParse(Console.ReadLine(), out int gaji))
                    {
                        karyawan.Gaji = gaji;
                        Console.WriteLine("Gaji berhasil ditambahkan.");
                    }
                    else
                    {
                        Console.WriteLine("Input tidak valid.");
                    }
                }
                else
                {
                    Console.WriteLine("Karyawan tidak ditemukan.");
                }
            }
            else
            {
                Console.WriteLine("ID tidak valid.");
            }
        }

        private void EditGaji()
        {
            Console.Write("Masukkan ID Karyawan: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var karyawan = daftarKaryawan.FirstOrDefault(k => k.Id_Karyawan == id);
                if (karyawan != null)
                {
                    Console.WriteLine($"Gaji saat ini: Rp {karyawan.Gaji:N0}");
                    Console.Write("Masukkan gaji baru: Rp ");
                    if (int.TryParse(Console.ReadLine(), out int gajiBaru))
                    {
                        karyawan.Gaji = gajiBaru;
                        Console.WriteLine("Gaji berhasil diperbarui.");
                    }
                    else
                    {
                        Console.WriteLine("Input tidak valid.");
                    }
                }
                else
                {
                    Console.WriteLine("Karyawan tidak ditemukan.");
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
                var karyawan = daftarKaryawan.FirstOrDefault(k => k.Id_Karyawan == id);
                if (karyawan != null)
                {
                    Console.WriteLine($"Gaji saat ini: Rp {karyawan.Gaji:N0}");
                    Console.Write("Apakah Anda yakin ingin menghapus gaji ini? (y/n): ");
                    string konfirmasi = Console.ReadLine().ToLower();
                    if (konfirmasi == "y")
                    {
                        karyawan.Gaji = 0;
                        Console.WriteLine("Gaji berhasil dihapus.");
                    }
                    else
                    {
                        Console.WriteLine("Penghapusan dibatalkan.");
                    }
                }
                else
                {
                    Console.WriteLine("Karyawan tidak ditemukan.");
                }
            }
            else
            {
                Console.WriteLine("ID tidak valid.");
            }
        }
    }
}