namespace Master_RS485
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.PuertoDatos = new System.IO.Ports.SerialPort(this.components);
            this.SelectPuertos = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SelectSlave = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LimpiarDatos = new System.Windows.Forms.Button();
            this.EnvioDatos = new System.Windows.Forms.TextBox();
            this.EstadoScooter = new System.Windows.Forms.Button();
            this.EntregaMoto = new System.Windows.Forms.Button();
            this.TimeOutReceiveDatas = new System.Windows.Forms.Timer(this.components);
            this.ScanNewFrame = new System.Windows.Forms.Timer(this.components);
            this.RecibeScooter = new System.Windows.Forms.Button();
            this.ReiniciarScooter = new System.Windows.Forms.Button();
            this.BanderaRecepcionScooter = new System.Windows.Forms.Button();
            this.BanderaEntregaScooter = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.ReciboDatos = new System.Windows.Forms.TextBox();
            this.ScooterDisponible = new System.Windows.Forms.PictureBox();
            this.EspacioDisponible = new System.Windows.Forms.PictureBox();
            this.ScooterConectadoAbierto = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.ScooterDesconectadoAbierto = new System.Windows.Forms.PictureBox();
            this.ScooterEntregado = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.ScooterRecibido = new System.Windows.Forms.PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScooterDisponible)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EspacioDisponible)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ScooterConectadoAbierto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ScooterDesconectadoAbierto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ScooterEntregado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ScooterRecibido)).BeginInit();
            this.SuspendLayout();
            // 
            // PuertoDatos
            // 
            this.PuertoDatos.ReadBufferSize = 50;
            this.PuertoDatos.ReadTimeout = 100;
            this.PuertoDatos.WriteBufferSize = 50;
            this.PuertoDatos.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.RecepcionDatas);
            // 
            // SelectPuertos
            // 
            this.SelectPuertos.FormattingEnabled = true;
            this.SelectPuertos.Location = new System.Drawing.Point(11, 39);
            this.SelectPuertos.Name = "SelectPuertos";
            this.SelectPuertos.Size = new System.Drawing.Size(123, 21);
            this.SelectPuertos.TabIndex = 0;
            this.SelectPuertos.SelectedIndexChanged += new System.EventHandler(this.SelectPuertos_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Seleccione puerto Serial";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(11, 68);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Abrir Puerto";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Start_Stop_DB9);
            // 
            // SelectSlave
            // 
            this.SelectSlave.FormattingEnabled = true;
            this.SelectSlave.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15"});
            this.SelectSlave.Location = new System.Drawing.Point(15, 134);
            this.SelectSlave.Name = "SelectSlave";
            this.SelectSlave.Size = new System.Drawing.Size(71, 21);
            this.SelectSlave.TabIndex = 3;
            this.SelectSlave.SelectedIndexChanged += new System.EventHandler(this.SelectSlave_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Direccion Scooter";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.LimpiarDatos);
            this.groupBox1.Controls.Add(this.ReciboDatos);
            this.groupBox1.Controls.Add(this.EnvioDatos);
            this.groupBox1.Location = new System.Drawing.Point(200, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(408, 312);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Manejo de frames";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(209, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Frame recibido";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Frames enviado";
            // 
            // LimpiarDatos
            // 
            this.LimpiarDatos.Location = new System.Drawing.Point(106, 280);
            this.LimpiarDatos.Name = "LimpiarDatos";
            this.LimpiarDatos.Size = new System.Drawing.Size(190, 23);
            this.LimpiarDatos.TabIndex = 2;
            this.LimpiarDatos.Text = "Limpiar Datos";
            this.LimpiarDatos.UseVisualStyleBackColor = true;
            this.LimpiarDatos.Click += new System.EventHandler(this.LimpiarDatos_Click);
            // 
            // EnvioDatos
            // 
            this.EnvioDatos.Location = new System.Drawing.Point(7, 45);
            this.EnvioDatos.Multiline = true;
            this.EnvioDatos.Name = "EnvioDatos";
            this.EnvioDatos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.EnvioDatos.Size = new System.Drawing.Size(190, 229);
            this.EnvioDatos.TabIndex = 0;
            // 
            // EstadoScooter
            // 
            this.EstadoScooter.Location = new System.Drawing.Point(15, 162);
            this.EstadoScooter.Name = "EstadoScooter";
            this.EstadoScooter.Size = new System.Drawing.Size(178, 23);
            this.EstadoScooter.TabIndex = 6;
            this.EstadoScooter.Text = "Estado Scooter";
            this.EstadoScooter.UseVisualStyleBackColor = true;
            this.EstadoScooter.Click += new System.EventHandler(this.button2_Click);
            // 
            // EntregaMoto
            // 
            this.EntregaMoto.Location = new System.Drawing.Point(15, 191);
            this.EntregaMoto.Name = "EntregaMoto";
            this.EntregaMoto.Size = new System.Drawing.Size(178, 23);
            this.EntregaMoto.TabIndex = 7;
            this.EntregaMoto.Text = "Entregar Scooter";
            this.EntregaMoto.UseVisualStyleBackColor = true;
            this.EntregaMoto.Click += new System.EventHandler(this.EntregaMoto_Click);
            // 
            // TimeOutReceiveDatas
            // 
            this.TimeOutReceiveDatas.Interval = 5;
            // 
            // ScanNewFrame
            // 
            this.ScanNewFrame.Tick += new System.EventHandler(this.ScanNewFrame_Tick);
            // 
            // RecibeScooter
            // 
            this.RecibeScooter.Location = new System.Drawing.Point(15, 220);
            this.RecibeScooter.Name = "RecibeScooter";
            this.RecibeScooter.Size = new System.Drawing.Size(178, 23);
            this.RecibeScooter.TabIndex = 8;
            this.RecibeScooter.Text = "Recibir Scooter";
            this.RecibeScooter.UseVisualStyleBackColor = true;
            this.RecibeScooter.Click += new System.EventHandler(this.RecibeScooter_Click);
            // 
            // ReiniciarScooter
            // 
            this.ReiniciarScooter.BackColor = System.Drawing.Color.Red;
            this.ReiniciarScooter.Location = new System.Drawing.Point(14, 306);
            this.ReiniciarScooter.Name = "ReiniciarScooter";
            this.ReiniciarScooter.Size = new System.Drawing.Size(178, 23);
            this.ReiniciarScooter.TabIndex = 9;
            this.ReiniciarScooter.Text = "Reiniciar Scooter";
            this.ReiniciarScooter.UseVisualStyleBackColor = false;
            // 
            // BanderaRecepcionScooter
            // 
            this.BanderaRecepcionScooter.Location = new System.Drawing.Point(15, 249);
            this.BanderaRecepcionScooter.Name = "BanderaRecepcionScooter";
            this.BanderaRecepcionScooter.Size = new System.Drawing.Size(178, 23);
            this.BanderaRecepcionScooter.TabIndex = 10;
            this.BanderaRecepcionScooter.Text = "Bandera Recepcion Scooter";
            this.BanderaRecepcionScooter.UseVisualStyleBackColor = true;
            this.BanderaRecepcionScooter.Click += new System.EventHandler(this.BanderaRecepcionScooter_Click);
            // 
            // BanderaEntregaScooter
            // 
            this.BanderaEntregaScooter.Location = new System.Drawing.Point(15, 278);
            this.BanderaEntregaScooter.Name = "BanderaEntregaScooter";
            this.BanderaEntregaScooter.Size = new System.Drawing.Size(178, 23);
            this.BanderaEntregaScooter.TabIndex = 11;
            this.BanderaEntregaScooter.Text = "Bandera Entrega Scooter";
            this.BanderaEntregaScooter.UseVisualStyleBackColor = true;
            this.BanderaEntregaScooter.Click += new System.EventHandler(this.BanderaEntregaScooter_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(633, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Situacion de Scooter";
            // 
            // ReciboDatos
            // 
            this.ReciboDatos.Location = new System.Drawing.Point(212, 45);
            this.ReciboDatos.Multiline = true;
            this.ReciboDatos.Name = "ReciboDatos";
            this.ReciboDatos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ReciboDatos.Size = new System.Drawing.Size(190, 229);
            this.ReciboDatos.TabIndex = 1;
            // 
            // ScooterDisponible
            // 
            this.ScooterDisponible.Image = global::Master_RS485.Properties.Resources.Black_Test_Button;
            this.ScooterDisponible.Location = new System.Drawing.Point(636, 45);
            this.ScooterDisponible.Name = "ScooterDisponible";
            this.ScooterDisponible.Size = new System.Drawing.Size(30, 30);
            this.ScooterDisponible.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ScooterDisponible.TabIndex = 13;
            this.ScooterDisponible.TabStop = false;
            // 
            // EspacioDisponible
            // 
            this.EspacioDisponible.Image = global::Master_RS485.Properties.Resources.Black_Test_Button;
            this.EspacioDisponible.Location = new System.Drawing.Point(636, 96);
            this.EspacioDisponible.Name = "EspacioDisponible";
            this.EspacioDisponible.Size = new System.Drawing.Size(30, 30);
            this.EspacioDisponible.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.EspacioDisponible.TabIndex = 14;
            this.EspacioDisponible.TabStop = false;
            // 
            // ScooterConectadoAbierto
            // 
            this.ScooterConectadoAbierto.Image = global::Master_RS485.Properties.Resources.Black_Test_Button;
            this.ScooterConectadoAbierto.Location = new System.Drawing.Point(636, 147);
            this.ScooterConectadoAbierto.Name = "ScooterConectadoAbierto";
            this.ScooterConectadoAbierto.Size = new System.Drawing.Size(30, 30);
            this.ScooterConectadoAbierto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ScooterConectadoAbierto.TabIndex = 15;
            this.ScooterConectadoAbierto.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(681, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(193, 25);
            this.label6.TabIndex = 16;
            this.label6.Text = "Scooter Disponible";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(681, 96);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(196, 25);
            this.label7.TabIndex = 17;
            this.label7.Text = "Espacio Disponible";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(681, 147);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(296, 25);
            this.label8.TabIndex = 18;
            this.label8.Text = "Scooter Conectado &&  Abierto";
            // 
            // ScooterDesconectadoAbierto
            // 
            this.ScooterDesconectadoAbierto.Image = global::Master_RS485.Properties.Resources.Black_Test_Button;
            this.ScooterDesconectadoAbierto.Location = new System.Drawing.Point(636, 198);
            this.ScooterDesconectadoAbierto.Name = "ScooterDesconectadoAbierto";
            this.ScooterDesconectadoAbierto.Size = new System.Drawing.Size(30, 30);
            this.ScooterDesconectadoAbierto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ScooterDesconectadoAbierto.TabIndex = 19;
            this.ScooterDesconectadoAbierto.TabStop = false;
            // 
            // ScooterEntregado
            // 
            this.ScooterEntregado.Image = global::Master_RS485.Properties.Resources.Black_Test_Button;
            this.ScooterEntregado.Location = new System.Drawing.Point(636, 249);
            this.ScooterEntregado.Name = "ScooterEntregado";
            this.ScooterEntregado.Size = new System.Drawing.Size(30, 30);
            this.ScooterEntregado.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ScooterEntregado.TabIndex = 20;
            this.ScooterEntregado.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(681, 198);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(330, 25);
            this.label9.TabIndex = 21;
            this.label9.Text = "Scooter Desconectado &&  Abierto";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(681, 249);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(191, 25);
            this.label10.TabIndex = 22;
            this.label10.Text = "Scooter Entregado";
            // 
            // ScooterRecibido
            // 
            this.ScooterRecibido.Image = global::Master_RS485.Properties.Resources.Black_Test_Button;
            this.ScooterRecibido.Location = new System.Drawing.Point(636, 300);
            this.ScooterRecibido.Name = "ScooterRecibido";
            this.ScooterRecibido.Size = new System.Drawing.Size(30, 30);
            this.ScooterRecibido.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ScooterRecibido.TabIndex = 23;
            this.ScooterRecibido.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(681, 300);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(176, 25);
            this.label11.TabIndex = 24;
            this.label11.Text = "Scooter Recibido";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 347);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.ScooterRecibido);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.ScooterEntregado);
            this.Controls.Add(this.ScooterDesconectadoAbierto);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ScooterConectadoAbierto);
            this.Controls.Add(this.EspacioDisponible);
            this.Controls.Add(this.ScooterDisponible);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.BanderaEntregaScooter);
            this.Controls.Add(this.BanderaRecepcionScooter);
            this.Controls.Add(this.ReiniciarScooter);
            this.Controls.Add(this.RecibeScooter);
            this.Controls.Add(this.EntregaMoto);
            this.Controls.Add(this.EstadoScooter);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SelectSlave);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SelectPuertos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pruebas de comunicacion RS485";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScooterDisponible)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EspacioDisponible)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ScooterConectadoAbierto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ScooterDesconectadoAbierto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ScooterEntregado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ScooterRecibido)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort PuertoDatos;
        private System.Windows.Forms.ComboBox SelectPuertos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox SelectSlave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button LimpiarDatos;
        private System.Windows.Forms.TextBox EnvioDatos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button EstadoScooter;
        private System.Windows.Forms.Button EntregaMoto;
        private System.Windows.Forms.Timer TimeOutReceiveDatas;
        private System.Windows.Forms.Timer ScanNewFrame;
        private System.Windows.Forms.Button RecibeScooter;
        private System.Windows.Forms.Button ReiniciarScooter;
        private System.Windows.Forms.Button BanderaRecepcionScooter;
        private System.Windows.Forms.Button BanderaEntregaScooter;
        private System.Windows.Forms.TextBox ReciboDatos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox ScooterDisponible;
        private System.Windows.Forms.PictureBox EspacioDisponible;
        private System.Windows.Forms.PictureBox ScooterConectadoAbierto;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox ScooterDesconectadoAbierto;
        private System.Windows.Forms.PictureBox ScooterEntregado;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox ScooterRecibido;
        private System.Windows.Forms.Label label11;
    }
}

