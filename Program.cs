using System;
using System.Collections.Generic;

namespace Euler
{
	public static partial class MainClass
	{
		public static void Main (string[] args)
		{
			
			int[] array = read_file_to_array ();
			int res = max_product (array, 5);
			Console.WriteLine (res);
			Console.ReadKey ();
		}

		public static void permute(string[] foo)
		{
			//#List<List<string>> perms = new List<List<string>> ();
			
			for (int i = 0; i < foo.Length - 1; i++)
			{
				for (int skip = i; skip < foo.Length - i; skip++) {
					List<string> curr = new List<string> ();
					for (int j = 0; j < i; j++) {
						curr.Add (foo [j]);
					}
					string scratch = string.Empty;
					int count = 0;
					for (int k = i; k < foo.Length; k++) {
						scratch = scratch + foo [k] + " ";
						++count;
						if (count % (skip + 1) == 0) {
							scratch.Trim();
							curr.Add (scratch);
							count = 0;
							scratch = string.Empty;
						}
					}
					int adj = (foo.Length - i) % (skip + 1);
					for (int l = 0; l < adj; l++) {
						curr.Add (foo [foo.Length - l - 1]);
					}
					Console.WriteLine ("The value of i is: {0}", i);
					Console.WriteLine ("The skip value is: {0}", skip);
					Console.WriteLine ("The adjustment needed is {0}", adj);
					for (int j = 0; j < curr.Count; j++) {
						Console.WriteLine (curr[j]);
					}
				}

			}
		}
	}
}
