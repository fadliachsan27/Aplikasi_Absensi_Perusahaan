﻿using System;
using System.Collections.Generic;

namespace Aplikasi_Absensi_Perusahaan.Models
{
    public class Karyawan
    {
        public int Id_Karyawan { get; set; }
        public string Nama_Karyawan { get; set; }
        public string Email_Karyawan { get; set; }
        public string Phone_Karyawan { get; set; }
        public int Role { get; set; }
        public int Status { get; set; }
        public int Gaji { get; set; }
        public List<string> Jobdesks { get; set; }

        // Tambahkan properti untuk Check-in dan Check-out
        public DateTime? CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }

        public Karyawan(int id_Karyawan, string nama_Karyawan, string email_Karyawan, string phone_Karyawan, int role, int status, int gaji)
        {
            Id_Karyawan = id_Karyawan;
            Nama_Karyawan = nama_Karyawan;
            Email_Karyawan = email_Karyawan;
            Phone_Karyawan = phone_Karyawan;
            Role = role;
            Status = status;
            Gaji = gaji;
            Jobdesks = new List<string>();
            CheckInTime = null;
            CheckOutTime = null;
        }

        public override string ToString()
        {
            return $"{Nama_Karyawan} ({Id_Karyawan}) - {Role}";
        }
    }
}
