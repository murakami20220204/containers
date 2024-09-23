// Copyright 2024 Taichi Murakami.

using System.Collections.Generic;
using System.IO;

namespace Containers.Wavefront
{
	/// <summary>
	/// DOM として OBJ ファイル内に記述された情報を格納します。
	/// </summary>
	public class Document
	{
		/// <summary>
		/// 材質のコレクション。
		/// </summary>
		public IDictionary<string, Material> Materials
		{
			get
			{
				return materials;
			}
		}

		/// <summary>
		/// メッシュのコレクション。
		/// </summary>
		public IDictionary<string, Mesh> Meshes
		{
			get
			{
				return meshes;
			}
		}

		/// <summary>
		/// クラスの新しいインスタンスを初期化します。
		/// </summary>
		public Document()
		{
			materials = new Dictionary<string, Material>();
			meshes = new Dictionary<string, Mesh>();
		}

		/// <summary>
		/// OBJ ファイルを読み込みます
		/// </summary>
		/// <param name="fileName">OBJ ファイルへのパス。</param>
		public void Load(string fileName)
		{
			using (DocumentReader reader = new DocumentReader(fileName))
			{
				Mesh mesh = null;
				MeshMaterial material = null;

				while (reader.Next())
				{
					switch (reader.Command)
					{
						case "mtllib":
							LoadMaterialLibrary(reader);
							break;
						case "f":
							if (material == null) throw new DocumentException(reader);
							material.Faces.Add(reader.ParseFace());
							break;
						case "o":
							mesh = new Mesh();
							meshes.Add(reader.ParseString(), mesh);
							break;
						case "s":
							if (mesh == null) throw new DocumentException(reader);
							mesh.Smoothing = reader.ParseBoolean();
							break;
						case "usemtl":
							if (mesh == null) throw new DocumentException(reader);
							material = new MeshMaterial();
							material.Name = reader.ParseString();
							mesh.Materials.Add(material);
							break;
						case "v":
							if (mesh == null) throw new DocumentException(reader);
							mesh.Positions.Add(reader.ParseVector3());
							break;
						case "vn":
							if (mesh == null) throw new DocumentException(reader);
							mesh.Normals.Add(reader.ParseVector3());
							break;
						case "vt":
							if (mesh == null) throw new DocumentException(reader);
							mesh.Texcoords.Add(reader.ParseVector2());
							break;
					}
				}
			}
		}

		/// <summary>
		/// MTL ファイルを読み込みます。
		/// </summary>
		/// <param name="reader">OBJ ファイル。</param>
		private void LoadMaterialLibrary(DocumentReader reader)
		{
			using (reader = new DocumentReader(Path.Combine(Path.GetDirectoryName(reader.File), reader.ParseString())))
			{
				string name = null;
				Material material = new Material();

				while (reader.Next())
				{
					switch (reader.Command)
					{
						case "Ka":
							material.Ambient = reader.ParseVector3();
							break;
						case "Kd":
							material.Diffuse = reader.ParseVector3();
							break;
						case "Ke":
							material.Emissive = reader.ParseVector3();
							break;
						case "Ks":
							material.Specular = reader.ParseVector3();
							break;
						case "Ni":
							material.Refractance = reader.ParseSingle();
							break;
						case "Ns":
							material.Shininess = reader.ParseSingle();
							break;
						case "d":
							material.Opacity = reader.ParseSingle();
							break;
						case "newmtl":
							if (name != null)
							{
								materials[name] = material;
								material = new Material();
							}

							name = reader.ParseString();
							break;
					}
				}
				if (name != null)
				{
					materials[name] = material;
				}
			}
		}

		private Dictionary<string, Material> materials;
		private Dictionary<string, Mesh> meshes;
	}
}
