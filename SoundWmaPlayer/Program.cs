/*
 * Creado por SharpDevelop.
 * Usuario: Gabriel
 * Fecha: 27/06/2015
 * Hora: 16:26
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Diagnostics;

namespace SoundWmaPlayer
{
	class Program
	{
		public static void Main(string[] args)
		{
			bool infinito = args[1] == "-i";
			System.Media.SoundPlayer player = new System.Media.SoundPlayer(args[0]);
			Console.WriteLine("Plaing:"+args[0]);
			if (!infinito)
				player.PlaySync();
			else{
				player.PlayLooping();
				for(;;);
			}
		}
	}
}