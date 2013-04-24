# C#プログラミング講習会

## 3. コンソールへの入力を受け取る

### 文字列型変数に入力結果を代入する

まずは下のコードを入力してください。

<pre class="code"><code>class Program
{
  static void Main()
  {
    string s = <strong>System.Console.ReadLine</strong>();
    System.Console.WriteLine("Hello, " + s + "!");
  }
}
</code></pre>

実行すると、コンソール上のカーソルが点滅した状態（入力待ち状態）になるはずです。
そこで、自分の名前を入力してEnterを押してみましょう。

`System.Console.ReadLine()`はコンソールからの入力を受け取る部分で、
その入力が文字列型変数<var>s</var>に代入されています。

### 整数・実数型変数に入力結果を代入する

`System.Console.ReadLine()`の結果は文字列なので、
int型・double型の変数に直接入れることはできません。
文字列をintやdoubleに変換してやる必要があります。

<pre class="code"><code>class Program
{
  static void Main()
  {
    int x = <strong>int.Parse</strong>(System.Console.ReadLine());
    System.Console.WriteLine(x * x);

    double y = <strong>double.Parse</strong>(System.Console.ReadLine());
    System.Console.WriteLine(1 / y);
  }
}
</code></pre>

重要なのは**`int.Parse`**と**`double.Parse`**で、
この括弧の中に文字列を入れると整数や実数に変換してくれます。

### System.Console.WriteLine, System.Console.ReadLineって長い

ところで、一々`System.Console.WriteLine`という長ったらしい名前を打ち込むのは面倒です。**using ディレクティブ**を使うことでこの負担を軽減することができます。

<pre class="code"><code><strong>using System;</strong>
class Program
{
  static void Main()
  {
    double x = double.Parse(<strong>Console.ReadLine</strong>());
    <strong>Console.WriteLine</strong>(1 / x);
  }
}
</code></pre>

先頭に`using System;`を加えると、以降はSystemを省略できるようになります。

### System.Console.WriteLineの便利な機能

System.Console.WriteLineには**フォーマット出力**という機能があります。

<pre class="code"><code>using System;
class Program
{
  static void Main()
  {
    int m = int.Parse(Console.ReadLine());
    int n = int.Parse(Console.ReadLine());
    <strong>Console.WriteLine("{0}+{1}={2}, {0}*{1}={3}", m, n, m + n, m * n);</strong>
  }
}
</code></pre>

表示文字列に**{<var>数字</var>}**と書くことで、後ろの対応する値をそこに埋め込むことができます（上の例の場合、{0}にm、{1}にn、{2}にm+n、{3}にm*nの値が埋め込まれます）。

### 演習：西暦→和暦変換プログラムを作る

Console.ReadLineとint.Parseを利用して、西暦を入力したら平成何年かを表示してくれるプログラムを作りましょう（元年は1年とみなして良いです）。

西暦から1988を引くと平成になります
（ちなみに1867・1911・1925を引くとそれぞれ明治・大正・昭和になります。例えば今年は明治・大正・昭和ではそれぞれ何年相当なのかを表示するプログラムを作っても面白いかも）。
