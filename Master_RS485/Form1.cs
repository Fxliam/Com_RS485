using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.Diagnostics;

namespace Master_RS485
{
    public partial class Form1 : Form
    {
        // comandos master to slave
        // comandos master to slave
        // comandos master to slave
        private const byte Read_Status = 0x0A;
        private const byte Deliver_scooter = 0x0B;
        private const byte Receive_scooter = 0x0C;

        private const byte Reset_modulo = 0x0D;
        private const byte Clear_flag_Deliver = 0x1B;
        private const byte Clear_flag_Receive = 0x1C;

        private const byte CMD_OK = 0x0E;
        private const byte CMD_ERROR = 0x0F;

        private const bool Recepcion = true;
        private const bool Transmision = false;

        private bool PollingStatus = false;

        // ESTADOS DE LA POSICION
        private const byte EQUIPO_DISPONIBLE = 0;	        // 1 -> POSICION con moto
												            // 0 -> POSICION sin moto
        private const byte ESPACIO_DISPONIBLE = 1;	        // 1 -> POSICION con moto
												            // 0 -> POSICION sin moto												
        private const byte EQUIPO_CONECTADO_ABIERTO	= 2;	// 1 -> Excepcion de Equipo conectado con apertura
												            // 0 -> Excepcion no ocurrida
        private const byte EQUIPO_DESCONECTADO_ABIERTO = 3;	// 1 -> Excepcion de Equipo conectado con apertura
												            // 0 -> Excepcion no ocurrida												
        private const byte EQUIPO_ENTREGADO	= 4;	        // 1 -> Se entrego equipo, limpia bandera por software
        private const byte EQUIPO_RECIBIDO = 5;             // 1 -> Se recibio equipo, limpia bandera por software
        
        private bool FRAME_BUFFER0 = new bool();
        private Frame DatosMaestro = new Frame();

        private aux_buffer Buffer_frame_RX0 = new aux_buffer();

        private Bitmap OFF = new Bitmap(Master_RS485.Properties.Resources.Black_Test_Button);
        private Bitmap ON = new Bitmap(Master_RS485.Properties.Resources.Green_Test_Button);

        public Form1()
        {
            InitializeComponent();
            
            FRAME_BUFFER0 = false;            
            ScanNewFrame.Enabled = true;
            ScanNewFrame.Start();
            
        }

        private void Start_Stop_DB9(object sender, EventArgs e)
        {
            if (button1.Text == "Abrir Puerto")
            {
                button1.Text = "Cerrar Puerto";
                PuertoDatos.Open();
                PuertoDatos.RtsEnable = Recepcion;
            }
            else
            {
                button1.Text = "Abrir Puerto";
                PuertoDatos.Close();
                PollingStatus = false;
            }
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            SelectSlave.Text = "1";
            //inicialializa led en apagado            
            string[] ports = SerialPort.GetPortNames();            

            foreach (string port in ports)
            {
                SelectPuertos.Items.Add(port);
            }     
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (PuertoDatos.IsOpen)
            {
                PuertoDatos.Close();
            }
        }

        private void SelectPuertos_SelectedIndexChanged(object sender, EventArgs e)
        {
            PuertoDatos.PortName = SelectPuertos.SelectedItem.ToString(); 
        }

        private void LimpiarDatos_Click(object sender, EventArgs e)
        {
            EnvioDatos.Clear();
            ReciboDatos.Clear();
        }

