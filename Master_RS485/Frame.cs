using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Master_RS485
{
    class Frame
    {
        private const byte BYTE_START = 0x02;
        private const byte BYTE_STOP = 0x04;
        private const byte BUFF_SIZE_DATAS = 39;
        private const byte MASTER_ID = 0;     
   
        // comandos master to slave
        private const byte CMD_Read_Status = 0x0A;
        private const byte CMD_Deliver_scooter = 0x0B;
        private const byte CMD_Receive_scooter = 0x0C;

        private const byte CMD_Reset_modulo		= 0x0D;
        private const byte CMD_Clear_flag_Deliver	= 0x1B;
        private const byte CMD_Clear_flag_Receive	= 0x1C;

        private const byte CMD_OK	 = 0x0E;
        private const byte CMD_ERROR = 0x0F;
       

        public byte Dir_slave;

        private bool ModoMaestro; // true -- opera como maestro
                                  // false -- operac como esclavo
        public Frame()
        {            
            Dir_slave = 1;
            ModoMaestro = true;
        }

        public Frame(byte slave, bool operacion)
        {
            Dir_slave = slave;
            ModoMaestro = operacion;
        }

        public void SetSlave(byte slave)
        {
            Dir_slave = slave;
        }

        public bool Crc_Check(aux_buffer a)
        {
            bool result;
            result = true;
            byte n;	        
	        byte crc_frame;
	
	        crc_frame=0;	
	        n = 1;	        
	        while (n < (a.data_len-1))
	        {
		        crc_frame = (byte) (crc_frame ^ a.buffer[n]);
		        n++;		        
	        }
		
	        if (crc_frame == a.buffer[n])
	        {		        
                result = true;    // el frame es correcto
	        }
	        else
	        {			        
                result = false;	// Error de frame
	        }

            return result;
        }

        //
        public ProtocoloRS485 Read_Frame(aux_buffer Buffer_frame_RX)
        {
	        byte j;
            ProtocoloRS485 InfoRecepcion = new ProtocoloRS485();

	        if (Crc_Check(Buffer_frame_RX) == true)
	        {
		        if (Buffer_frame_RX.buffer[0] != BYTE_START)
		        {
			        InfoRecepcion.command = 0x00;
                    return InfoRecepcion;
		        }
		
		        if (Buffer_frame_RX.buffer[1] >  BUFF_SIZE_DATAS)
		        {
			        InfoRecepcion.command = 0x00; // se considera que la trama se recibio mal
                    return InfoRecepcion;
		        }
		        else
		        {
			        InfoRecepcion.data_len = Buffer_frame_RX.buffer[1];
		        }
		
		        InfoRecepcion.origen = Buffer_frame_RX.buffer[2];		
		        InfoRecepcion.destino = Buffer_frame_RX.buffer[3];

                if (ModoMaestro)
                {
                    // Cuando actua como maestro lo datos provienen de un esclavo
                    // y la informacion destino es dirigida a el maestro
                    if ((InfoRecepcion.origen != Dir_slave) || (InfoRecepcion.destino != MASTER_ID))
                    {
                        InfoRecepcion.command = 0x00; // se considera que la trama se recibio mal
                        return InfoRecepcion;
                    }
                }
                else
                {
                    // Cuando actua como esclavo el origen de los datos proviene de un maestro
                    // y los datos destinos es a un esclavo
                    if ((InfoRecepcion.origen != MASTER_ID) || (InfoRecepcion.destino != Dir_slave))
                    {
                        InfoRecepcion.command = 0x00; // se considera que la trama se recibio mal
                        return InfoRecepcion;
                    }
                }
		        
				
		        InfoRecepcion.command = Buffer_frame_RX.buffer[4];
		
		        if (InfoRecepcion.data_len != 0)
		        {
			        for (j = 0;j <= InfoRecepcion.data_len;j++)
			        {
				        InfoRecepcion.buffer[j] = Buffer_frame_RX.buffer[5+j];
			        }
		        }
		
	        }
	        else
	        {
		        InfoRecepcion.command = 0x00; // se considera que la trama se recibio mal
	        }

            return InfoRecepcion;
        }
        //

        //
        public aux_buffer Built_to_Frame(ProtocoloRS485 b)
        {
	        byte n,m,u;
            aux_buffer c = new aux_buffer();
	
	        c.data_len = 0x00;
	
	        c.buffer[0] = BYTE_START; 		//Byte de arranque.
	        c.buffer[1] = b.data_len;	//Longitud de datos.
	        c.buffer[2] = b.origen;
	        c.buffer[3] = b.destino;		
	        c.buffer[4] = b.command;	//Comando
	    
	        //parte de datos
	        n = 0;
	        while (n < b.data_len)
	        {
		        c.buffer[n+5] = b.buffer[n];
		        n++;
	        }
	        c.buffer[b.data_len+5] = BYTE_STOP;
	
	        //Calcula el Check_Sum
	        n = 1;
	        m = 0;
	        while (n < (b.data_len+6))
	        {
		        u=c.buffer[n];
		        m = (byte) (m ^ u);
		        n++;
	        }
	        c.buffer[b.data_len+6] = m;
	        c.data_len= (byte) (b.data_len+6);
	        c.data_len++;
	        return c;
        }
        //

        public aux_buffer SetCommandMaster(byte cmd)
        {
            aux_buffer Buffer_Enviar = new aux_buffer();
            ProtocoloRS485 InfoTransmision = new ProtocoloRS485();

            InfoTransmision.data_len = 0;
            InfoTransmision.buffer_index = 0;
            InfoTransmision.destino = Dir_slave; // envia una orden a el esclavo
            InfoTransmision.origen = MASTER_ID;  // del la direccion maestro

            switch (cmd)
            {
                case CMD_Read_Status:
                    InfoTransmision.command = CMD_Read_Status;
                    break;

                case CMD_Deliver_scooter:
                    InfoTransmision.command = CMD_Deliver_scooter;
                    break;

                case CMD_Receive_scooter:
                    InfoTransmision.command = CMD_Receive_scooter;
                    break;

                case CMD_Clear_flag_Deliver:
                    InfoTransmision.command = CMD_Clear_flag_Deliver;                
                    break;

                case CMD_Clear_flag_Receive:
                    InfoTransmision.command = CMD_Clear_flag_Receive;
                    break;

                case CMD_Reset_modulo:
                    InfoTransmision.command = CMD_Reset_modulo;
                    break;

                default:
                    InfoTransmision.command = CMD_ERROR;
                    break;
            }

            // si se generar un error, no se genera respuesta
            if (InfoTransmision.command != CMD_ERROR)
            {
                Buffer_Enviar = Built_to_Frame(InfoTransmision);                
            }

            return Buffer_Enviar;

        }

    }
}
