using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class GeneratorTester : MonoBehaviour
{
    public int coinMin = 5;
    public int coinMax = 25;
    public int coinNumber = 5;
    public int maxSolutionValue = 80;

    [ContextMenu("Generate")]
    public void Generate()
    {
        SolutionGenerator solutionGenerator = new SolutionGenerator();

        // int coinDiap = 20;
        // int coinNumber = 5;
        // int maxSolutionValue = 80;

        //solutionGenerator.GenerateSolution(coinDiap, coinNumber, maxSolutionValue);
        var chosenCoins = solutionGenerator.GenerateCoinsFromDiap(coinMin, coinMax, coinNumber);
        List<int>[] allSolutions = solutionGenerator.FindAllSolutions(chosenCoins, maxSolutionValue);

        LogAllSolutions(allSolutions);
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

        Debug.Log(builder.ToString());
    }
}
