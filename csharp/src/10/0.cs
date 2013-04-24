using System;
class Program
{
  static void Main()
  {
    <strong>int[] xs = new int[3];</strong>

    <strong>xs[0] = 123;</strong>
    <strong>xs[1] = 456;</strong>
    <strong>xs[2] = 789;</strong>

    for (int i = 0; i &lt; 3; i++)
    {
      Console.WriteLine(<strong>xs[i]</strong>);
    }
  }
}
