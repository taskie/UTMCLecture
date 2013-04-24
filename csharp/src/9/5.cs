using System;
class Program
{
  static void Main()
  {
    <strong>Random rand = new Random();</strong>
    for (int i = 0; i &lt; 10; i++)
    {
      Console.WriteLine(<strong>rand.Next(100)</strong>);
    }
  }
}
