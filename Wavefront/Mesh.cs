// Copyright 2024 Taichi Murakami.

using System.Collections.Generic;
using System.Numerics;

namespace Containers.Wavefront
{
	/// <summary>
	/// DOM オブジェクトを構成するメッシュを表します。
	/// OBJ ファイルにおける <c>o</c>。
	/// </summary>
	public class Mesh
	{
		/// <summary>
		/// OBJ ファイルにおける <c>usemtl</c>。
		/// </summary>
		public IList<MeshMaterial> Materials
		{
			get
			{
				return materials;
			}
		}

		/// <summary>
		/// OBJ ファイルにおける <c>vn</c>。
		/// </summary>
		public IList<Vector3> Normals
		{
			get
			{
				return normals;
			}
		}

		/// <summary>
		/// OBJ ファイルにおける <c>v</c>。
		/// </summary>
		public IList<Vector3> Positions
		{
			get
			{
				return positions;
			}
		}

		/// <summary>
		/// OBJ ファイルにおける <c>s</c>。
		/// </summary>
		public bool Smoothing
		{
			get
			{
				return smoothing;
			}
			set
			{
				smoothing = value;
			}
		}

		/// <summary>
		/// OBJ ファイルにおける <c>vt</c>。
		/// </summary>
		public IList<Vector2> Texcoords
		{
			get
			{
				return texcoords;
			}
		}

		/// <summary>
		/// クラスの新しいインスタンスを初期化します。
		/// </summary>
		public Mesh()
		{
			materials = new List<MeshMaterial>();
			normals = new List<Vector3>();
			positions = new List<Vector3>();
			texcoords = new List<Vector2>();
		}

		private List<MeshMaterial> materials;
		private List<Vector3> normals;
		private List<Vector3> positions;
		private List<Vector2> texcoords;
		private bool smoothing;
	}
}
