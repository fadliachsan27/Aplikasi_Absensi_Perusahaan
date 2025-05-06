using System;
using System.Collections.Generic;

namespace Aplikasi_Absensi_Perusahaan.Services
{
    public class JobdeskService
    {
        private List<string> jobdeskList = new List<string>();

        public void TampilkanMenu()
        {
            bool lanjut = true;
            while (lanjut)
            {
                Console.Clear();
                Console.WriteLine("=== SISTEM JOBDESK KARYAWAN ===");
                Console.WriteLine("1. Tambah Jobdesk");
                Console.WriteLine("2. Tampilkan Semua Jobdesk");
                Console.WriteLine("3. Hapus Jobdesk");
                Console.WriteLine("4. Keluar");
                Console.Write("Pilihan Anda: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        TambahJobdesk();
                        break;
                    case "2":
                        TampilkanJobdesk();
                        break;
                    case "3":
                        HapusJobdesk();
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
                    Console.WriteLine("\nTekan ENTER untuk kembali ke menu...");
                    Console.ReadLine();
                }
            }
        }

        public void TambahJobdesk()
        {
            Console.Write("Masukkan jobdesk baru: ");
            string jobdesk = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(jobdesk))
            {
                jobdeskList.Add(jobdesk);
                Console.WriteLine("✅ Jobdesk ditambahkan.");
            }
            else
            {
                Console.WriteLine("❌ Jobdesk tidak boleh kosong.");
            }
        }

        public void TampilkanJobdesk()
        {
            if (jobdeskList.Count == 0)
            {
                Console.WriteLine("Belum ada jobdesk.");
                return;
            }

            Console.WriteLine("Daftar Jobdesk Karyawan:");
            for (int i = 0; i < jobdeskList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {jobdeskList[i]}");
            }
        }

        public void HapusJobdesk()
        {
            TampilkanJobdesk();
            Console.Write("Masukkan nomor jobdesk yang ingin dihapus: ");
            if (int.TryParse(Console.ReadLine(), out int index))
            {
                index--;
                if (index >= 0 && index < jobdeskList.Count)
                {
                    Console.WriteLine($"Jobdesk \"{jobdeskList[index]}\" dihapus.");
                    jobdeskList.RemoveAt(index);
                }
                else
                {
                    Console.WriteLine("❌ Nomor tidak valid.");
                }
            }
            else
            {
                Console.WriteLine("❌ Input bukan angka.");
            }
        }
    }
}
