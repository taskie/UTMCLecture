using System;
class Program
{
  static void Main()
  {
    int n = int.Parse(Console.ReadLine());
    for (int i = 0; i &lt; n; i++)
    {
      <strong>if (i % 2 == 0) continue;</strong>
      Console.WriteLine(i);
    }
  }
}
