using System;
using Aplikasi_Absensi_Perusahaan.Services;

namespace Aplikasi_Absensi_Perusahaan
{
    class Program
    {
        static void Main(string[] args)
        {
            JobdeskService jobdeskService = new JobdeskService();
            jobdeskService.TampilkanMenu();
        }
    }
}
