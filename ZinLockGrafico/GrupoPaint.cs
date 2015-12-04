/*
 * Creado por SharpDevelop.
 * Usuario: Gabriel
 * Fecha: 29/06/2015
 * Hora: 14:46
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ZinLockGrafico
{
	/// <summary>
	/// Description of GrupoPaint.
	/// </summary>
	public partial class GrupoPaint : UserControl
	{
		List<ControlPaint> capas;
		public GrupoPaint()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			capas = new List<ControlPaint>();
		}
		public GrupoPaint(IEnumerable<PintaEventHandler> capas)
			: this()
		{
			ControlPaint capa;
			foreach (PintaEventHandler metodo in capas) {
				capa=new ControlPaint(metodo);
				capa.Dock=DockStyle.Fill;
				capa.MouseClick+=OnClickEvent;
				this.capas.Add(capa);
				capa.BackColor=Color.Transparent;//las capas se tapan igual...
			}
			this.Controls.AddRange(this.capas.ToArray());
		}

		public ControlPaint[] Capas {
			get {
				return capas.ToArray();
			}
			set {
				capas.Clear();
				Controls.Clear();
				capas.AddRange(value);
				Controls.AddRange(value);
			}
		}
		public void Refresh(int capa)
		{
			if (capa > 0 && capa < capas.Count)
				capas[capa].Refresh();
		}
		public void RefreshAll()
		{
			for(int i=0;i<capas.Count;i++)
				capas[i].Refresh();
		}

		void OnClickEvent(object sender, MouseEventArgs e)
		{
			OnMouseClick(e);
		}
	}
}
