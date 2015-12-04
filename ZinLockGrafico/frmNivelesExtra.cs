/*
 * Creado por SharpDevelop.
 * Usuario: Gabriel
 * Fecha: 30/06/2015
 * Hora: 14:49
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Gabriel.Cat;
namespace ZinLockGrafico
{
	/// <summary>
	/// Description of frmNivelesExtra.
	/// </summary>
	public partial class frmNivelesExtra : Form
	{
		Panel pnlNivelesExtra;
		public event MapaEventHandler MapaSeleccionado;
		public frmNivelesExtra()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			pnlNivelesExtra = new Panel();
			pnlNivelesExtra.Dock = DockStyle.Fill;
			Controls.Add(pnlNivelesExtra);
			mapaBuilder.PuntoClic += PonFichaEvent;
			mapaBuilder.ResetPosiciones();
			CargarNivelesToolStripMenuItemClick(null, null);
			pnlNivelesExtra.AutoScroll = true;
			BackColor = Color.White;
			pnlNivelesExtra.DragDrop += FrmNivelesExtraDragDrop;
			//pnlCrearNivel.DragDrop+=FrmNivelesExtraDragDrop;
			menuStrip1.DragDrop += FrmNivelesExtraDragDrop;
			AllowDrop = true;
			pnlNivelesExtra.AllowDrop = true;
			menuStrip1.AllowDrop = true;
			pnlNivelesExtra.DragEnter += EnableDragIco;
			DragEnter += EnableDragIco;
			
		}
		void PonFichaEvent(int x, int y)
		{
			mapaBuilder.MapaAPintar[x, y] = fichaPreview.Numero;
			mapaBuilder.Refresh();
		}

		void FichaMouseClick(object sender, MouseEventArgs e)
		{
			fichaPreview.Numero = (sender as Ficha).Numero;
		}
		void BtnGuardarClick(object sender, EventArgs e)
		{
			if (String.IsNullOrWhiteSpace(txtNombreNivel.Text))
				MessageBox.Show("Necesita un nombre para poderlo guardar");
			else {
				if (!System.IO.Directory.Exists("NivelesExtra"))
					System.IO.Directory.CreateDirectory("NivelesExtra");
				if (System.IO.File.Exists(System.IO.Directory.GetCurrentDirectory() + System.IO.Path.DirectorySeparatorChar + "NivelesExtra" + System.IO.Path.DirectorySeparatorChar + txtNombreNivel.Text + ".ZinLevel"))
					GuardarNivel();
				else {
					GuardarNivel(txtNombreNivel.Text + ".ZinLevel");
					MessageBox.Show("Nivel Guardado :D");
				}

			}

		}

		void EnableDragIco(object sender, DragEventArgs e)
		{
			string[] formats=e.Data.GetFormats();
			if (e.Data.GetDataPresent(DataFormats.FileDrop)&&formats.Contains(".ZinLevel"))
				e.Effect = DragDropEffects.Copy;
			else
				e.Effect = DragDropEffects.None;
		}
		void GuardarNivel()
		{
			SaveFileDialog saveFile = new SaveFileDialog();
			saveFile.DefaultExt = "ZinLevel";
			if (saveFile.ShowDialog() == DialogResult.OK) {
				GuardarNivel(saveFile.FileName);
				MessageBox.Show("Nivel Guardado :D");
			}
		}

		void GuardarNivel(string nombre)
		{
			System.IO.StreamWriter lvl = new System.IO.StreamWriter("NivelesExtra" + System.IO.Path.DirectorySeparatorChar + nombre, false, Encoding.UTF8);
			lvl.WriteLine(txtNombreNivel.Text);
			lvl.WriteLine(mapaBuilder.ToString());
			lvl.WriteLine(nudSegundos.Value + "");
			lvl.Close();
		
		}
		void CrearNivelesToolStripMenuItemClick(object sender, EventArgs e)
		{
			pnlCrearNivel.Visible = true;
			pnlNivelesExtra.Visible = false;
		}
		void CargarNivelesToolStripMenuItemClick(object sender, EventArgs e)
		{
			System.IO.FileInfo[] nivelesEncontrados = { };
			int amplada = 10, altura = 40;
			NivelExtra nivel;
			System.IO.StreamReader str;
			pnlCrearNivel.Visible = false;
			pnlNivelesExtra.Visible = true;
			pnlNivelesExtra.Controls.Clear();
			//cargo los niveles que encuentre
			nivelesEncontrados = new System.IO.DirectoryInfo(System.IO.Directory.GetCurrentDirectory()).GetFiles(".ZinLevel", true);
			//pongo los niveles
			for (int i = 0; i < nivelesEncontrados.Length; i++) {
				str = new System.IO.StreamReader(nivelesEncontrados[i].FullName, Encoding.UTF8);
				nivel = new NivelExtra(str.ReadLine(), str.ReadLine(), Convert.ToInt32(str.ReadLine()));
				str.Close();
				nivel.Location = new Point(amplada, altura);
				amplada += nivel.Width;
				if (amplada > Width - 40) {
					amplada = 0;
					altura += nivel.Height;
				}
				nivel.Mapa += PonMapaCargado;
				pnlNivelesExtra.Controls.Add(nivel);
			}
		}

		void PonMapaCargado(int[,] mapa, string nombre, int segundos)
		{
			if (MapaSeleccionado != null)
				MapaSeleccionado(mapa, nombre, segundos);
		}

		void Button1Click(object sender, EventArgs e)
		{
			if (MapaSeleccionado != null)
				MapaSeleccionado(mapaBuilder.MapaAPintar, txtNombreNivel.Text, Convert.ToInt32(nudSegundos.Value));
		}
		void FrmNivelesExtraDragDrop(object sender, DragEventArgs e)
		{
			//copio los archivos en la carpeta 
			object obj = e.Data.GetData(DataFormats.FileDrop);

			//vuelvo a cargar los niveles :D	     
			CargarNivelesToolStripMenuItemClick(null, null);
		}

	}
}
