using System;
class Program
{
  static void Main()
  {
    int n = int.Parse(Console.ReadLine());
    for (int i = 0; i &lt; n; i++)
    {
      <strong>if (i == 5) break;</strong>
      Console.WriteLine(i);
    }
  }
}
