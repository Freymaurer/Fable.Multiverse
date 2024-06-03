namespace ProjectNameVar.CSharp;

using ProjectNameVar.CSharp.Util;


public class Main
{
    public static void Hello(string name, Optional<string> from = default)
    {
        ProjectNameVar.Main.hello(name, from.ToOption());
    }
    public static void PrintTuples((string,string)[] tuples)
    {
        ProjectNameVar.Main.printTuples(tuples.Select(t => t.ToTuple()));
    }
} 
