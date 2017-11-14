using System;
using System.Collections.Generic;
using System.Linq;//System.Core.dll
using MusicTheory.Chord;
namespace Console
{
	class Program
	{
		public static void Main (string[] args)
		{
//			Test_NotSameAccidentals ();
//			Test_Accidental ();
//			Test_Degree ();
			Test_Interval ();
		}

		// Accidental.cs 異常系
		// 異なる変化記号はエラーになる
		public static void Test_NotSameAccidentals()
		{
			MusicTheory.Chord.Degree degree1 = new MusicTheory.Chord.Degree ("+-#b♯♭1");
			System.Console.WriteLine ("度名:" + degree1.Name + ", pitch:" + degree1.Pitch);
		}
		
		// Accidental.cs 正常系
		public static void Test_Accidental()
		{
			for (int i = 1; i < 3; i++) {
				foreach (string accidental in new List<string>(){"","+","-","#","b","♯","♭"}) {
					string acc_str = string.Concat(System.Linq.Enumerable.Repeat(accidental, i));
					System.Console.WriteLine (acc_str + ": " + Accidental.GetPitch (acc_str));
					acc_str += "1";
					MusicTheory.Chord.Degree deg = new MusicTheory.Chord.Degree (acc_str);
					System.Console.WriteLine ("度名:" + deg.Name + ", pitch:" + deg.Pitch);
				}
			}
		}
		
		// Degree.cs 正常系
		public static void Test_Degree()
		{
			MusicTheory.Chord.Degree.Perfects.ForEach (n => System.Console.WriteLine ("P" + n));
			MusicTheory.Chord.Degree.Majors.ForEach (n => System.Console.WriteLine ("M" + n + ", m" + n));
			for (int i = 1; i < 3; i++) {
				foreach (string accidental in new List<string>(){"","+","-","#","b","♯","♭"}) {
					for (int d = 1; d < 15; d++) {
						string acc_str = string.Concat (System.Linq.Enumerable.Repeat (accidental, i)) + d;
						MusicTheory.Chord.Degree deg = new MusicTheory.Chord.Degree (acc_str);
						System.Console.WriteLine ("度名:" + deg.Name + ", pitch:" + deg.Pitch);
					}
				}
			}
		}

		public static void Test_Interval()
		{
			foreach (char prefix in MusicTheory.Chord.Interval.Prefixes) {
				for (int degree = 1; degree < 15; degree++) {
					string name = "" + prefix + degree;
					MusicTheory.Chord.Interval interval = new MusicTheory.Chord.Interval (name);
					if (null == interval.Name || 0 == interval.Name.Trim ().Length) {
						System.Console.WriteLine ("音程名:" + name + " (無効名)");
					} else {
						System.Console.WriteLine ("音程名:" + interval.Name + ", pitch:" + interval.Pitch);
					}
				}
			}

		}
	}
}
