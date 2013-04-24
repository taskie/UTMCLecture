using System;
class Program
{
  static void Main()
  {
    <strong>bool loopFlag = true;</strong>
    while (<strong>loopFlag</strong>)
    {
      Console.WriteLine("ループから抜けますか？ (y/n)");
      if (Console.ReadLine() == "y") {
        <strong>loopFlag = false;</strong>
      }
    }
  }
}
