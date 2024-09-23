// Copyright 2024 Taichi Murakami.

using System.Collections.Generic;

namespace Containers.Wavefront
{
	/// <summary>
	/// Mesh が面として使用する材質を表します。
	/// </summary>
	public class MeshMaterial
	{
		/// <summary>
		/// OBJ ファイルにおける <c>f</c>。
		/// </summary>
		public IList<Face> Faces
		{
			get
			{
				return faces;
			}
		}

		/// <summary>
		/// 現在の面が使用する材質の名前。
		/// </summary>
		public string Name
		{
			get
			{
				return name;
			}
			set
			{
				name = value;
			}
		}

		/// <summary>
		/// クラスの新しいインスタンスを初期化します。
		/// </summary>
		public MeshMaterial()
		{
			faces = new List<Face>();
		}

		private List<Face> faces;
		private string name;
	}
}
