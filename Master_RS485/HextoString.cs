using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Master_RS485
{
    class HextoString
    {
        //private const char[] HEX_CHARS = "0123456789abcdef".ToCharArray();    
    
        private char[] HEX_CHARS = {'0','1','2','3','4','5','6','7','8','9','A','B','C','D','E','F'};
        public HextoString()
        {

        }

        public String Byte_To_String_Hex(byte Mybyte) {
            char[] hexChars = new char[2];

                int v = Mybyte & 0xFF;
                hexChars[0] = HEX_CHARS[(v>>4)];
                hexChars[1] = HEX_CHARS[v & 0x0F];
           
            return new String(hexChars);
        }
        
        public String ArrayByte_To_String_Hex(byte[] bytes) {
            char[] hexChars = new char[bytes.Length * 2];

            for ( int j = 0; j < bytes.Length; j++ ) {
                int v = bytes[j] & 0xFF;
                hexChars[j * 2] = HEX_CHARS[v >> 4];
                hexChars[j * 2 + 1] = HEX_CHARS[v & 0x0F];
            }
            return new String(hexChars);
        }
 
    }
}
