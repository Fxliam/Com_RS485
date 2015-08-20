using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Master_RS485
{
    					
    class aux_buffer
    {
        public byte[] buffer = new byte[40];			 //buffer auxiliar
        public byte data_len;					//tamaño de datos a enviar
        public byte index;

        public aux_buffer()
        {
            data_len = 0;
            index = 0;
        }
    }
}
