using System;
class Program
{
  static void Main()
  {
    int n = 0;
    Console.WriteLine("入力された整数を合計します（0を入力すると終了します）")
    <strong>for ( ; ; ) {</strong>
      int x = int.Parse(Console.ReadLine());
      if ( x == 0 ) break;
      n += x;
    <strong>}</strong>
    Console.WriteLine("合計：{0}", n);
  }
}
