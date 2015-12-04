/*
 * Creado por SharpDevelop.
 * Usuario: Gabriel
 * Fecha: 27/06/2015
 * Hora: 13:04
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;
using System.Threading;


namespace ZinLock
{
	/// <summary>
	/// Description of SonidosZinLock.
	/// </summary>
	public static class SonidosZinLock
	{
		//Initialization
		[DllImport("user32.dll")]
		private static extern bool ShowWindow(IntPtr hwnd, int nCmdShow);
		[DllImport("user32.dll")]
		private static extern bool EnableWindow(IntPtr hwnd, bool enable);
		[DllImport("user32.dll")]
		private static extern bool MoveWindow(IntPtr handle, int x, int y, int width,
			int height, bool redraw);
		public enum Sonidos
		{
			FichaSeleccionada,
			FichaMoviendose,
			WinLevel,
			TimeOut
		}
		static string tempPath = Path.GetTempPath();
		static Thread ejecutarBackGround = null;
		static bool ejecutandoSonidoBackGround = false;
		public static void Play(Sonidos sonido)
		{
			byte[] musica = Obtener(sonido.ToString());
			string pathSonido;
			//play sonido
			pathSonido = DameRutaTemporal(musica,sonido.ToString());
			System.Media.SoundPlayer player = new System.Media.SoundPlayer(pathSonido);
			player.PlaySync();
		}

		static  string DameRutaTemporal(byte[] musica,string nombre)
		{
			string name = Path.ChangeExtension(nombre, ".wav");
			string path = Path.Combine(Path.GetTempPath(), name);
			if(!File.Exists(path))
			File.WriteAllBytes(path, musica);
			return path;
		}

		static byte[] Obtener(string nombre)
		{
			
			ResourceManager resources = new ResourceManager("ZinLock.Sonidos", Assembly.GetExecutingAssembly());
			byte[] fileData = (byte[])resources.GetObject(nombre);
			return fileData;

		}
		public static void EliminaArchivosTemporales()
		{
			string[] nombres = Enum.GetNames(typeof(SonidosZinLock.Sonidos));
			for (int i = 0; i < nombres.Length; i++)
				if (File.Exists(tempPath + Path.DirectorySeparatorChar + nombres[i] + ".wma"))
					File.Delete(tempPath + Path.DirectorySeparatorChar + nombres[i] + ".wma");
			
		}
		
		public static void PlaySoundTrack()
		{
			PlaySoundTrack(ProcessWindowStyle.Minimized);
		}
		public static void PlaySoundTrack(ProcessWindowStyle windowsStyle)
		{
			//pone el sonido en el background
			if (!ejecutandoSonidoBackGround) {
				ejecutandoSonidoBackGround = true;
				ejecutarBackGround = new Thread(() => {
					ProcessStartInfo startInfo = new ProcessStartInfo("SoundWmaPlayer.exe");
					startInfo.Arguments = DameRutaTemporal(Obtener("SoundTrack"),"SoundTrack") + "  -i";
					startInfo.WindowStyle = windowsStyle;
					Process.Start(startInfo);
				});
				ejecutarBackGround.Start();
			}
		}
		public static void StopSoundTrack()
		{
			//quita el sonido del background
			foreach (Process pr in Process.GetProcesses()) {
				
				if (pr.ProcessName == "SoundWmaPlayer") {
					pr.Kill();
				}
			}
			ejecutandoSonidoBackGround = false;
		}
		public static void PonOQuitaSoundTrack()
		{
			PonOQuitaSoundTrack(true);
		}
		public static void PonOQuitaSoundTrack(bool visible)
		{
			ProcessWindowStyle windowsStyle=visible?ProcessWindowStyle.Minimized:ProcessWindowStyle.Hidden;
			if (!ejecutandoSonidoBackGround)
				PlaySoundTrack(windowsStyle);
			else
				StopSoundTrack();
		}

	}
}
