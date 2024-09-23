// Copyright 2024 Taichi Murakami.

using Containers.Riff;
using System;
using System.IO;

namespace Containers.RiffTest
{
	internal static class Program
	{
		public static void Main(string[] args)
		{
			if (args.Length > 0)
			{
				using (FileStream input = File.OpenRead(args[0]))
				{
					using (BinaryReader reader = new BinaryReader(input))
					{
						Read(reader);
					}
				}
			}
			else
			{
				Console.WriteLine("Arguments: InputFileName");
			}
		}

		public static ChunkIndex Read(BinaryReader reader)
		{
			ChunkIndex chunk = new ChunkIndex();
			chunk.Signature = new FourCC(reader.ReadInt32());
			chunk.Size = reader.ReadInt32();
			chunk.Read = 8;

			if (chunk.Signature.IsList)
			{
				chunk.ListName = new FourCC(reader.ReadInt32());
				chunk.Read += 4;
			}

			Console.WriteLine(chunk);

			if (chunk.Signature.IsList)
			{
				int end = chunk.Size + 8;

				while (chunk.Read < end)
				{
					ChunkIndex child = Read(reader);
					chunk.Read += child.Read;
					Console.WriteLine("{0}: {1}/{2}", chunk.ListName, chunk.Read, end);
				}
				if (chunk.Read > end)
				{
					throw new Exception();
				}
			}
			else
			{
				int offset = chunk.SizeAligned;
				reader.BaseStream.Seek(chunk.SizeAligned, SeekOrigin.Current);
				chunk.Read += offset;
			}

			return chunk;
		}
	}
}
