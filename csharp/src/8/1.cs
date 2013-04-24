using System;
class Program
{
  static void RepeatHello(<strong>string s, int n</strong>)
  {
    for (int i = 0; i &lt; n; i++)
    {
      Console.WriteLine("Hello, {0}!", s);
    }
  }

  static void Main()
  {
    RepeatHello(<strong>"world", 5</strong>);
  }
}
