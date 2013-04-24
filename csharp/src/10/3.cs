using System;
class Program
{
  static void Main()
  {
    int[] xs = { 2, 3, 5, 7, 11, 13, 17, 19 };
    int[] ys = xs;  // ys に xs を代入
    ys[4] = 256;    // ys を 弄る
    
    foreach (int x in xs) Console.WriteLine(x);  // xs[4] も変更されている
  }
}
