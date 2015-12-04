/*
 * Creado por SharpDevelop.
 * Usuario: Gabriel
 * Fecha: 30/06/2015
 * Hora: 14:58
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
namespace ZinLockGrafico
{
	partial class NivelExtra
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private ZinLockGrafico.Mapa mapaExtra;
		private System.Windows.Forms.Label lblNombre;
		private System.Windows.Forms.Label lblTiempo;
		
		/// <summary>
		/// Disposes resources used by the control.
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
			this.mapaExtra = new ZinLockGrafico.Mapa();
			this.lblNombre = new System.Windows.Forms.Label();
			this.lblTiempo = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// mapaExtra
			// 
			this.mapaExtra.BackColor = System.Drawing.Color.White;
			this.mapaExtra.Bloqueado = false;
			this.mapaExtra.EsMapaDeSolucion = true;
			this.mapaExtra.Location = new System.Drawing.Point(31, 12);
			this.mapaExtra.MostrarFichas = true;
			this.mapaExtra.Name = "mapaExtra";
			this.mapaExtra.PosicionFichaAMover = new System.Drawing.Point(0, 0);
			this.mapaExtra.PosicionFinMovimiento = new System.Drawing.Point(0, 0);
			this.mapaExtra.Size = new System.Drawing.Size(150, 150);
			this.mapaExtra.TabIndex = 0;
			this.mapaExtra.ValorSuelo = 1;
			this.mapaExtra.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Mapa1MouseClick);
			// 
			// lblNombre
			// 
			this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblNombre.Location = new System.Drawing.Point(43, 165);
			this.lblNombre.Name = "lblNombre";
			this.lblNombre.Size = new System.Drawing.Size(138, 23);
			this.lblNombre.TabIndex = 1;
			this.lblNombre.Text = "   Nombre Nivel";
			this.lblNombre.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Mapa1MouseClick);
			// 
			// lblTiempo
			// 
			this.lblTiempo.Location = new System.Drawing.Point(124, 188);
			this.lblTiempo.Name = "lblTiempo";
			this.lblTiempo.Size = new System.Drawing.Size(89, 23);
			this.lblTiempo.TabIndex = 2;
			this.lblTiempo.Text = "label2";
			// 
			// NivelExtra
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.lblTiempo);
			this.Controls.Add(this.lblNombre);
			this.Controls.Add(this.mapaExtra);
			this.Name = "NivelExtra";
			this.Size = new System.Drawing.Size(216, 211);
			this.ResumeLayout(false);

		}
	}
}
