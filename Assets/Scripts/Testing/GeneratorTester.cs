using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class GeneratorTester: MonoBehaviour
{
    public int coinMin = 5;
    public int coinMax = 25;
    public int coinNumber = 5;
    public int maxSolutionValue = 120;

    [ContextMenu("Generate")]
    public void Generate()
    {
        // var chosenCoins = solutionGenerator.GenerateCoinsFromDiap(coinMin, coinMax, coinNumber);

        SolutionGenerator solutionGenerator = new SolutionGenerator(coinMin, coinMax, coinNumber, maxSolutionValue);
        (List<int>, List<Solution>) solutionPair = solutionGenerator.GenerateSolutions();
        Debug.Log($"Coins {LogList(solutionPair.Item1)}");
        LogAllSolutions(solutionPair.Item2);
    }

    public static string LogList<T>(List<T> list)
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

    public static void LogAllSolutions(List<int>[] allSolutions)
    {
        StringBuilder builder = new StringBuilder();
        int sum = 0;

        foreach(var l in allSolutions)
        {
            builder.Append($"-------------Target: {sum++}-------------\n");
            builder.Append(LogList(l));
            builder.Append("\n");
        }

        Debug.Log(builder.ToString());
    }

    public static void LogAllSolutions(List<Solution> allSolutions){
        foreach(var l in allSolutions)
        {
            Debug.Log(l.ToString());
        }
    }
}
