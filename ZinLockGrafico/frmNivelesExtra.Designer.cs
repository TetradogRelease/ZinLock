/*
 * Creado por SharpDevelop.
 * Usuario: Gabriel
 * Fecha: 30/06/2015
 * Hora: 14:49
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
namespace ZinLockGrafico
{
	partial class frmNivelesExtra
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem cargarNivelesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem crearNivelesToolStripMenuItem;
		private System.Windows.Forms.Panel pnlCrearNivel;
		private System.Windows.Forms.Label label1;
		private ZinLockGrafico.Mapa mapaBuilder;
		private System.Windows.Forms.TextBox txtNombreNivel;
		private System.Windows.Forms.Button btnGuardar;
		private ZinLockGrafico.Ficha fichaPreview;
		private ZinLockGrafico.Ficha ficha1;
		private ZinLockGrafico.Ficha ficha6;
		private ZinLockGrafico.Ficha ficha5;
		private ZinLockGrafico.Ficha ficha4;
		private ZinLockGrafico.Ficha ficha3;
		private ZinLockGrafico.Ficha ficha2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.NumericUpDown nudSegundos;
		private System.Windows.Forms.Label label2;
		
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
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.cargarNivelesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.crearNivelesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pnlCrearNivel = new System.Windows.Forms.Panel();
			this.nudSegundos = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.fichaPreview = new ZinLockGrafico.Ficha();
			this.ficha1 = new ZinLockGrafico.Ficha();
			this.ficha6 = new ZinLockGrafico.Ficha();
			this.ficha5 = new ZinLockGrafico.Ficha();
			this.ficha4 = new ZinLockGrafico.Ficha();
			this.ficha3 = new ZinLockGrafico.Ficha();
			this.ficha2 = new ZinLockGrafico.Ficha();
			this.label1 = new System.Windows.Forms.Label();
			this.mapaBuilder = new ZinLockGrafico.Mapa();
			this.txtNombreNivel = new System.Windows.Forms.TextBox();
			this.btnGuardar = new System.Windows.Forms.Button();
			this.menuStrip1.SuspendLayout();
			this.pnlCrearNivel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudSegundos)).BeginInit();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.cargarNivelesToolStripMenuItem,
			this.crearNivelesToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(471, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// cargarNivelesToolStripMenuItem
			// 
			this.cargarNivelesToolStripMenuItem.Name = "cargarNivelesToolStripMenuItem";
			this.cargarNivelesToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
			this.cargarNivelesToolStripMenuItem.Text = "Cargar Niveles";
			this.cargarNivelesToolStripMenuItem.Click += new System.EventHandler(this.CargarNivelesToolStripMenuItemClick);
			// 
			// crearNivelesToolStripMenuItem
			// 
			this.crearNivelesToolStripMenuItem.Name = "crearNivelesToolStripMenuItem";
			this.crearNivelesToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
			this.crearNivelesToolStripMenuItem.Text = "Crear Niveles";
			this.crearNivelesToolStripMenuItem.Click += new System.EventHandler(this.CrearNivelesToolStripMenuItemClick);
			// 
			// pnlCrearNivel
			// 
			this.pnlCrearNivel.Controls.Add(this.nudSegundos);
			this.pnlCrearNivel.Controls.Add(this.label2);
			this.pnlCrearNivel.Controls.Add(this.button1);
			this.pnlCrearNivel.Controls.Add(this.fichaPreview);
			this.pnlCrearNivel.Controls.Add(this.ficha1);
			this.pnlCrearNivel.Controls.Add(this.ficha6);
			this.pnlCrearNivel.Controls.Add(this.ficha5);
			this.pnlCrearNivel.Controls.Add(this.ficha4);
			this.pnlCrearNivel.Controls.Add(this.ficha3);
			this.pnlCrearNivel.Controls.Add(this.ficha2);
			this.pnlCrearNivel.Controls.Add(this.label1);
			this.pnlCrearNivel.Controls.Add(this.mapaBuilder);
			this.pnlCrearNivel.Controls.Add(this.txtNombreNivel);
			this.pnlCrearNivel.Controls.Add(this.btnGuardar);
			this.pnlCrearNivel.Location = new System.Drawing.Point(4, 28);
			this.pnlCrearNivel.Name = "pnlCrearNivel";
			this.pnlCrearNivel.Size = new System.Drawing.Size(466, 325);
			this.pnlCrearNivel.TabIndex = 1;
			// 
			// nudSegundos
			// 
			this.nudSegundos.Increment = new decimal(new int[] {
			10,
			0,
			0,
			0});
			this.nudSegundos.Location = new System.Drawing.Point(350, 64);
			this.nudSegundos.Maximum = new decimal(new int[] {
			10000,
			0,
			0,
			0});
			this.nudSegundos.Name = "nudSegundos";
			this.nudSegundos.Size = new System.Drawing.Size(98, 20);
			this.nudSegundos.TabIndex = 14;
			this.nudSegundos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nudSegundos.Value = new decimal(new int[] {
			100,
			0,
			0,
			0});
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(357, 49);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(85, 23);
			this.label2.TabIndex = 12;
			this.label2.Text = "Segundos Nivel";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(354, 289);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(20, 23);
			this.button1.TabIndex = 11;
			this.button1.Text = "P";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// fichaPreview
			// 
			this.fichaPreview.Location = new System.Drawing.Point(374, 87);
			this.fichaPreview.Name = "fichaPreview";
			this.fichaPreview.Numero = 6;
			this.fichaPreview.Size = new System.Drawing.Size(59, 59);
			this.fichaPreview.TabIndex = 10;
			// 
			// ficha1
			// 
			this.ficha1.Location = new System.Drawing.Point(413, 241);
			this.ficha1.Name = "ficha1";
			this.ficha1.Numero = 1;
			this.ficha1.Size = new System.Drawing.Size(42, 42);
			this.ficha1.TabIndex = 9;
			this.ficha1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FichaMouseClick);
			// 
			// ficha6
			// 
			this.ficha6.Location = new System.Drawing.Point(357, 241);
			this.ficha6.Name = "ficha6";
			this.ficha6.Numero = 6;
			this.ficha6.Size = new System.Drawing.Size(42, 42);
			this.ficha6.TabIndex = 8;
			this.ficha6.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FichaMouseClick);
			// 
			// ficha5
			// 
			this.ficha5.Location = new System.Drawing.Point(413, 193);
			this.ficha5.Name = "ficha5";
			this.ficha5.Numero = 5;
			this.ficha5.Size = new System.Drawing.Size(42, 42);
			this.ficha5.TabIndex = 7;
			this.ficha5.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FichaMouseClick);
			// 
			// ficha4
			// 
			this.ficha4.Location = new System.Drawing.Point(357, 193);
			this.ficha4.Name = "ficha4";
			this.ficha4.Numero = 4;
			this.ficha4.Size = new System.Drawing.Size(42, 42);
			this.ficha4.TabIndex = 6;
			this.ficha4.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FichaMouseClick);
			// 
			// ficha3
			// 
			this.ficha3.Location = new System.Drawing.Point(413, 145);
			this.ficha3.Name = "ficha3";
			this.ficha3.Numero = 3;
			this.ficha3.Size = new System.Drawing.Size(42, 42);
			this.ficha3.TabIndex = 5;
			this.ficha3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FichaMouseClick);
			// 
			// ficha2
			// 
			this.ficha2.Location = new System.Drawing.Point(357, 145);
			this.ficha2.Name = "ficha2";
			this.ficha2.Numero = 2;
			this.ficha2.Size = new System.Drawing.Size(42, 42);
			this.ficha2.TabIndex = 4;
			this.ficha2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FichaMouseClick);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(357, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 3;
			this.label1.Text = "Nombre Nivel";
			// 
			// mapaBuilder
			// 
			this.mapaBuilder.BackColor = System.Drawing.Color.White;
			this.mapaBuilder.Bloqueado = false;
			this.mapaBuilder.EsMapaDeSolucion = true;
			this.mapaBuilder.Location = new System.Drawing.Point(17, 9);
			this.mapaBuilder.MostrarFichas = true;
			this.mapaBuilder.Name = "mapaBuilder";
			this.mapaBuilder.PosicionFichaAMover = new System.Drawing.Point(0, 0);
			this.mapaBuilder.PosicionFinMovimiento = new System.Drawing.Point(0, 0);
			this.mapaBuilder.Size = new System.Drawing.Size(303, 303);
			this.mapaBuilder.TabIndex = 2;
			this.mapaBuilder.ValorSuelo = 1;
			// 
			// txtNombreNivel
			// 
			this.txtNombreNivel.Location = new System.Drawing.Point(350, 26);
			this.txtNombreNivel.Name = "txtNombreNivel";
			this.txtNombreNivel.Size = new System.Drawing.Size(98, 20);
			this.txtNombreNivel.TabIndex = 1;
			// 
			// btnGuardar
			// 
			this.btnGuardar.Location = new System.Drawing.Point(380, 289);
			this.btnGuardar.Name = "btnGuardar";
			this.btnGuardar.Size = new System.Drawing.Size(75, 23);
			this.btnGuardar.TabIndex = 0;
			this.btnGuardar.Text = "Guardar";
			this.btnGuardar.UseVisualStyleBackColor = true;
			this.btnGuardar.Click += new System.EventHandler(this.BtnGuardarClick);
			// 
			// frmNivelesExtra
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(471, 358);
			this.Controls.Add(this.pnlCrearNivel);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.Name = "frmNivelesExtra";
			this.Text = "Niveles Extra";
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FrmNivelesExtraDragDrop);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.pnlCrearNivel.ResumeLayout(false);
			this.pnlCrearNivel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudSegundos)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
