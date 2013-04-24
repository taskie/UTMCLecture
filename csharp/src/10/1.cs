using System;
class Program
{
  static void Main()
  {
    int[] xs = new int[3];

    xs[0] = 123;
    xs[1] = 456;
    xs[2] = 789;

    <strong>foreach (int x in xs)</strong>
    {
      Console.WriteLine(<strong>x</strong>);
    }
  }
}
