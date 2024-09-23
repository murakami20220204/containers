// Copyright 2024 Taichi Murakami.

using System;

namespace Containers.Wavefront
{
	/// <summary>
	/// OBJ ファイル内の特定の行で失敗した場合に発生します。
	/// </summary>
	public class DocumentException : Exception
	{
		/// <summary>
		/// クラスの新しいインスタンスを初期化します。
		/// </summary>
		internal DocumentException(DocumentReader reader) : this(reader.File, reader.Line, reader.Text)
		{
		}

		/// <summary>
		/// クラスの新しいインスタンスを初期化します。
		/// </summary>
		public DocumentException(string file, int line, string text) : base(FormatMessage(file, line, text))
		{
		}

		/// <summary>
		/// 例外を説明する文字列を作成します。
		/// </summary>
		private static string FormatMessage(string file, int line, string text)
		{
			return string.Format("Document error: {0} ({1}): {2}", file, line, text);
		}
	}
}
