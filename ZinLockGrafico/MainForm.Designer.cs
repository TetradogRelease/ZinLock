/*
 * Creado por SharpDevelop.
 * Usuario: Gabriel
 * Fecha: 27/06/2015
 * Hora: 21:39
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using Gabriel.Cat.WindowsForms;
namespace ZinLockGrafico
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label lblTiempo;
		private System.Windows.Forms.Label lblMovimientos;
		private System.Windows.Forms.Label lblVidas;
		private System.Windows.Forms.Label lblNombreApp;
		private ZinLockGrafico.Mapa mapaJugador;
		private ZinLockGrafico.Mapa mapaSolucion;
		private System.Windows.Forms.Panel pnlSoundTrack;
		private Etiqueta lblNivel;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.lblTiempo = new System.Windows.Forms.Label();
			this.lblMovimientos = new System.Windows.Forms.Label();
			this.lblVidas = new System.Windows.Forms.Label();
			this.lblNombreApp = new System.Windows.Forms.Label();
			this.mapaJugador = new ZinLockGrafico.Mapa();
			this.mapaSolucion = new ZinLockGrafico.Mapa();
			this.pnlSoundTrack = new System.Windows.Forms.Panel();
			this.lblNivel = new Gabriel.Cat.Etiqueta();
			this.SuspendLayout();
			// 
			// lblTiempo
			// 
			this.lblTiempo.Font = new System.Drawing.Font("Raavi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTiempo.ForeColor = System.Drawing.Color.DarkGray;
			this.lblTiempo.Location = new System.Drawing.Point(447, 41);
			this.lblTiempo.Name = "lblTiempo";
			this.lblTiempo.Size = new System.Drawing.Size(100, 23);
			this.lblTiempo.TabIndex = 0;
			this.lblTiempo.Text = "tiempo";
			// 
			// lblMovimientos
			// 
			this.lblMovimientos.Font = new System.Drawing.Font("Raavi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMovimientos.ForeColor = System.Drawing.Color.DarkGray;
			this.lblMovimientos.Location = new System.Drawing.Point(447, 98);
			this.lblMovimientos.Name = "lblMovimientos";
			this.lblMovimientos.Size = new System.Drawing.Size(109, 23);
			this.lblMovimientos.TabIndex = 1;
			this.lblMovimientos.Text = "movimientos 0";
			// 
			// lblVidas
			// 
			this.lblVidas.Font = new System.Drawing.Font("Raavi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblVidas.ForeColor = System.Drawing.Color.DarkGray;
			this.lblVidas.Location = new System.Drawing.Point(447, 121);
			this.lblVidas.Name = "lblVidas";
			this.lblVidas.Size = new System.Drawing.Size(100, 23);
			this.lblVidas.TabIndex = 2;
			this.lblVidas.Text = "vidas 3";
			// 
			// lblNombreApp
			// 
			this.lblNombreApp.Font = new System.Drawing.Font("Raavi", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblNombreApp.ForeColor = System.Drawing.Color.LightGray;
			this.lblNombreApp.Location = new System.Drawing.Point(440, 359);
			this.lblNombreApp.Name = "lblNombreApp";
			this.lblNombreApp.Size = new System.Drawing.Size(141, 23);
			this.lblNombreApp.TabIndex = 6;
			this.lblNombreApp.Text = "LIGHTFORCE";
			// 
			// mapaJugador
			// 
			this.mapaJugador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(154)))), ((int)(((byte)(154)))));
			this.mapaJugador.Bloqueado = false;
			this.mapaJugador.EsMapaDeSolucion = false;
			this.mapaJugador.Location = new System.Drawing.Point(12, 12);
			this.mapaJugador.MostrarFichas = true;
			this.mapaJugador.Name = "mapaJugador";
			this.mapaJugador.PosicionFichaAMover = new System.Drawing.Point(0, 0);
			this.mapaJugador.PosicionFinMovimiento = new System.Drawing.Point(0, 0);
			this.mapaJugador.Size = new System.Drawing.Size(370, 370);
			this.mapaJugador.TabIndex = 7;
			this.mapaJugador.ValorSuelo = 1;
			// 
			// mapaSolucion
			// 
			this.mapaSolucion.BackColor = System.Drawing.Color.White;
			this.mapaSolucion.Bloqueado = false;
			this.mapaSolucion.EsMapaDeSolucion = true;
			this.mapaSolucion.Location = new System.Drawing.Point(447, 176);
			this.mapaSolucion.MostrarFichas = true;
			this.mapaSolucion.Name = "mapaSolucion";
			this.mapaSolucion.PosicionFichaAMover = new System.Drawing.Point(0, 0);
			this.mapaSolucion.PosicionFinMovimiento = new System.Drawing.Point(0, 0);
			this.mapaSolucion.Size = new System.Drawing.Size(129, 129);
			this.mapaSolucion.TabIndex = 8;
			this.mapaSolucion.ValorSuelo = 1;
			this.mapaSolucion.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MapaSolucionMouseDoubleClick);
			// 
			// pnlSoundTrack
			// 
			this.pnlSoundTrack.BackgroundImage = global::ZinLockGrafico.Resource1.sound;
			this.pnlSoundTrack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.pnlSoundTrack.Location = new System.Drawing.Point(447, 21);
			this.pnlSoundTrack.Name = "pnlSoundTrack";
			this.pnlSoundTrack.Size = new System.Drawing.Size(18, 17);
			this.pnlSoundTrack.TabIndex = 9;
			this.pnlSoundTrack.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MainFormMouseClick);
			// 
			// lblNivel
			// 
			this.lblNivel.Font = new System.Drawing.Font("Raavi", 12.95405F);
			this.lblNivel.ForeColor = System.Drawing.Color.DarkGray;
			this.lblNivel.Location = new System.Drawing.Point(447, 64);
			this.lblNivel.Name = "lblNivel";
			this.lblNivel.Size = new System.Drawing.Size(120, 37);
			this.lblNivel.TabIndex = 10;
			this.lblNivel.Text = "nivel ";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(593, 411);
			this.Controls.Add(this.lblNivel);
			this.Controls.Add(this.pnlSoundTrack);
			this.Controls.Add(this.mapaSolucion);
			this.Controls.Add(this.mapaJugador);
			this.Controls.Add(this.lblNombreApp);
			this.Controls.Add(this.lblVidas);
			this.Controls.Add(this.lblMovimientos);
			this.Controls.Add(this.lblTiempo);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.Text = "ZinLock";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
			this.ResumeLayout(false);

		}
	}
}
