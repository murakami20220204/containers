// Copyright 2024 Taichi Murakami.

using System.Numerics;

namespace Containers.Wavefront
{
	/// <summary>
	/// DOM オブジェクトを構成する材質を表します。
	/// OBJ ファイルにおける <c>newmtl</c>。
	/// </summary>
	public struct Material
	{
		/// <summary>
		/// Ambient 色を示します。
		/// OBJ ファイルにおける <c>Ka</c>。
		/// </summary>
		public Vector3 Ambient { get; set; }

		/// <summary>
		/// Diffuse 色を示します。
		/// OBJ ファイルにおける <c>Kd</c>。
		/// </summary>
		public Vector3 Diffuse { get; set; }

		/// <summary>
		/// Emissive 色を示します。
		/// OBJ ファイルにおける <c>Ke</c>。
		/// </summary>
		public Vector3 Emissive { get; set; }

		/// <summary>
		/// Specular 色を示します。
		/// OBJ ファイルにおける <c>Ks</c>。
		/// </summary>
		public Vector3 Specular { get; set; }

		/// <summary>
		/// 不透明度を示します。
		/// OBJ ファイルにおける <c>d</c>。
		/// </summary>
		public float Opacity { get; set; }

		/// <summary>
		/// 屈折率を示します。
		/// OBJ ファイルにおける <c>Ni</c>。
		/// </summary>
		public float Refractance { get; set; }

		/// <summary>
		/// Specular 色の強さを 0 から 1000 で示します。
		/// OBJ ファイルにおける <c>Ns</c>。
		/// </summary>
		public float Shininess { get; set; }
	}
}
