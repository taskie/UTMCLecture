using System;
class Program
{
  static void Main()
  {
    int x = int.Parse(Console.ReadLine());
    if (x &gt; 0 <strong>&amp;&amp;</strong> x % 2 == 0)
    {
      Console.WriteLine("正の2の倍数です");
    }
  }
}
