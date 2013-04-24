using System;
class Program
{
  static <strong>int</strong> Pow2(int n)
  {
    <strong>return</strong> n * n;
  }
  
  static void Main()
  {
    Console.WriteLine(<strong>Pow2(2)</strong>);
    Console.WriteLine(<strong>Pow2(3)</strong> + <strong>Pow2(4)</strong>);
    Console.WriteLine(<strong>Pow2(Pow2(2))</strong>);
  }
}
