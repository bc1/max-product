using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Diagnostics;

namespace Euler
{
	public static partial class MainClass
	{
		public static void Main (string[] args)
		{
			
			//int[] array = read_file_to_array ();
			//Console.WriteLine ("The solution to Problem 8 is: {0}", max_product (array, 5));
			//Console.WriteLine ("The solution to Problem 9 is: {0}", pythag_triples(1000));
			//Console.WriteLine ("The solution to Problem 10 is: {0}", prime_sum (2000000));
			Int32[,] _array = load ("/users/bryancallaway/Projects/Euler/test_matrix.txt");
			Stopwatch s = new Stopwatch();
			s.Start ();
			Console.WriteLine (max_product (_array));
			s.Stop ();
			Console.WriteLine ("Time elapsed: {0}", s.ElapsedMilliseconds);
			Stopwatch t = new Stopwatch ();
			t.Start ();
			Console.WriteLine (max_product_fast (_array));
			t.Stop ();
			Console.WriteLine ("Time elapsed: {0}", t.ElapsedMilliseconds);
			Console.ReadKey ();





			/*
			string _str = "04 08 09.7 11";
			IEnumerable<Double> _str_split = _str.Split ().Select(x => Convert.ToDouble (x));
			//double[] f = _str_split.Where (x => (x % 1) != 0)
			bool _ints = _str_split.isInteger ();
			Console.WriteLine (_ints);

			foreach (double i in _str_split)
				Console.Write (i.ToString () + ',');
			Console.ReadKey ();
			*/
		}
	}

	
}