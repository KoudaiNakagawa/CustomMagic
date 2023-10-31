using System.Runtime.Serialization;
using System.Collections.Concurrent;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;
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

    static dynamic TreeParser_RecCal(string[] strLis) {
        
        switch(strLis[0]) {
            case "If"
                if( TreeParser_RecCal(strLis[1]) ) {
                    TreeParser_RecCal(strLis[2]);
                }
                else {
                    try { TreeParser_RecCal(strLis[3]); }
                }
            
            case "For":
                /* どうやって動かそう...
                int i;
                for (i = TreeParser_RecCal(strLis[1]), TreeParser_RecCal(strLis[2]), i++) {
                    TreeParser_RecCal(strLis[3])
                }
                // ドスル・ザビ
                */
                break;
            
            case "Movement":
                //そろそろ; break;
            
            case "Area":
                //魔法作らんと; break;
            
            case "Damage":
                //ここ作れない; break;
            
            case IsArithExpr(strLis[0]):
                ArithExprParser(strLis); break;
            
            case IsLogicExpr(strLis[0]):
                LogicExprParser(strLis); break;
            
            case IsComparExpr(strLis[0]):
                ComparExprParser(strLis); break;
            
            case string strLis[0] when Regex.IsMatch(strLis[0], @"[a-zA-Z][a-zA-Z0-9]*\s*="):
                //どこかに代入; break;
            
            default:
                Console.WriteLine("Syntax Error"); break;
        }
        
        //s = s[1:]

        return TreeParser_RecCal(s);
    }

    
    string ArithOpers = @"[+-*/%]"
    string LogicOpers = @"[&|!]"
    string ComparOpers = @"==|<=|>=|!=|[<>]"
    
    static bool IsArithExpr(string s) {
        return 0 < Regex.Match(s, ArithOpers).Count() & 0 == Regex.Match(s, LogicOpers+ComparOpers).Count() 
    }
    static int ArithExprParser(string s) {

    }

    static bool IsLogicExpr(string s) {
        return 0 < Regex.Match(s, LogicOpers).Count() & 0 == Regex.Match(s, LogicOpers+ComparOpers).Count() 
    }
    static bool LogicExprParser(string s) {
        
    }

    static bool IsComparExpr(string s) {
        return 0 < Regex.Match(s, ComparOpers).Count() 
    }
    static bool ComparExprParser(string s) {
        
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
