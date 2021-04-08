using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace TestAws
{
	class Program
	{
		static async Task Main(string[] args)
		{
			try
			{
				using (var client = new HttpClient())
				{
					var res = await client.GetAsync("http://169.254.169.254/latest/dynamic/instance-identity/document");

					if (res.IsSuccessStatusCode)
					{
						Console.WriteLine("AWS environment");
						var txt = await res.Content.ReadAsStringAsync();
						Console.WriteLine($"The response is {txt}");
					}
					else
					{
						Console.WriteLine("Not AWS");
					}
				}
			}
			catch
			{
				Console.WriteLine("Not AWS");
			}
		}
	}
}
