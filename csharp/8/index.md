# C#プログラミング講習会

## 8. メソッドを定義する

### メソッドを定義して呼び出す

**メソッド**<span class="fs_80">（C言語やC++等では関数と呼ばれる）</span>というものを定義することにより、処理をまとまった単位に分割することができます。以下のように書くことでメソッドを定義でき、Mainから呼び出すことができるようになります（実はMainもメソッドの一つです。プログラムは必ずMain メソッドから開始します）。

<pre class="code"><code>using System;
class Program
{
  <strong>static void RepeatHello()</strong>
  {
    for (int i = 0; i &lt; 5; i++)
    {
      Console.WriteLine("Hello!");
    }
  }

  static void Main()
  {
    <strong>RepeatHello();</strong>
  }
}
</code></pre>

### 引数のあるメソッドを定義して呼び出す

メソッドには小括弧を使って情報を渡すことができます。これを**引数（ひきすう）**と呼びます。

<pre class="code"><code>using System;
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
</code></pre>

上の場合、RepeatHello メソッドの第1引数として表示する文字列、第2引数として繰り返す回数を指定します。

### 戻り値のあるメソッドを定義して呼び出す

**return**を使うことでメソッドの実行結果を指定できます。
これを**戻り値**（返り値）と呼びます。
メソッド名の前で戻り値の型を指定する必要があります。

以下は引数として与えられた整数<var>n</var>の2乗の値を返すメソッドです。

<pre class="code"><code>using System;
class Program
{
  static <strong>int</strong> Pow2(int n)
  {
    <strong>return</strong> n * n;
  }
  
  static void Main()
  {
    Console.WriteLine(<strong>Pow2(2)</strong>);
    Console.WriteLine(<strong>Pow2(3)</strong> + <strong>Pow2(4)</strong>);
    Console.WriteLine(<strong>Pow2(Pow2(2))</strong>);
  }
}
</code></pre>

**void**は戻り値がないメソッドを示すキーワードです。戻り値がない場合でも`return;`と書くことでメソッド内の処理から抜けることができます。

### 演習：累乗プログラム

整数`a`, 自然数`n`を引数に取り、`a`の`n`乗を求めるメソッド`pow`を定義し、Main メソッドからそれを利用するプログラムを作りましょう。
