using System;
using System.Collections.Generic;
using Aplikasi_Absensi_Perusahaan.Models;

namespace Aplikasi_Absensi_Perusahaan
{
    public class Presensi
    {
        private List<Karyawan> daftarKaryawan;

        public Presensi(List<Karyawan> karyawanList)
        {
            daftarKaryawan = karyawanList;
        }

        public void PilihMenuPresensi()
        {
            while (true)
            {
                Console.Clear(); // Membersihkan layar agar tidak scroll panjang
                Console.WriteLine("=== Menu Presensi ===");
                Console.WriteLine("Pilih Karyawan untuk Presensi:");
                for (int i = 0; i < daftarKaryawan.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {daftarKaryawan[i].Nama_Karyawan}");
                }
                Console.WriteLine("0. Kembali");
                Console.Write("Nomor karyawan: ");

                if (int.TryParse(Console.ReadLine(), out int karyawanIndex))
                {
                    if (karyawanIndex == 0)
                    {
                        Console.WriteLine("Keluar dari menu presensi.");
                        break;
                    }

                    karyawanIndex--;
                    if (karyawanIndex >= 0 && karyawanIndex < daftarKaryawan.Count)
                    {
                        Console.Clear();
                        Console.WriteLine($"Presensi untuk {daftarKaryawan[karyawanIndex].Nama_Karyawan}");
                        Console.WriteLine("1. Check-in");
                        Console.WriteLine("2. Check-out");
                        Console.Write("Nomor aksi: ");

                        if (int.TryParse(Console.ReadLine(), out int aksiPresensi))
                        {
                            if (aksiPresensi == 1)
                            {
                                CheckIn(karyawanIndex);
                            }
                            else if (aksiPresensi == 2)
                            {
                                CheckOut(karyawanIndex);
                            }
                            else
                            {
                                Console.WriteLine("Pilihan tidak valid.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Input tidak valid.");
                        }

                        Console.WriteLine("\nTekan ENTER untuk kembali ke menu presensi...");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Nomor karyawan tidak valid.");
                        Console.WriteLine("Tekan ENTER untuk lanjut...");
                        Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("Input tidak valid.");
                    Console.WriteLine("Tekan ENTER untuk lanjut...");
                    Console.ReadLine();
                }
            }
        }



        private void CheckIn(int karyawanIndex)
        {
            var karyawan = daftarKaryawan[karyawanIndex];
            if (karyawan.CheckInTime == null)
            {
                karyawan.CheckInTime = DateTime.Now;
                Console.WriteLine($"{karyawan.Nama_Karyawan} berhasil check-in pada {karyawan.CheckInTime.Value}");
            }
            else
            {
                Console.WriteLine($"{karyawan.Nama_Karyawan} sudah melakukan check-in sebelumnya.");
            }
        }

        private void CheckOut(int karyawanIndex)
        {
            var karyawan = daftarKaryawan[karyawanIndex];
            if (karyawan.CheckInTime == null)
            {
                Console.WriteLine($"{karyawan.Nama_Karyawan} belum melakukan check-in.");
            }
            else
            {
                karyawan.CheckOutTime = DateTime.Now;
                Console.WriteLine($"{karyawan.Nama_Karyawan} berhasil check-out pada {karyawan.CheckOutTime.Value}");
            }
        }
    }
}
