using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplikasi_Absensi_Perusahaan.Services
{
    internal class Menu
    {
        public void TampilkanMenu()
        {
            bool lanjut = true;
            while (lanjut)
            {
                Console.Clear();
                Console.WriteLine("=== SISTEM JOBDESK KARYAWAN ===");
                Console.WriteLine("1. Melihat Jobdesk");
                Console.WriteLine("2. Melakukan Presensi");
                Console.WriteLine("3. Mengelola Jobdesk Karyawan");
                Console.WriteLine("4. Mengelola Data Karyawan")
                Console.WriteLine("Keluar")
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
        public 

    }
}
