//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace WpfApp1
//{
//    public class CaesarCipher
//    {
//        public string Crack(string x)
//        {
//            string EncryptedMessage = this.textBox_EncryptedMessage2.Text.ToUpper();
//            string CrackedMessage = String.Empty;

//            // Get the relative frequency table.
//            CharacterFrequency[] CFT =
//               CrackTheMCCUtility.GetFrequency(
//               Utilities.GetCharacterTable(listView_CharacterFrequencyTable),
//               Utilities.GetFrequencyTable(listView_CharacterFrequencyTable));

//            // sort the table
//            Utilities.Sort(CFT);

//            // Crack the Encrypted Message
//            CrackedMessage =
//               CrackTheMCC.CrackTheMessage(EncryptedMessage,
//               CFT, Convert.ToInt32(numericUpDown_KeyLength.Value));
//            textBox_OriginalMessage2.Text = CrackedMessage.ToLower();

//            // Recover the key.
//            this.textBox_ReCoveredKey.Text =
//                 CrackTheMCC.RecoverTheKey(EncryptedMessage, CrackedMessage,
//            Convert.ToInt32(numericUpDown_KeyLength.Value));
//        }
//    }
//}
