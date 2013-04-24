var keywords = [
  "class", "static", "void", "int", "double", "byte", "float", "string", "if", "else", "for", "while", "switch", "case", "default", "const", "do", "break", "continue", "bool", "true", "false", "return", "using", "new", "foreach", "in"
];

var classes = [
  "Console", "Program", "Random"
];

$(function(){
  coloring();
  $(".kobore").hide();
});

function showKobore(){
  $(".kobore").slideToggle();
}

function coloring(){
  var codes = $(".code > code");
  codes.bind("copy", function(){return false;});
  for (var i = 0; i < codes.length; i++) {
    var code = $(codes[i]);
    var s = colorBlockComment(code.html());
    code.html(s);
  }
}

function colorBlockComment(s){
  var ss = s.split(/\/\*|\*\//);
  for (var i = 0; i < ss.length; i++) {
    if (i % 2 == 0) {
      ss[i] = colorLine(ss[i]);
    } else {
      ss[i] = "<span class=\"comment\">/*" + ss[i] + "*/</span>";
    }
  }
  return ss.join("");
}

function colorLine(s){
  var ss = s.split("\n");
  for (var i = 0; i < ss.length; i++) {
    ss[i] = colorLineComment(ss[i]);
  }
  return ss.join("\n");
}

function colorLineComment(s){
  var ss = s.split("//");
  for (var i = 0; i < ss.length; i++) {
    if (i % 2 == 0) {
      ss[i] = colorString(ss[i]);
    } else {
      ss[i] = "<span class=\"comment\">//" + ss[i] + "</span>";
    }
  }
  return ss.join("");
}

function colorString(s){
  var ss = s.split("\"");
  for (var i = 0; i < ss.length; i++) {
    if (i % 2 == 0) {
      ss[i] = colorKeyword(ss[i]);
    } else {
      ss[i] = "<span class=\"string\">\"" + ss[i] + "\"</span>";
    }
  }
  return ss.join("");
}

function colorKeyword(s){
  for (var l = 0; l < keywords.length; l++) {
    s = s.replace(new RegExp("\\b" + keywords[l] + "\\b", "g"), "<span class=\"keyword\">"+keywords[l]+"</span>");
  }
  for (var l = 0; l < classes.length; l++) {
    s = s.replace(new RegExp("\\b" + classes[l] + "\\b", "g"), "<span class=\"classname\">"+classes[l]+"</span>");
  }
  return s;
}
