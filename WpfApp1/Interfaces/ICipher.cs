using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Interfaces.Ciphers
{
    interface ICipher
    {
        string Encrypt(string text, string alphabet);
        string Decrypt(string text, string alphabet);
    }
}
