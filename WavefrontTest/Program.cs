// Copyright 2024 Taichi Murakami.

using Containers.Wavefront;
using System;
using System.Collections.Generic;

namespace Containers.WavefrontTest
{
	internal static class Program
	{
		public static void Main(string[] args)
		{
			if (args.Length > 0)
			{
				Document document = new Document();
				document.Load(args[0]);

				foreach (KeyValuePair<string, Material> material in document.Materials)
				{
					Console.WriteLine(material);
				}
				foreach (KeyValuePair<string, Mesh> mesh in document.Meshes)
				{
					Console.WriteLine(mesh);
				}
			}
			else
			{
				Console.WriteLine("Arguments: InputFileName");
			}
		}
	}
}
