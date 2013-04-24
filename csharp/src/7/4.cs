using System;
class Program
{
  static void Main()
  {
    int n = int.Parse(Console.ReadLine());
    <strong>for (int i = n; i &gt;= 0; i -= 2)</strong>
    {
      Console.WriteLine(i);
    }
  }
}
