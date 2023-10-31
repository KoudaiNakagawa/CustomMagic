using System.Runtime.Serialization;
using System.Collections.Concurrent;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;
//using System.Data;
using Internal;
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
            MatchCollection results = Regex.Matches(text,  @"[a-zA-Z][a-zA-Z0-9]*|[1-9][0-9]*|0[0-1]|==|<=|>=|!=|[=+*-/%()<>!&\,|\\s\\t\\]" );

            foreach (Match m in results) {
                string s = m.Value;
            
                Console.Write(s + " ");
            }
            Console.WriteLine();
        }

        Console.WriteLine();

        foreach( string text in textList) {
            MatchCollection results2 = Regex.Matches(text, @"[^\(\)]+(?=\([^\(\)]+\))|[^\(\)]+$|^[^\(\)]+");

            foreach (Match m in results2) {
                string s = m.Value;
            
                Console.Write(s + " ");
            }
            Console.WriteLine();
        }
    }

    static dynamic TreeParser_RecCal(string s) {
        //string s0 = s[0];
        
        switch(s0) {
            case "If":
                //; break;
            case "For":
                //; break;
            case "Movement":
                //; break;
            case "Area":
                //; break;
            case "Damage":
                //; break;
            case string s0 when Regex.IsMatch(s0, @"[a-zA-Z][a-zA-Z0-9]*\s*="):
                //; break;
            default:
                Console.WriteLine("Syntax Error"); break;
        }
        
        //s = s[1:]

        return TreeParser_RecCal(s);
    }

    string[] ArithOper = new string[5]{"+", "-", "*", "/", "%"};
    
    static int ArithExprParser(string s) {
        Regex.Match(s, @"[+-*/%]")
    }

    string[] LogicOper = [3]{"&", "|", "!"};

    static bool BoolExprParser(string s) {
        
    }

    string[] ComparExpr = new string[6]{ "<", ">", "<=", ">=", "==", "!=" };
    static bool ComparxprParser(string s) {
        
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
