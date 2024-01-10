using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

public class GeneratorTester
{
    public int coinMin = 5;
    public int coinMax = 25;
    public int coinNumber = 5;
    public int maxSolutionValue = 120;

    public GeneratorTester()
    {
    }

    //[ContextMenu("Generate")]
    public void Generate()
    {
        // var chosenCoins = solutionGenerator.GenerateCoinsFromDiap(coinMin, coinMax, coinNumber);

        SolutionGenerator solutionGenerator = new SolutionGenerator(coinMin, coinMax, coinNumber, maxSolutionValue);
        (List<int>, List<Solution>) solutionPair = solutionGenerator.GenerateSolutions();
        Console.WriteLine($"Coins {LogList(solutionPair.Item1)}");
        LogAllSolutions(solutionPair.Item2);
    }

    public string LogList<T>(List<T> list)
    {
        StringBuilder builder = new StringBuilder();

        builder.Append("");

        foreach(T n in list)
        {
            builder.Append(n.ToString());
            builder.Append('\t');
        }

        return builder.ToString();
    }

    public void LogAllSolutions(List<int>[] allSolutions)
    {
        StringBuilder builder = new StringBuilder();
        int sum = 0;

        foreach(var l in allSolutions)
        {
            builder.Append($"-------------Target: {sum++}-------------\n");
            builder.Append(LogList(l));
            builder.Append("\n");
        }

        Console.WriteLine(builder.ToString());
    }

    public void LogAllSolutions(List<Solution> allSolutions){
        foreach(var l in allSolutions)
        {
            Console.WriteLine(l.ToString());
        }
    }
}
