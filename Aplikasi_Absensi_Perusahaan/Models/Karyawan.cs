using System;

namespace AljabarLibrary
{
    public class Karyawan
    {
        public string NIK { get; set; }
        public string Nama { get; set; }

        public Karyawan(string nik, string nama)
        {
            NIK = nik;
            Nama = nama;
        }

        public override string ToString()
        {
            return $"{NIK} - {Nama}";
        }
    }
}
