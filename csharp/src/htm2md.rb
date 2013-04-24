#!/usr/local/bin/ruby

require "rexml/document"

CODE_EXT = 'cs'

def beforeContent(element)
  case element.name
  when 'p'
    return "\n"
  when 'strong'
    return '**'
  when 'a'
    return '['
  when "h1"
    return "# "
  when "h2"
    return "\n## "
  when "h3"
    return "\n### "
  when "code"
    return '`'
  when "img"
    path = File::basename(element.attributes['src'])
    return "![#{element.attributes['alt']}](#{path})"
  when "body"
    return ''
  when "br"
    return '<br />'
  else
    attrs = []
    element.attributes.each{|k, v| attrs << "#{k}=\"#{v}\""}
    if attrs.empty?
      return "<#{element.name}>"
    else
      return "\n<#{element.name} #{attrs.join(' ')}>\n" if ['div', 'ul'].include?(element.name)
      return "<#{element.name} #{attrs.join(' ')}>"
    end
  end
end

def afterContent(element)
  case element.name
  when 'p', 'h1', 'h2', 'h3'
    return "\n"
  when 'strong'
    return '**'
  when 'a'
    return "](#{element.attributes['href']})"
  when "code"
    return '`'
  when "body", "img", "br"
    return ''
  else 
    return "\n</#{element.name}>\n" if ['div', 'ul'].include?(element.name)
    return "</#{element.name}>"
  end
end

def parseXMLRecur(name, elements, string, codes, depth)
  elements.each do |element|
    case element
    when REXML::Element
      if element.name == 'pre' and element.attributes['class'] == 'code'
        string << "\n<<< #{codes.size}.#{CODE_EXT}\n"
        codeArray = element[0].to_s.split("\n")
        codes << codeArray[1, codeArray.size - 2].join("\n")
      elsif element.name == 'nav' or element.name == 'head'
      else
        string << beforeContent(element)
        parseXMLRecur(name, element, string, codes, depth + 1)
        string << afterContent(element)
      end
    when REXML::Text
      string << element.to_s.gsub(/\n\s+/, "\n").strip
    else
    end
  end
  return
end

def parseXML(name, data)
  xml = REXML::Document.new(data)
  string = ""
  codes = []
  parseXMLRecur(name, xml.root, string, codes, 0)
  return {:string => string, :codes => codes}
end

Dir::glob("./*.htm").each do |fileName|
  puts "Parsing #{fileName} ..."
  fileData = ""
  File::open(fileName) do |file|
    fileData = file.read
  end

  name = File::basename(fileName, ".htm").to_i.to_s
  data = parseXML(name, fileData)
  puts data[:string]

  Dir::mkdir(name) unless Dir::exist?(name)
  
  File::open("#{name}/index.md", 'w') do |file|
    file.puts data[:string]
  end
  
  data[:codes].each_index do |index|
    File::open("#{name}/#{index}.#{CODE_EXT}", 'w') do |file|
      file.puts data[:codes][index]
    end
  end
end
