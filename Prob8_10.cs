using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace Euler
{
	public static partial class MainClass
	{ 
		#region PROB_8
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
				temp *= inputStream [i];
			}

			max_ending_here = Math.Max (temp, 0);
			max_so_far = Math.Max (max_so_far, max_ending_here);

			for (int i = n; i < inputStream.Length; i++) {
				if (inputStream [i] != 0 && inputStream [i - n] != 0) {
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
		public static int[] read_file_to_array ()
		{
			Console.WriteLine ("Enter file name to be read: ");
			string input_file = Console.ReadLine ().Trim ();
			
			string text = File.ReadAllText (input_file).Replace (Environment.NewLine, "");
			text = text.Trim ();
			int[] array = new int[text.Length];
			int i = 0;
			foreach (char c in text) {
				array [i] = (int)Char.GetNumericValue (c);
				++i;
			}
			return array;
		}
		#endregion

		#region PROB_9
		public static int pythag_triples (int n)
		{
			int sum_trip = (int)Math.Pow (n, 2) / 2;
			int val;
			int a = 1;
			int s1 = 0;
			while (1 == 1) {
				s1 = b (a, sum_trip);
				val = sum_trip - (1000 * a) - (1000 * s1) + a * s1;
				if (val == 0) {
					break;
				}

				++a;
			}
			int c = n - s1 - a;
			return a * s1 * c;
		}

		public static int b (int a, int sum_trip)
		{
			return ((sum_trip - 1000 * a) / (1000 - a));
		}
		#endregion

		#region PROB_10
		public static long prime_sum (int n)
		{
			BitArray sieve = new BitArray (n + 1, true);
			long sum = 2;

			for (int i = 3; i <= n; i += 2) {
				if (sieve [i] == true) {
					for (int j = i + i; j <= n; j += i) {
						sieve [j] = false;
					}
					sum += i; 
				}
			}
			return sum;
		}
		#endregion

		#region PROB_11

		public static int max_product(Int32[,] grid)
		{
			const int nvals = 4;
			int max_prod = int.MinValue;
			int tmp;
			// evaluate along each row
			for (int i = 0; i < (int)Math.Sqrt (grid.Length); i++) {
				for (int j = 0; j < (int) Math.Sqrt (grid.Length) - nvals; j++) {
					tmp = 1;
					for (int k = 0; k < nvals; k++) {
						tmp *= grid [i, j + k];
					}
					max_prod = Math.Max (tmp, max_prod);
				}
			}

			// evaluate along each column
			for (int i = 0; i < (int)Math.Sqrt (grid.Length) - nvals; i++) {
				for (int j = 0; j < (int) Math.Sqrt (grid.Length); j++) {
					tmp = 1;
					for (int k = 0; k < nvals; k++) {
						tmp *= grid [i + k, j];
					}
					max_prod = Math.Max (tmp, max_prod);
				}
			}

			// calculate first diagonal product
			for (int i = 0; i < (int)Math.Sqrt (grid.Length) - nvals; i++) {
				for (int j = 0; j < (int)Math.Sqrt (grid.Length) - nvals; j++){
					tmp = 1;
					for (int k = 0; k < nvals; k++) {
						tmp *= grid[i + k, j + k];
					}
					max_prod = Math.Max (tmp, max_prod);
				}
			}

			// calculate second diagonal product
			for (int i = nvals - 1; i < (int)Math.Sqrt (grid.Length); i++) {
				for (int j = 0; j < (int)Math.Sqrt (grid.Length) - nvals; j++) {
					tmp = 1;
					for (int k = 0; k < nvals; k++) {
						tmp *= grid [j + k, i - k];
						//tmp *= grid [i - k, j + k];
					}
					max_prod = Math.Max (tmp, max_prod);
				}
			}
			return max_prod;
		}

		public static int max_product_fast(Int32[,] grid)
		{
			int[] max_loc = new int[(int)Math.Sqrt(grid.Length)];
			int size = (int)Math.Sqrt (grid.Length);
			int max = int.MinValue;

			for (int i = 0; i < size; i++) {
				max = 0;
				for (int j = 0; j < size; j++){
					max = (grid [i, j] > grid [i, max]) ? j : max;
				}

				max_loc [i] = max;
			}

			// Now iterate over max vals in each row and compute 
			for (int i = 0; i < size; i++) {
				int _row = max_val (grid, i, max_loc[i], size);
				max = Math.Max (max, _row);
			}

			return max;
		}

		public static int max_val(int[,] grid, int row, int col, int size)
		{
			int _rowval = (row < size - 4) ? grid [row + 1, col] * grid [row + 2, col] * grid [row + 3, col] : 0;
			int _colval = (col < size - 4) ? grid [row, col + 1] * grid [row, col + 2] * grid [row, col + 3] : 0;
			int _diag1 = (row < size - 4 && col < size - 4) ? grid [row + 1, col + 1] * grid [row + 2, col + 2] * grid [row + 3, col + 3] : 0;
			int _diag2 = 0;
			if ((row > 3 && col < size - 4) && (row < size - 4 && col >= 3))
			{
				_diag2 = grid [row + 1, col - 1] * grid [row + 2, col - 2] * grid [row + 3, col - 3];
			}

			int max1 = Math.Max (_rowval, _colval);
			int max2 = Math.Max (_diag1, _diag2);
			return Math.Max (max1, max2) * grid [row, col];
		}

		#endregion

		#region PROB_12

		#endregion

		#region UTILITIES

		public static Int32[,] load (string path, string _delim = " ")
		{
			using (StreamReader file = new StreamReader(path)) {
				string line = string.Empty;
				//string[] split_line;
				//bool ints_only = true;

				char[] delim = {_delim [0]};
				List<int[]> tmp = new List<int[]>();
				int m, n;
				m = n = 0;
				while (!file.EndOfStream) {
					line = file.ReadLine ().Replace(Environment.NewLine, "");
					//split_line = line.Split (delim);
					tmp.Add (line.Split(delim).Select(x => Convert.ToInt32(x)).ToArray());
					n = Math.Max (tmp[m].Length, n);
					++m;
				}

				int[,] out_array = new int[m, n];
				for (int i = 0; i < m; i++)
				{
					for (int j = 0; j < n; j++)
					{
						out_array[i, j] = tmp[i][j];
					}
				}

				return out_array;
			}
		}

		#endregion

		#endregion

		#region LINQ_Extensions

		public static bool isInteger(this IEnumerable<double> source) 
		{

			foreach (var item in source) {
				if (item % 1 != 0) {
					return false;
				}
			}

			return true;
		}

		public static bool isInteger(this IEnumerable<string> source)
		{
			return source.Select (x => Convert.ToDouble (x)).isInteger ();
		}

		#endregion
	}
}

