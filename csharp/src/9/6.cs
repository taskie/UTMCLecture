using System;
class Program
{
  static void Main()
  {
    Random rand = new Random(<strong>1234</strong>);
    for (int i = 0; i &lt; 10; i++)
    {
      Console.WriteLine(rand.Next(100));
    }
  }
}
