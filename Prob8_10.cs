using System;
using System.IO;
using System.Collections.Generic;


namespace Euler
{
	public static partial class MainClass
	{
		/// <summary>
		/// Max_product computes the maximum product of n non-negative integers in a stream
		/// Runs in O(n) time
		/// </summary>
		/// <param name="inputStream">Input stream.</param>
		/// <param name="n">Number of consecutive integers to conisder</param>
		public static int  max_product (int[] inputStream, int n)
		{
			int max_so_far, max_ending_here, temp;
			max_so_far = max_ending_here = 0;
			temp = inputStream [0];
			for (int i = 1; i < n; i++) {
				temp *= inputStream[i];
			}

			max_ending_here = Math.Max (temp, 0);
			max_so_far = Math.Max (max_so_far, max_ending_here);

			for (int i = n; i < inputStream.Length; i++) {
				if (inputStream [i] != 0 && inputStream[i - n] != 0) {
					temp /= inputStream [i - n];
					temp *= inputStream [i];
				} else if (i <= inputStream.Length - n) {
					i += 1;
					temp = 1;
					for (int j = i; j <= (i + n - 1); j++) {
						temp *= inputStream [j];
					}
					i += n - 1;
				}

				max_ending_here = Math.Max (temp, 0);
				max_so_far = Math.Max (max_so_far, max_ending_here);
			}

			return max_so_far;
		}

		/// <summary>
		/// Reads in file of non-negative, and populates integer array
		/// </summary>
		public static int[] read_file_to_array()
		{
			Console.WriteLine ("Enter file name to be read: ");
			string input_file = Console.ReadLine ().Trim ();
			
			string text = File.ReadAllText (input_file).Replace(Environment.NewLine, "");
			text = text.Trim ();
			int[] array = new int[text.Length];
			int i = 0;
			foreach (char c in text) {
				array [i] = (int)Char.GetNumericValue (c);
				++i;
			}
			return array;
		}

	}
}

