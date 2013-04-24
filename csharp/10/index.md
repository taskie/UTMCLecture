# C#プログラミング講習会

## 10. 配列を使う

同じ型の大量の変数を扱う方法として、配列というものが用意されています。

<pre class="code"><code>using System;
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
</code></pre>

まず、**`int[] xs`**と書くことで**「int 型の配列」型の変数**<var>xs</var>を宣言します。
その<var>xs</var>に**「3要素のint 型配列」オブジェクト**を代入しています
（なんだか変な構文ですが慣れてください。僕は慣れていません）。

こうすることで、xs[0], xs[1], xs[2]の3つの変数を使うことができるようになります。
[]の中の数字のことを**インデックス**（添え字）と呼びます。**インデックスは0から(<var>要素数</var>-1)までの整数値を取ります。**

### foreach 文

上の例のように配列はfor 文と組み合わせて使われることが多いのですが、
C#には**foreach 文**という構文が用意されており以下のように書くこともできます。

<pre class="code"><code>using System;
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
</code></pre>

変数<var>x</var>には配列<var>xs</var>の要素が次々に入ります。
foreach 文の場合、**<var>x</var>に何か値を代入しても配列中の値は変更されません。**

### フィボナッチ数列を得る

配列を使ってフィボナッチ数列を得るプログラムを書くと以下のようになります。

<pre class="code"><code>using System;
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
</code></pre>

配列の**Length**プロパティを呼ぶと要素数（ここでは10）がわかるのでfor 文を使う時はこのようにすることをおすすめします。

### 演習：トリボナッチ数出力プログラム

フィボナッチ数列は「前の2項の和」で定義されますが、トリボナッチ数列（[Wikipedia](http://ja.wikipedia.org/wiki/%E3%83%95%E3%82%A3%E3%83%9C%E3%83%8A%E3%83%83%E3%83%81%E6%95%B0#.E3.83.88.E3.83.AA.E3.83.9C.E3.83.8A.E3.83.83.E3.83.81.E6.95.B0)）は「前の3項の和」で定義されます。

0, 0, 1, 1, 2, 4, 7, 13, 24, ...

フィボナッチ数列のコード例を参考にし、20要素の配列`tribonacci`を作ってトリボナッチ数列を計算しましょう。

### [こぼれ話](javascript:showKobore();)

<div class="kobore">

配列を`int[] xs = { 2, 3, 5, 7, 11, 13, 17, 19 };`のように初期化することができます。

配列型の変数に既存の配列を代入すると同じ物を指すようになります。

<pre class="code"><code>using System;
class Program
{
  static void Main()
  {
    int[] xs = { 2, 3, 5, 7, 11, 13, 17, 19 };
    int[] ys = xs;  // ys に xs を代入
    ys[4] = 256;    // ys を 弄る
    
    foreach (int x in xs) Console.WriteLine(x);  // xs[4] も変更されている
  }
}
</code></pre>

配列に限らず既存のオブジェクトを変数に代入すると変数は同一のオブジェクトを指すようになります。

</div>
