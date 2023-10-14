using System.IO;
using System.Threading.Tasks;

namespace Music.Helper
{
	public class FileManager
	{
		public const string fileName = "token.txt";

		public static async Task WriteToFileToken(string token)
		{
			using (StreamWriter writer = new StreamWriter(fileName, false))
			{
				await writer.WriteLineAsync($"token={token}");
			}
		}

		public static async Task<string> ReadFromFileToken()
		{
			using (StreamReader reader = new StreamReader(fileName))
			{
				string line;
				while ((line = await reader.ReadLineAsync()) != null)
				{
					if (line.StartsWith("token="))
					{
						return line.Substring(6);
					}
				}
				return null;
			}
		}

		public static void DeleteFileToken()
		{
			using (StreamWriter writer = new StreamWriter(fileName, false))
			{
				writer.WriteAsync(string.Empty);
			}
		}
	}
}