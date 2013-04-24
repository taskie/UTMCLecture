using System;
class Program
{
  static void Main()
  {
    int n = int.Parse(Console.ReadLine());
    int i = 0; // ループの外で変数を宣言している
    while (i &lt; n)
    {
      Console.WriteLine(i);
      i++;
    }
    Console.WriteLine(<strong>i</strong>); // ループの外で i を参照できる
  }
}
