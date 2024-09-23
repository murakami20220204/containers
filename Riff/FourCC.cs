// Copyright 2024 Taichi Murakami.

namespace Containers.Riff
{
	/// <summary>
	/// RIFF チャンクの名前を 4 バイトで表します。
	/// </summary>
	public struct FourCC
	{
		public static FourCC List => new FourCC('L', 'I', 'S', 'T');
		public static FourCC Riff => new FourCC('R', 'I', 'F', 'F');

		public byte B0
		{
			get => (byte)(mask & (value >> a0));
			set => this.value &= (value << a0) | z0;
		}

		public byte B1
		{
			get => (byte)(mask & (value >> a1));
			set => this.value &= (value << a1) | z1;
		}

		public byte B2
		{
			get => (byte)(mask & (value >> a2));
			set => this.value &= (value << a2) | z2;
		}

		public byte B3
		{
			get => (byte)(mask & (value >> a3));
			set => this.value &= (value << a3) | z3;
		}

		public char C0
		{
			get => (char)B0;
			set => B0 = (byte)value;
		}

		public char C1
		{
			get => (char)B1;
			set => B1 = (byte)value;
		}

		public char C2
		{
			get => (char)B2;
			set => B2 = (byte)value;
		}

		public char C3
		{
			get => (char)B3;
			set => B3 = (byte)value;
		}

		public bool IsList
		{
			get
			{
				return
					(this == List) ||
					(this == Riff);
			}
		}

		public int Value
		{
			get => value;
			set => this.value = value;
		}

		public FourCC(int value)
		{
			this.value = value;
		}

		public FourCC(byte b0, byte b1, byte b2, byte b3)
		{
			value = ToValue(b0, b1, b2, b3);
		}

		public FourCC(char c0, char c1, char c2, char c3)
		{
			value = ToValue((byte)c0, (byte)c1, (byte)c2, (byte)c3);
		}

		/// <inheritdoc />
		public override bool Equals(object other)
		{
			return (other is FourCC) ? (this == (FourCC)other) : base.Equals(other);
		}

		/// <inheritdoc />
		public override int GetHashCode()
		{
			return value;
		}

		private static void ToBytes(int value, out byte b0, out byte b1, out byte b2, out byte b3)
		{
			b0 = (byte)(mask & (value >> a0));
			b1 = (byte)(mask & (value >> a1));
			b2 = (byte)(mask & (value >> a2));
			b3 = (byte)(mask & (value >> a3));
		}

		/// <inheritdoc />
		public override string ToString()
		{
			return new string(new char[] { C0, C1, C2, C3 });
		}

		private static int ToValue(byte b0, byte b1, byte b2, byte b3)
		{
			return
				(b0 << a0) |
				(b1 << a1) |
				(b2 << a2) |
				(b3 << a3);
		}

		public static bool operator ==(FourCC left, FourCC right)
		{
			return left.value == right.value;
		}

		public static bool operator !=(FourCC left, FourCC right)
		{
			return left.value != right.value;
		}

		private const int a0 = 0;
		private const int a1 = 8;
		private const int a2 = 16;
		private const int a3 = 24;
		private const int mask = byte.MaxValue;
		private const int z0 = ~(mask << a0);
		private const int z1 = ~(mask << a1);
		private const int z2 = ~(mask << a2);
		private const int z3 = ~(mask << a3);
		private int value;
	}
}
