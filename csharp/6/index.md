# C#プログラミング講習会

## 6. 処理を繰り返させる

### while 文

コンピュータは基本的に「単純作業を繰り返させる」「大量のデータを処理させる」為の存在です。
だから、繰り返し構文は<span class="fs_80">（手続き型）</span>プログラミングにおいて最も重要な構文でしょう。

**while 文**は、**条件式が満たされている場合中括弧の中の処理を繰り返します**。条件式の判定は**ループに入る時**及び**中括弧内の処理が終わってループの先頭に戻る時**に行われます。

<pre class="code"><code>using System;
class Program
{
  static void Main()
  {
    int n = int.Parse(Console.ReadLine());
    <strong>while (n &lt; 10)</strong>
    <strong>{</strong>
      Console.WriteLine(n);
      n = n + 1;
    <strong>}</strong>
  }
}
</code></pre>

**最初から条件が満たされていない場合は1度もその処理を行いません。**また、**ずっと条件が満たされている場合は永久にループから抜けられなくなります**（コンソールの場合フリーズすることはないので安心してください）。

### do while 文

while 文の亜種として**do while 文**というものがあります。

do while 文の場合**少なくとも1回は中括弧の中身が実行され**、それから条件式が判定されます。

<pre class="code"><code>using System;
class Program
{
  static void Main()
  {
    int n;
    <strong>do</strong>
    <strong>{</strong>
      n = int.Parse(Console.ReadLine());
    <strong>}</strong>
    <strong>while (n &gt; 0);</strong>
  }
}
</code></pre>

### bool 型

intは整数、doubleは実数、stringは文字列を扱う型でしたが、**bool**は**論理値（真／偽）**を扱う型です。
boolには**true, false**のいずれかが格納されます（文字列の"true", "false"とは異なります）。
if 文やwhile 文は条件式がtrueである時に実行されます。

<pre class="code"><code>using System;
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
</code></pre>

### 複合代入演算子

`n = n + 1`のような処理は頻繁に出現するのでより短く書く方法が用意されています（`+=`のような演算子を**複合代入演算子**と呼びます）。

<pre class="code"><code>using System;
class Program
{
  static void Main()
  {
    int x = 0;
    <strong>x += 4;</strong>  // x = x + 4
    Console.WriteLine(x);
    <strong>x -= 2;</strong>  // x = x - 2
    Console.WriteLine(x);
    <strong>x *= 3;</strong>  // x = x * 3
    Console.WriteLine(x);
    <strong>x /= 2;</strong>  // x = x / 2
    Console.WriteLine(x);
  }
}
</code></pre>

### 演習：コラッツ数列表示プログラム

ここまでの知識でコラッツの問題（[Wikipedia](http://ja.wikipedia.org/wiki/%E3%82%B3%E3%83%A9%E3%83%83%E3%83%84%E3%81%AE%E5%95%8F%E9%A1%8C)）の数列を表示するプログラムを書いてみましょう（できるだけ自力でやりましょう）。

コラッツの問題については以下の通り（Wikipediaより引用）。
<blockquote>問題の概要は、「任意の0でない自然数<var>n</var>をとり、<ul><li><var>n</var>が偶数の場合、<var>n</var>を 2 で割る</li><li><var>n</var>が奇数の場合、<var>n</var>に 3 をかけて 1 を足す</li>
</ul>
という操作を繰り返すと、有限回で 1 に到達する」という主張である（1 に到達すると、1→4→2→1 を繰り返す）。</blockquote>
例えば3と入力すると、
<pre class="sample"><samp>3
10
5
16
8
4
2
1</samp></pre>
と表示するようなプログラムを作りましょう。
