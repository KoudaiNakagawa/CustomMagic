using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;

public class test1
{
    public static void Main() {

        string path = @"./test1.sl";
        var textList = ReadFile(path);

        SimpLang(textList);
    }

    static List<string> ReadFile(string path) {
        var textList = new List<string>(File.ReadAllLines(path));
        return textList;
    }

    static void SimpLang(List<string> textList) {
        
        foreach( string text in textList) {
            MatchCollection results = Regex.Matches(text,  @"[a-zA-Z][a-zA-Z0-9]*| [1-9][0-9]* | 0[0-1] | ==| <=| >=| !=| [=+*-/%()<>!&\,|\\s\\t\\]" );
        
            foreach (Match m in results) {
                string s = m.Value;
            
                Console.Write(s + " ");
            }
            Console.WriteLine();
        }
    }

    /*
    static void UsePythonFunctions(List<string> textList) {
        
        foreach( string text in textList) {
            MatchCollection results = Regex.Matches(text,  @"[a-zA-Z][a-zA-Z0-9]*|[0-9]+|==|\*\*|:=|::|[=+*-/%()\[\]{}<>'.,:#\\s\\t\\]" );
        
            foreach (Match m in results) {
                string s = m.Value;
            
                Console.Write(s + ", ");
            }
            Console.WriteLine();
        }
    }


    // ~~~PythonLikeFunctions~~~

    static string input(string s="", string end="\n") {
        if (s != ""){
            print(s, end);
        }
        return Console.ReadLine();
    }

    static void print(dynamic d, string end="\n") { 
        Console.Write(d+end);
    }

    static int intP(dynamic d) {
        return int.Parse(d.ToString());
    }

    */
}
