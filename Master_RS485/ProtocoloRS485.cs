using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Master_RS485
{
    class ProtocoloRS485
    {
        public byte 	data_len;			     //Campo que indica la cantidad de bytes del campo de datos de la trama recibida.
	    public byte 	origen;                  //Campo que indica el origen de los datos
	    public byte 	destino;                 //Campo que indica la direccion de donde se estan enviando los datos
	    public byte 	command;				 //Campo que indica el codigo de comando recibido.	
	    public byte 	buffer_index;		     //indice de recepción del buffer
        public byte[] buffer = new byte[40];     //buffer para RX

        public ProtocoloRS485()
        {
            data_len = 0;
            origen = 0;
            destino = 0;
            command = 0;
            buffer_index = 0;
        }

    }
}
