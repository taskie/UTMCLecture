using System;
class Program
{
  static void Main()
  {
    int x = int.Parse(Console.ReadLine());
    <strong>if (x > 0)</strong>
    <strong>{</strong>
      Console.WriteLine("正の数です");
    <strong>}</strong>
    <strong>else if (x == 0)</strong>
    <strong>{</strong>
      Console.WriteLine("0です");
    <strong>}</strong>
    <strong>else if (x == -1)</strong>
    <strong>{</strong>
      Console.WriteLine("-1です");
    <strong>}</strong>
    <strong>else</strong>
    <strong>{</strong>
      Console.WriteLine("-1以外の負の数です");
    <strong>}</strong>
  }
}
