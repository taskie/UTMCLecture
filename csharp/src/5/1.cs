using System;
class Program
{
  static void Main()
  {
    int x = int.Parse(Console.ReadLine());
    if (x % 2 == 0 <strong>||</strong> x % 3 == 0)
    {
      Console.WriteLine("2の倍数または3の倍数です");
    }
  }
}
