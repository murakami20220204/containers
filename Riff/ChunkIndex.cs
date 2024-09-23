// Copyright 2024 Taichi Murakami.

namespace Containers.Riff
{
	public struct ChunkIndex
	{
		public FourCC ListName
		{
			get
			{
				return listName;
			}
			set
			{
				listName = value;
			}
		}

		public FourCC Signature
		{
			get
			{
				return signature;
			}
			set
			{
				signature = value;
			}
		}

		public int Read
		{
			get
			{
				return read;
			}
			set
			{
				read = value;
			}
		}

		public int Size
		{
			get
			{
				return size;
			}
			set
			{
				size = value;
			}
		}

		public int SizeAligned
		{
			get
			{
				return Size + (Size % 2);
			}
		}

		public override string ToString()
		{
			return Signature.IsList ?
				string.Format("{0}: {1} {2}", Signature, Size, ListName) :
				string.Format("{0}: {1}", Signature, Size);
		}

		private FourCC signature;
		private int size;
		private FourCC listName;
		private int read;
	}
}