        private void SelectSlave_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectSlave.SelectedItem.ToString() != null)
            {
                DatosMaestro.SetSlave(Convert.ToByte(SelectSlave.SelectedItem.ToString()));
            }            
        }

        private void EnvioFrame(aux_buffer a)
        {
            //PuertoDatos.RtsEnable = Transmision;
            //Thread.Sleep(3); // espera 3 milisegundos antes de enviar un frame
            PuertoDatos.Write(a.buffer, 0, a.data_len);
            //Thread.Sleep(a.data_len + 3); // espera N bytes + 3 milisegundos antes de cambiar a recepcion de datos
            //PuertoDatos.RtsEnable = Recepcion;
            //PuertoDatos.
        }

        private void button2_Click(object sender, EventArgs e)
        {   
            aux_buffer a = new aux_buffer();            
            if (PuertoDatos.IsOpen)
            {
                a = DatosMaestro.SetCommandMaster(Read_Status);
                EnvioDatos.AppendText(BitConverter.ToString(a.buffer, 0, a.data_len) + "\r\n");
                EnvioFrame(a);                  
            }
            else
            {                
                MessageBox.Show("Se necesita seleccionar y abrir un puerto");
            }

        }

        private void EntregaMoto_Click(object sender, EventArgs e)
        {
            aux_buffer a = new aux_buffer();

            if (PuertoDatos.IsOpen)
            {
                a = DatosMaestro.SetCommandMaster(Deliver_scooter);
                EnvioDatos.AppendText(BitConverter.ToString(a.buffer, 0, a.data_len) + "\r\n");
                EnvioFrame(a);
                PollingStatus = true;
            }
            else
            {
                MessageBox.Show("Se necesita seleccionar y abrir un puerto");
            }
        }

       
        private void RecepcionDatas(object sender, SerialDataReceivedEventArgs e)
        {
            
            if (PuertoDatos.IsOpen)
            {
                Thread.Sleep(20);
                Buffer_frame_RX0.data_len = (byte)PuertoDatos.BytesToRead;
                PuertoDatos.Read(Buffer_frame_RX0.buffer, 0, Buffer_frame_RX0.data_len);
                FRAME_BUFFER0 = true; 
            }
            else
            {
                FRAME_BUFFER0 = false;
            }
                                   
                                  
            
        }        

        private void ScanNewFrame_Tick(object sender, EventArgs e)
        {
            if(FRAME_BUFFER0)
            {
                ProtocoloRS485 a = new ProtocoloRS485();
                a = DatosMaestro.Read_Frame(Buffer_frame_RX0);

                switch (a.command)
                {
                    case Read_Status:
                        ReciboDatos.AppendText(BitConverter.ToString(Buffer_frame_RX0.buffer, 0, Buffer_frame_RX0.data_len) + "\r\n");
                        // falta informacion
                        // de estado de la scooter
                        if ((a.buffer[0] & (1 << EQUIPO_DISPONIBLE)) != 0)
                        {
                            ScooterDisponible.Image = ON;
                        }
                        else
                        {
                            ScooterDisponible.Image = OFF;
                        }


                        if ((a.buffer[0] & (1 << ESPACIO_DISPONIBLE)) != 0)
                        {
                            EspacioDisponible.Image = ON;
                        }
                        else
                        {
                            EspacioDisponible.Image = OFF;
                        }


                        if ((a.buffer[0] & (1 << EQUIPO_CONECTADO_ABIERTO)) != 0)
                        {
                            ScooterConectadoAbierto.Image = ON;
                        }
                        else
                        {
                            ScooterConectadoAbierto.Image = OFF;
                        }

                        if ((a.buffer[0] & (1 << EQUIPO_DESCONECTADO_ABIERTO)) != 0)
                        {
                            ScooterDesconectadoAbierto.Image = ON;
                        }
                        else
                        {
                            ScooterDesconectadoAbierto.Image = OFF;
                        }

                        if ((a.buffer[0] & (1 << EQUIPO_DESCONECTADO_ABIERTO)) != 0)
                        {
                            ScooterDesconectadoAbierto.Image = ON;
                        }
                        else
                        {
                            ScooterDesconectadoAbierto.Image = OFF;
                        }

                        if ((a.buffer[0] & (1 << EQUIPO_ENTREGADO)) != 0)
                        {
                            ScooterEntregado.Image = ON;
                            PollingStatus = false;
                        }
                        else
                        {
                            ScooterEntregado.Image = OFF;
                        }

                        if ((a.buffer[0] & (1 << EQUIPO_RECIBIDO)) != 0)
                        {
                            ScooterRecibido.Image = ON;
                            PollingStatus = false;
                        }
                        else
                        {
                            ScooterRecibido.Image = OFF;
                        }                        


                        break;                    
                    default:                        
                        break;
                }

                
                Buffer_frame_RX0.data_len = 0;
                FRAME_BUFFER0 = false;
            }

            if(PollingStatus)
            {
                aux_buffer c = new aux_buffer();
                if (PuertoDatos.IsOpen)
                {
                    c = DatosMaestro.SetCommandMaster(Read_Status);
                    EnvioDatos.AppendText(BitConverter.ToString(c.buffer, 0, c.data_len) + "\r\n");
                    EnvioFrame(c);
                }
            }
            
        }

        private void RecibeScooter_Click(object sender, EventArgs e)
        {
            aux_buffer a = new aux_buffer();

            if (PuertoDatos.IsOpen)
            {
                a = DatosMaestro.SetCommandMaster(Receive_scooter);
                EnvioDatos.AppendText(BitConverter.ToString(a.buffer, 0, a.data_len) + "\r\n");
                EnvioFrame(a);
                PollingStatus = true;
            }
            else
            {
                MessageBox.Show("Se necesita seleccionar y abrir un puerto");
            }
        }

        private void BanderaRecepcionScooter_Click(object sender, EventArgs e)
        {
            aux_buffer a = new aux_buffer();

            if (PuertoDatos.IsOpen)
            {
                a = DatosMaestro.SetCommandMaster(Clear_flag_Receive);
                EnvioDatos.AppendText(BitConverter.ToString(a.buffer, 0, a.data_len) + "\r\n");
                EnvioFrame(a);
            }
            else
            {
                MessageBox.Show("Se necesita seleccionar y abrir un puerto");
            }
        }

        private void BanderaEntregaScooter_Click(object sender, EventArgs e)
        {
            aux_buffer a = new aux_buffer();

            if (PuertoDatos.IsOpen)
            {
                a = DatosMaestro.SetCommandMaster(Clear_flag_Deliver);
                EnvioDatos.AppendText(BitConverter.ToString(a.buffer, 0, a.data_len) + "\r\n");
                EnvioFrame(a);
            }
            else
            {
                MessageBox.Show("Se necesita seleccionar y abrir un puerto");
            }
        }
    }
}
