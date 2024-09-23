// Copyright 2024 Taichi Murakami.

using System;
using System.IO;
using System.Numerics;

namespace Containers.Wavefront
{
	/// <summary>
	/// OBJ ファイルにおける例外を説明する情報を保持します。
	/// </summary>
	internal class DocumentReader : IDisposable
	{
		/// <summary>
		/// 現在の行で最初の単語を返します。
		/// </summary>
		public string Command
		{
			get
			{
				if (words == null)
				{
					throw new InvalidOperationException();
				}
				else if (words.Length > 0)
				{
					return words[0];
				}
				else
				{
					throw new DocumentException(this);
				}
			}
		}

		/// <summary>
		/// 現在のファイルの名前。
		/// </summary>
		public string File
		{
			get
			{
				return file;
			}
		}

		/// <summary>
		/// 現在の行。
		/// </summary>
		public int Line
		{
			get
			{
				return line;
			}
		}

		/// <summary>
		/// 現在の読み込み機能。
		/// </summary>
		public StreamReader Reader
		{
			get
			{
				return reader;
			}
		}

		/// <summary>
		/// 現在の行。
		/// </summary>
		public string Text
		{
			get
			{
				return text;
			}
		}

		/// <summary>
		/// 現在の行における各単語。
		/// </summary>
		public string[] Words
		{
			get
			{
				return words;
			}
		}

		/// <summary>
		/// クラスの新しいインスタンスを初期化します。
		/// </summary>
		/// <param name="fileName">OBJ ファイルへのパス。</param>
		public DocumentReader(string fileName)
		{
			file = fileName;
			reader = new StreamReader(fileName);
		}

		/// <summary>
		/// 現在のストリームを終了します。
		/// </summary>
		public void Dispose()
		{
			if (reader != null)
			{
				reader.Dispose();
				reader = null;
			}

			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// 次の行を読み込みます。
		/// </summary>
		/// <returns>次の行を読み込んだ場合は true を返します。</returns>
		public bool Next()
		{
			if (reader == null)
			{
				throw new InvalidOperationException();
			}
			else
			{
				text = reader.ReadLine();
				line++;

				bool contains = text != null;

				if (contains)
				{
					words = text.Split(' ');
				}

				return contains;
			}
		}

		/// <summary>
		/// 現在のパラメーターから論理値を取得します。
		/// </summary>
		public bool ParseBoolean()
		{
			if (words == null)
			{
				throw new InvalidOperationException();
			}
			else if (words.Length > 1)
			{
				string source = words[1];

				if (int.TryParse(source, out int value))
				{
					return value != 0;
				}
				else
				{
					return source != "off";
				}
			}
			else
			{
				throw new DocumentException(this);
			}
		}

		/// <summary>
		/// 現在のパラメーターから面を取得します。
		/// </summary>
		public Face ParseFace()
		{
			const int maxTokens = 3;
			const int maxWords = 4;
			const int offFaces = -1;

			if (words == null)
			{
				throw new InvalidOperationException();
			}
			else if (words.Length > 3)
			{
				Face face = Face.InvalidValue;

				for (int wordIndex = 1; (wordIndex < words.Length) && (wordIndex <= maxWords); wordIndex++)
				{
					string[] tokens = words[wordIndex].Split('/');
					Vertex vertex = Vertex.InvalidValue;

					for (int tokenIndex = 0; (tokenIndex < tokens.Length) && (tokenIndex < maxTokens); tokenIndex++)
					{
						if (int.TryParse(tokens[tokenIndex], out int value))
						{
							value--;
							vertex[tokenIndex] = value;
						}
					}

					face[wordIndex + offFaces] = vertex;
				}

				return face;
			}
			else
			{
				throw new DocumentException(this);
			}
		}

		/// <summary>
		/// 現在のパラメーターから実数を取得します。
		/// </summary>
		public float ParseSingle()
		{
			if (words == null)
			{
				throw new InvalidOperationException();
			}
			else if (words.Length > 1)
			{
				return float.Parse(words[1]);
			}
			else
			{
				throw new DocumentException(this);
			}
		}

		/// <summary>
		/// 現在のパラメーターから文字列を取得します。
		/// </summary>
		public string ParseString()
		{
			if (words == null)
			{
				throw new InvalidOperationException();
			}
			else if (words.Length > 1)
			{
				return words[1];
			}
			else
			{
				throw new DocumentException(this);
			}
		}

		/// <summary>
		/// 現在のパラメーターからベクトルを取得します。
		/// </summary>
		public Vector2 ParseVector2()
		{
			if (words == null)
			{
				throw new InvalidOperationException();
			}
			else if (words.Length > 2)
			{
				return new Vector2(
					float.Parse(words[1]),
					float.Parse(words[2]));
			}
			else
			{
				throw new DocumentException(this);
			}
		}

		/// <summary>
		/// 現在のパラメーターからベクトルを取得します。
		/// </summary>
		public Vector3 ParseVector3()
		{
			if (words == null)
			{
				throw new InvalidOperationException();
			}
			else if (words.Length > 3)
			{
				return new Vector3(
					float.Parse(words[1]),
					float.Parse(words[2]),
					float.Parse(words[3]));
			}
			else
			{
				throw new DocumentException(this);
			}
		}

		private StreamReader reader;
		private string file;
		private string text;
		private string[] words;
		private int line;
	}
}
