using System;
class Program
{
  static void Main()
  {
    int x = int.Parse(Console.ReadLine());
    switch (x)
    {
      case 0:
        Console.WriteLine("A");
        break;
      case 1:
        Console.WriteLine("B");
        break;
      case 2:
      case 3:
        Console.WriteLine("C");
        break;
      default:
        Console.WriteLine("D");
        break;
    }
  }
}
