using System;
class Program
{
  static void Main()
  {
    int[] fibonacci = new int[10];
    
    fibonacci[0] = 0;
    fibonacci[1] = 1;
    
    for (int i = 2; i &lt; <strong>fibonacci.Length</strong>; i++)
    {
      fibonacci[i] = fibonacci[i-1] + fibonacci[i-2];
    }
    
    foreach (int val in fibonacci) 
    {
      Console.WriteLine(val);
    }
  }
}
