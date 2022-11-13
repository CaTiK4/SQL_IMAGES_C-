using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WPF_TEST_SQL_2
{
    public partial class User
    {
        public int age
        {
            get
            {
                if (birthdate != null)
                {
                    int Age = DateTime.Now.Year - birthdate.Value.Year;
                    return Age;
                }
                else
                {
                    return 0;
                }
            }

        }
        public string pass
        {
            get
            {
                char first_char = password[0];
                char lasat_char = password[password.Length - 1];
                return first_char + "****" + lasat_char;
            }
        }
        public string color
        {
            get
            {
                if (idRole == 6)
                {
                    return "lightgreen";
                }
                else
                {
                    return "lightgray";
                }
            }
        }
        public string img
        {
            get
            {
                if (image != null)
                {
                    string fullpath = System.IO.Path.GetFullPath(image);
                    return fullpath;
                }
                return "Картинки нет";
            }
        }
    }
}
