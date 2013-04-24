# C#プログラミング講習会

## 5. 続・処理を分岐させる

### 複雑な条件式

「A かつ B」のような条件式を作りたい時は、**&amp;&amp;**（論理積演算子）を使います。

<pre class="code"><code>using System;
class Program
{
  static void Main()
  {
    int x = int.Parse(Console.ReadLine());
    if (x &gt; 0 <strong>&amp;&amp;</strong> x % 2 == 0)
    {
      Console.WriteLine("正の2の倍数です");
    }
  }
}
</code></pre>

「A または B」のような条件式を作りたい時は、**||**（論理和演算子）を使います。

<pre class="code"><code>using System;
class Program
{
  static void Main()
  {
    int x = int.Parse(Console.ReadLine());
    if (x % 2 == 0 <strong>||</strong> x % 3 == 0)
    {
      Console.WriteLine("2の倍数または3の倍数です");
    }
  }
}
</code></pre>

「A ではない」のような条件式を作りたい時は、**!**（論理否定演算子）を使います。

<pre class="code"><code>using System;
class Program
{
  static void Main()
  {
    int x = int.Parse(Console.ReadLine());
    if (<strong>!</strong>(x % 3 == 0))
    {
      Console.WriteLine("3の倍数ではありません");
    }
  }
}
</code></pre>

演算子の優先順位に注意してください（`!`は結合の優先順位がかなり高いので`!x % 3 == 0`だと`(!x) % 3 == 0`と解釈されてしまいます）。
優先順位がよく分からない場合はとりあえず括弧を付けておきましょう（もっとも、上の場合 != 演算子を用いて`x % 3 != 0`と表せるのですが）。

### switch 文

**switch 文**を使うことである変数の値によって処理を分岐させることができます。

<pre class="code"><code>using System;
class Program
{
  static void Main()
  {
    int x = int.Parse(Console.ReadLine());
    switch (x)
    {
      case 0:
        Console.WriteLine("A");
        break;
      case 1:
        Console.WriteLine("B");
        break;
      case 2:
      case 3:
        Console.WriteLine("C");
        break;
      default:
        Console.WriteLine("D");
        break;
    }
  }
}
</code></pre>

上の例では、xが0ならA、1ならB、2, 3ならC、それ以外ならDが表示されます（defaultがif 文のelseの役割を果たします）。

C#では、caseでの処理の終わりには**break**が必要です。
