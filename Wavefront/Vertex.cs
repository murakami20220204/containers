// Copyright 2024 Taichi Murakami.

using System;

namespace Containers.Wavefront
{
	/// <summary>
	/// Face ノード内の各頂点を表します。
	/// </summary>
	public struct Vertex
	{
		public static Vertex InvalidValue
		{
			get
			{
				return new Vertex(-1, -1, -1);
			}
		}

		public bool IsValid
		{
			get
			{
				return this != InvalidValue;
			}
		}

		public int Normal
		{
			get
			{
				return normal;
			}
			set
			{
				normal = value;
			}
		}
		public int Position
		{
			get
			{
				return position;
			}
			set
			{
				position = value;
			}
		}

		public int Texcoord
		{
			get
			{
				return texcoord;
			}
			set
			{
				texcoord = value;
			}
		}

		public int this[int index]
		{
			get
			{
				switch (index)
				{
					case 0:
						return Position;
					case 1:
						return Texcoord;
					case 2:
						return Normal;
					default:
						throw new IndexOutOfRangeException();
				}
			}
			set
			{
				switch (index)
				{
					case 0:
						Position = value;
						break;
					case 1:
						Texcoord = value;
						break;
					case 2:
						Normal = value;
						break;
					default:
						throw new IndexOutOfRangeException();
				}
			}
		}

		public Vertex(int position, int texcoord, int normal)
		{
			this.position = position;
			this.texcoord = texcoord;
			this.normal = normal;
		}

		public override bool Equals(object other)
		{
			return (other is Vertex) ? (this == (Vertex)other) : base.Equals(other);
		}

		public override int GetHashCode()
		{
			return Position;
		}

		public override string ToString()
		{
			return string.Format("{{{0}, {1}, {2}}}", Position, Texcoord, Normal);
		}

		public static bool operator ==(Vertex left, Vertex right)
		{
			return
				(left.Position == right.Position) &&
				(left.Texcoord == right.Texcoord) &&
				(left.Normal == right.Normal);
		}

		public static bool operator !=(Vertex left, Vertex right)
		{
			return
				(left.Position != right.Position) ||
				(left.Texcoord != right.Texcoord) ||
				(left.Normal != right.Normal);
		}

		private int position;
		private int texcoord;
		private int normal;
	}
}
