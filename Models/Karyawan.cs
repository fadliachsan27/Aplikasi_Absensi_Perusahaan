using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplikasi_Absensi_Perusahaan.Models
{
    public class Karyawan
    {
        public int ID { get; set; }
        public string Nama { get; set; }
        public string Jabatan { get; set; }

        public Karyawan(int id, string nama, string jabatan)
        {
            ID = id;
            Nama = nama;
            Jabatan = jabatan;
        }
    }
}
