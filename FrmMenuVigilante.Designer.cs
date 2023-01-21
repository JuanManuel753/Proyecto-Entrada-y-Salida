namespace login_simple
{
    partial class FrmMenuVigilante
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMenuVigilante));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
			this.LblRol = new System.Windows.Forms.Label();
			this.PbxSalir = new System.Windows.Forms.PictureBox();
			this.LblUsuario = new System.Windows.Forms.Label();
			this.Dgv = new System.Windows.Forms.DataGridView();
			this.BtnControlES = new System.Windows.Forms.Button();
			this.GbMenu = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.Entrada = new System.Windows.Forms.Label();
			this.TxtEntrada = new System.Windows.Forms.TextBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.BtnRegistros = new System.Windows.Forms.Button();
			this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
			this.LblFecha = new System.Windows.Forms.Label();
			this.LblHora = new System.Windows.Forms.Label();
			this.FechaHora = new System.Windows.Forms.Timer(this.components);
			((System.ComponentModel.ISupportInitialize)(this.PbxSalir)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
			this.GbMenu.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// LblRol
			// 
			this.LblRol.AutoSize = true;
			this.LblRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LblRol.ForeColor = System.Drawing.Color.White;
			this.LblRol.Location = new System.Drawing.Point(110, 433);
			this.LblRol.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.LblRol.Name = "LblRol";
			this.LblRol.Size = new System.Drawing.Size(37, 20);
			this.LblRol.TabIndex = 20;
			this.LblRol.Text = "Rol:";
			// 
			// PbxSalir
			// 
			this.PbxSalir.Cursor = System.Windows.Forms.Cursors.Hand;
			this.PbxSalir.Image = ((System.Drawing.Image)(resources.GetObject("PbxSalir.Image")));
			this.PbxSalir.Location = new System.Drawing.Point(28, 426);
			this.PbxSalir.Margin = new System.Windows.Forms.Padding(2);
			this.PbxSalir.Name = "PbxSalir";
			this.PbxSalir.Size = new System.Drawing.Size(64, 64);
			this.PbxSalir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.PbxSalir.TabIndex = 19;
			this.PbxSalir.TabStop = false;
			this.PbxSalir.Click += new System.EventHandler(this.PbxSalir_Click);
			// 
			// LblUsuario
			// 
			this.LblUsuario.AutoSize = true;
			this.LblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LblUsuario.ForeColor = System.Drawing.Color.White;
			this.LblUsuario.Location = new System.Drawing.Point(110, 454);
			this.LblUsuario.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.LblUsuario.Name = "LblUsuario";
			this.LblUsuario.Size = new System.Drawing.Size(68, 20);
			this.LblUsuario.TabIndex = 18;
			this.LblUsuario.Text = "Usuario:";
			// 
			// Dgv
			// 
			this.Dgv.AllowUserToAddRows = false;
			this.Dgv.AllowUserToDeleteRows = false;
			dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
			dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Blue;
			dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.WindowText;
			this.Dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
			this.Dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.Dgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(170)))), ((int)(((byte)(221)))));
			dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.Dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
			this.Dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.Dgv.DefaultCellStyle = dataGridViewCellStyle8;
			this.Dgv.Location = new System.Drawing.Point(105, 64);
			this.Dgv.Margin = new System.Windows.Forms.Padding(2);
			this.Dgv.Name = "Dgv";
			this.Dgv.ReadOnly = true;
			dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.Dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
			this.Dgv.RowHeadersWidth = 51;
			dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.WindowText;
			this.Dgv.RowsDefaultCellStyle = dataGridViewCellStyle10;
			this.Dgv.RowTemplate.Height = 24;
			this.Dgv.Size = new System.Drawing.Size(643, 291);
			this.Dgv.TabIndex = 7;
			this.Dgv.Visible = false;
			// 
			// BtnControlES
			// 
			this.BtnControlES.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(145)))), ((int)(((byte)(221)))));
			this.BtnControlES.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnControlES.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(145)))), ((int)(((byte)(221)))));
			this.BtnControlES.FlatAppearance.BorderSize = 0;
			this.BtnControlES.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(85)))), ((int)(((byte)(255)))));
			this.BtnControlES.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BtnControlES.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BtnControlES.ForeColor = System.Drawing.SystemColors.WindowText;
			this.BtnControlES.Location = new System.Drawing.Point(5, 126);
			this.BtnControlES.Margin = new System.Windows.Forms.Padding(2);
			this.BtnControlES.Name = "BtnControlES";
			this.BtnControlES.Size = new System.Drawing.Size(96, 29);
			this.BtnControlES.TabIndex = 6;
			this.BtnControlES.Text = "ControlE/S";
			this.BtnControlES.UseVisualStyleBackColor = false;
			this.BtnControlES.Click += new System.EventHandler(this.BtnControlES_Click);
			// 
			// GbMenu
			// 
			this.GbMenu.Controls.Add(this.label1);
			this.GbMenu.Controls.Add(this.Dgv);
			this.GbMenu.Controls.Add(this.Entrada);
			this.GbMenu.Controls.Add(this.TxtEntrada);
			this.GbMenu.Controls.Add(this.pictureBox1);
			this.GbMenu.Controls.Add(this.BtnRegistros);
			this.GbMenu.Controls.Add(this.BtnControlES);
			this.GbMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.GbMenu.ForeColor = System.Drawing.Color.White;
			this.GbMenu.Location = new System.Drawing.Point(23, 19);
			this.GbMenu.Margin = new System.Windows.Forms.Padding(0);
			this.GbMenu.Name = "GbMenu";
			this.GbMenu.Padding = new System.Windows.Forms.Padding(0);
			this.GbMenu.Size = new System.Drawing.Size(764, 402);
			this.GbMenu.TabIndex = 17;
			this.GbMenu.TabStop = false;
			this.GbMenu.Text = "Menu";
			this.GbMenu.Enter += new System.EventHandler(this.GbMenu_Enter);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(41, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(685, 29);
			this.label1.TabIndex = 23;
			this.label1.Text = "MENU DE GESTION DE ENTRADA Y SALIDA DE BIENES";
			// 
			// Entrada
			// 
			this.Entrada.AutoSize = true;
			this.Entrada.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Entrada.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(176)))), ((int)(((byte)(242)))));
			this.Entrada.Location = new System.Drawing.Point(319, 160);
			this.Entrada.Name = "Entrada";
			this.Entrada.Size = new System.Drawing.Size(208, 20);
			this.Entrada.TabIndex = 21;
			this.Entrada.Text = "Fecha De Entrada O Salida:";
			// 
			// TxtEntrada
			// 
			this.TxtEntrada.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(41)))), ((int)(((byte)(86)))));
			this.TxtEntrada.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.TxtEntrada.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TxtEntrada.ForeColor = System.Drawing.Color.White;
			this.TxtEntrada.Location = new System.Drawing.Point(314, 196);
			this.TxtEntrada.Name = "TxtEntrada";
			this.TxtEntrada.Size = new System.Drawing.Size(225, 15);
			this.TxtEntrada.TabIndex = 17;
			this.TxtEntrada.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtEntrada_KeyPress);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(299, 182);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(250, 48);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 19;
			this.pictureBox1.TabStop = false;
			// 
			// BtnRegistros
			// 
			this.BtnRegistros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(145)))), ((int)(((byte)(221)))));
			this.BtnRegistros.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnRegistros.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(145)))), ((int)(((byte)(221)))));
			this.BtnRegistros.FlatAppearance.BorderSize = 0;
			this.BtnRegistros.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(85)))), ((int)(((byte)(255)))));
			this.BtnRegistros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BtnRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BtnRegistros.ForeColor = System.Drawing.SystemColors.WindowText;
			this.BtnRegistros.Location = new System.Drawing.Point(5, 250);
			this.BtnRegistros.Margin = new System.Windows.Forms.Padding(2);
			this.BtnRegistros.Name = "BtnRegistros";
			this.BtnRegistros.Size = new System.Drawing.Size(96, 29);
			this.BtnRegistros.TabIndex = 16;
			this.BtnRegistros.Text = "Registros";
			this.BtnRegistros.UseVisualStyleBackColor = false;
			this.BtnRegistros.Click += new System.EventHandler(this.BtnRegistros_Click);
			// 
			// bunifuElipse1
			// 
			this.bunifuElipse1.ElipseRadius = 35;
			this.bunifuElipse1.TargetControl = this;
			// 
			// LblFecha
			// 
			this.LblFecha.AutoSize = true;
			this.LblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LblFecha.ForeColor = System.Drawing.Color.White;
			this.LblFecha.Location = new System.Drawing.Point(389, 462);
			this.LblFecha.Name = "LblFecha";
			this.LblFecha.Size = new System.Drawing.Size(92, 31);
			this.LblFecha.TabIndex = 22;
			this.LblFecha.Text = "label1";
			// 
			// LblHora
			// 
			this.LblHora.AutoSize = true;
			this.LblHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LblHora.ForeColor = System.Drawing.Color.DodgerBlue;
			this.LblHora.Location = new System.Drawing.Point(617, 421);
			this.LblHora.Name = "LblHora";
			this.LblHora.Size = new System.Drawing.Size(132, 46);
			this.LblHora.TabIndex = 21;
			this.LblHora.Text = "label1";
			this.LblHora.Click += new System.EventHandler(this.LblHora_Click);
			// 
			// FechaHora
			// 
			this.FechaHora.Enabled = true;
			this.FechaHora.Tick += new System.EventHandler(this.FechaHora_Tick);
			// 
			// FrmMenuVigilante
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(25)))), ((int)(((byte)(74)))));
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.ClientSize = new System.Drawing.Size(803, 502);
			this.Controls.Add(this.LblFecha);
			this.Controls.Add(this.LblHora);
			this.Controls.Add(this.LblRol);
			this.Controls.Add(this.PbxSalir);
			this.Controls.Add(this.LblUsuario);
			this.Controls.Add(this.GbMenu);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "FrmMenuVigilante";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "FrmMenuVigilante";
			this.Activated += new System.EventHandler(this.FrmMenuVigilante_Activated);
			((System.ComponentModel.ISupportInitialize)(this.PbxSalir)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
			this.GbMenu.ResumeLayout(false);
			this.GbMenu.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LblRol;
        private System.Windows.Forms.PictureBox PbxSalir;
        private System.Windows.Forms.Label LblUsuario;
        private System.Windows.Forms.DataGridView Dgv;
        private System.Windows.Forms.Button BtnControlES;
        private System.Windows.Forms.GroupBox GbMenu;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Button BtnRegistros;
        private System.Windows.Forms.TextBox TxtEntrada;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label Entrada;
        private System.Windows.Forms.Label LblFecha;
        private System.Windows.Forms.Label LblHora;
        private System.Windows.Forms.Timer FechaHora;
        private System.Windows.Forms.Label label1;
    }
}