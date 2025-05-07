using System;
using System.Collections.Generic;

namespace Aplikasi_Absensi_Perusahaan.Api
{
    public class LoginApiSimulator
    {
        // Dummy data: username dan password
        private Dictionary<string, string> dummyUsers = new Dictionary<string, string>
        {
            { "admin", "admin123" },
            { "karyawan1", "password1" },
            { "karyawan2", "password2" }
        };

        // Fungsi untuk melakukan login
        public bool Login(string username, string password)
        {
            if (dummyUsers.ContainsKey(username))
            {
                return dummyUsers[username] == password;
            }
            return false;
        }
    }
}
