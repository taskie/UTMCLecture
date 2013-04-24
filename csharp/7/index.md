# C#プログラミング講習会

## 7. 続・処理を繰り返させる

### インクリメント演算子・デクリメント演算子

`n += 1`・`n -= 1`という処理は頻繁に出てくるので短く書く方法が用意されています。

<pre class="code"><code>using System;
class Program
{
  static void Main()
  {
    int x = 0;
    <strong>x++;</strong>  // x += 1
    Console.WriteLine(x);
    <strong>x--;</strong>  // x -= 1
    Console.WriteLine(x);
    <strong>++x;</strong>  // x += 1
    Console.WriteLine(x);
    <strong>--x;</strong>  // x -= 1
    Console.WriteLine(x);
  }
}
</code></pre>

`x++`（後置インクリメント）と`++x`（前置インクリメント）の違いは`x++`,`++x`という式自体の値を参照する時に現れます。

<pre class="code"><code>using System;
class Program
{
  static void Main()
  {
    int x;
    x = 0;
    Console.WriteLine(<strong>x++</strong>);
    Console.WriteLine(x);
    x = 0;
    Console.WriteLine(<strong>++x</strong>);
    Console.WriteLine(x);
  }
}
</code></pre>

`x++`の値は+1する前の`x`の値、`++x`は+1した後の`x`の値です
（x--, --x も同様）。ただこういうことをする機会はそんなに無いのであまり気にしなくていいかも。

### for 文

n回何らかの処理を繰り返したい、という時はwhile文を使って以下のように書けます（<var>i</var>は0からn-1までのn通りの値をとる）。

<pre class="code"><code>using System;
class Program
{
  static void Main()
  {
    int n = int.Parse(Console.ReadLine());
    <strong>int i = 0;</strong>
    <strong>while (i &lt; n)</strong>
    {
      Console.WriteLine(i);
      <strong>i++;</strong>
    }
  }
}
</code></pre>

こういう形はよく出てくるので上の太字部分をまとめた構文が存在します。

<pre class="code"><code>using System;
class Program
{
  static void Main()
  {
    int n = int.Parse(Console.ReadLine());
    <strong>for (int i = 0; i &lt; n; i++)</strong>
    {
      Console.WriteLine(i);
    }
  }
}
</code></pre>

`for (<var>初期化式</var>;<var>条件式</var>;<var>増分</var>)`という順番です。

例えば、<var>i</var>が<var>n</var>から0まで2ずつ減っていく処理なら以下のように書けます。

<pre class="code"><code>using System;
class Program
{
  static void Main()
  {
    int n = int.Parse(Console.ReadLine());
    <strong>for (int i = n; i &gt;= 0; i -= 2)</strong>
    {
      Console.WriteLine(i);
    }
  }
}
</code></pre>

### break 文

while, for文を抜ける方法として、**break**というものが用意されています。

<pre class="code"><code>using System;
class Program
{
  static void Main()
  {
    int n = int.Parse(Console.ReadLine());
    for (int i = 0; i &lt; n; i++)
    {
      <strong>if (i == 5) break;</strong>
      Console.WriteLine(i);
    }
  }
}
</code></pre>

上の例の場合、<var>i</var>が5になったら強制的にループを抜けます（ちなみに、if, while, for 文の後の中括弧の中に1文しか無い場合は中括弧を省略できます。が、紛らわしいので簡単な処理にだけ使うようにしましょう）。

### continue 文

特定の条件でループを飛ばしたい場合は**continue**を使います。

<pre class="code"><code>using System;
class Program
{
  static void Main()
  {
    int n = int.Parse(Console.ReadLine());
    for (int i = 0; i &lt; n; i++)
    {
      <strong>if (i % 2 == 0) continue;</strong>
      Console.WriteLine(i);
    }
  }
}
</code></pre>

上の例の場合、<var>i</var>が偶数なら表示の処理を行わずループの最初に戻ります。for 文の場合**増分の処理（ここでは`i++`）はcontinueした直後に実行されます**。

### 無限ループ

**`for ( ; ; )`**と書くことで無限ループを作ることができます。
その名の通り永久に終わらないのでbreak 文でループを中断する必要があります。

<pre class="code"><code>using System;
class Program
{
  static void Main()
  {
    int n = 0;
    Console.WriteLine("入力された整数を合計します（0を入力すると終了します）")
    <strong>for ( ; ; ) {</strong>
      int x = int.Parse(Console.ReadLine());
      if ( x == 0 ) break;
      n += x;
    <strong>}</strong>
    Console.WriteLine("合計：{0}", n);
  }
}
</code></pre>

`while (true) { ... }`でも同じことができます。

### 演習：Fizz Buzz表示プログラム

for 文を使ってFizz Buzz ([Wikipedia](http://ja.wikipedia.org/wiki/Fizz_Buzz)) を行うプログラム作りましょう。

Fizz Buzzのルールは以下のとおり。
<ul><li>最初のプレイヤーは**1**と数字を発言する。</li><li>次のプレイヤーは直前のプレイヤーの次の数字を発言していく。</li><li>ただし、<ul><li>3で割り切れる場合は**Fizz**</li><li>5で割り切れる場合は**Buzz**</li><li>両者で割り切れる場合は**FizzBuzz**</li>
</ul>
を数の代わりに発言しなければならない。</li>
</ul>

入力された数までFizz Buzzを行うプログラムを書いてみましょう。例えば、<kbd>16</kbd>と入力すると、
<pre class="sample"><samp>1
2
Fizz
4
Buzz
Fizz
7
8
Fizz
Buzz
11
Fizz
13
14
FizzBuzz
16</samp></pre>
と表示するようなプログラムを書きましょう。

ちなみに、Fizz Buzzはプログラマの中では非常に有名な問題です。以下Wikipediaより引用。
<blockquote>このゲームをコンピュータ画面に表示させるプログラムとして作成させることで、**コードがかけないプログラマ志願者を見分ける手法**を Jeff Atwood が FizzBuzz問題 (FizzBuzz Question)として提唱した。その提唱はインターネットの様々な場所で議論の対象になっている。</blockquote>
逆に言うと、Fizz Buzzさえ書ければコードが書ける人として見なされるかも……？　頑張って書いてみましょう。

### [こぼれ話](javascript:showKobore();)

<div class="kobore">

「for 文」で出てきた2つのコード（while 文バージョン／for 文バージョン）の大きな違いは、ループ回数をカウントしている<var>i</var>をループの後で参照できるかどうかという点です。

while 文バージョンでは変数<var>i</var>の値を後で参照することができますが、for 文で同じことをしようとするとVisual Studioに怒られます。

<pre class="code"><code>using System;
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
</code></pre>

C#には**スコープ**（変数の有効範囲）という概念があります。**中括弧**（if, while, for 文の中括弧も同じ働き）を使うとスコープを明示することができ、**中括弧の内側で宣言した変数の内容を外側で読むことができなくなります。**

<pre class="code"><code>using System;
class Program
{
  static void Main()
  {
    <strong>{</strong>
      int x = 127;
      Console.WriteLine(x); // 表示される
    <strong>}</strong>
    // Console.WriteLine(x); ←エラー
  }
}
</code></pre>

**for 文の初期化部で宣言した変数は中括弧の内側で宣言したものとして扱われます。**だからfor文の外側で変数の値を参照できなかったという訳です。

</div>
