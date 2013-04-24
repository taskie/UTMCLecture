#!/usr/local/bin/ruby
# -*- coding: utf-8 -*-

require 'rexml/document'

PAGE_BEGIN = 1
PAGE_END = 10

def main()
  (PAGE_BEGIN .. PAGE_END).each do |i|
    name = i.to_s
    Dir::mkdir(name) unless Dir::exist?(name)
    File::open("#{name}/index.md", "w") do |outFile|
      File::open("src/#{name}/index.md") do |inFile|
        inFile.each do |line|
          if line =~ /^<<</
            path = "src/#{name}/#{line.gsub('<<<', '').strip}" #

            outFile.print "<pre class=\"code\"><code>"
            File::open(path) do |codeFile|
              outFile.puts codeFile.read.strip
            end
            outFile.puts "</code></pre>"
          else
            outFile.puts line
          end
        end
      end 
    end
    
    document = createXHTML(name)
    File::open("#{name}/index.htm", "w") do |outFile|
      outFile.puts document
    end
  end
end

def createXHTML(name)
  bodyString = `pandoc #{name}/index.md -f markdown -t html`
  bodyString = "<body>#{bodyString}</body>"
  body = REXML::Document.new(bodyString).root
  
  document = REXML::Document.new
  document << REXML::XMLDecl.new('1.0', 'utf-8')
  document << REXML::DocType.new('html')
  
  html = document.add_element("html",
                              {"xmlns" => "http://www.w3.org/1999/xhtml"})
  head = html.add_element("head")
  
  h1Text = body.elements["h1"].text
  h2Text = body.elements["h2"].text
  head.add_element("title").add_text("#{h2Text} - #{h1Text}")
  head.add_element("link", {
                     "rel" => "stylesheet",
                     "href" => "../common/common.css",
                     "type" => "text/css"
                   })
  head.add_element("script", {
                     "src" => "../common/jquery-1.7.2.min.js",
                     "type" => "text/javascript"
                   }).add_text('')
  head.add_element("script", {
                     "src" => "../common/common.js",
                     "type" => "text/javascript"
                   }).add_text('')
  
  nav = REXML::Element.new('nav')
  nav.add_element("a", {"href" => "../index.htm"}).add_text(h1Text)
  nav.add_text(" » (")
  prevPage = name.to_i - 1
  nextPage = name.to_i + 1
  prevText = "< prev"
  nextText = "next >"
  if prevPage >= PAGE_BEGIN
    nav.add_element("a", {"href" => "../#{prevPage}/index.htm"}).add_text(prevText)
  else
    nav.add_text(prevText)
  end
  nav.add_text(" ")
  if nextPage <= PAGE_END
    nav.add_element("a", {"href" => "../#{nextPage}/index.htm"}).add_text(nextText)
  else
    nav.add_text(nextText)
  end
  nav.add_text(") #{h2Text}")

  newBody = REXML::Element.new('body')
  newBody.add_element(nav)
  body.each { |e| newBody.add_element(e) }
  newBody.add_element(nav)
  html.add_element(newBody)

  return document
end

main()
