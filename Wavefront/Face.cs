// Copyright 2024 Taichi Murakami.

using System;

namespace Containers.Wavefront
{
	/// <summary>
	/// DOM オブジェクトを構成する面を表します。
	/// OBJ ファイルにおける <c>f</c>。
	/// </summary>
	public struct Face
	{
		public static Face InvalidValue
		{
			get
			{
				return new Face(Vertex.InvalidValue, Vertex.InvalidValue, Vertex.InvalidValue);
			}
		}

		public bool IsValid
		{
			get
			{
				return this != InvalidValue;
			}
		}

		public FaceShape Shape
		{
			get
			{
				return Vertex3.IsValid ? FaceShape.Rectangle : FaceShape.Triangle;
			}
		}

		public Vertex Vertex0
		{
			get
			{
				return vertex0;
			}
			set
			{
				vertex0 = value;
			}
		}

		public Vertex Vertex1
		{
			get
			{
				return vertex1;
			}
			set
			{
				vertex1 = value;
			}
		}

		public Vertex Vertex2
		{
			get
			{
				return vertex2;
			}
			set
			{
				vertex2 = value;
			}
		}

		public Vertex Vertex3
		{
			get
			{
				return vertex3;
			}
			set
			{
				vertex3 = value;
			}
		}

		public Vertex this[int index]
		{
			get
			{
				switch (index)
				{
					case 0:
						return Vertex0;
					case 1:
						return Vertex1;
					case 2:
						return Vertex2;
					case 3:
						return Vertex3;
					default:
						throw new IndexOutOfRangeException();
				}
			}
			set
			{
				switch (index)
				{
					case 0:
						Vertex0 = value;
						break;
					case 1:
						Vertex1 = value;
						break;
					case 2:
						Vertex2 = value;
						break;
					case 3:
						Vertex3 = value;
						break;
					default:
						throw new IndexOutOfRangeException();
				}
			}
		}

		public Face(Vertex vertex0, Vertex vertex1, Vertex vertex2)
		{
			this.vertex0 = vertex0;
			this.vertex1 = vertex1;
			this.vertex2 = vertex2;
			this.vertex3 = Vertex.InvalidValue;
		}

		public Face(Vertex vertex0, Vertex vertex1, Vertex vertex2, Vertex vertex3)
		{
			this.vertex0 = vertex0;
			this.vertex1 = vertex1;
			this.vertex2 = vertex2;
			this.vertex3 = vertex3;
		}

		public override bool Equals(object other)
		{
			return (other is Face) ? (this == (Face)other) : base.Equals(other);
		}

		public override int GetHashCode()
		{
			return Vertex0.GetHashCode();
		}

		public override string ToString()
		{
			return (Shape == FaceShape.Triangle) ?
				string.Format("{{{0}, {1}, {2}}}", Vertex0, Vertex1, Vertex2) :
				string.Format("{{{0}, {1}, {2}, {3}}}", Vertex0, Vertex1, Vertex2, Vertex3);
		}

		public static bool operator ==(Face left, Face right)
		{
			return
				(left.Vertex0 == right.Vertex0) &&
				(left.Vertex1 == right.Vertex1) &&
				(left.Vertex2 == right.Vertex2) &&
				(left.Vertex3 == right.Vertex3);
		}

		public static bool operator !=(Face left, Face right)
		{
			return
				(left.Vertex0 != right.Vertex0) ||
				(left.Vertex1 != right.Vertex1) ||
				(left.Vertex2 != right.Vertex2) ||
				(left.Vertex3 != right.Vertex3);
		}

		private Vertex vertex0;
		private Vertex vertex1;
		private Vertex vertex2;
		private Vertex vertex3;
	}
}
