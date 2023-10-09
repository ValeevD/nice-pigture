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

        // solutionGenerator.GenerateSolution(coinDiap, coinNumber, maxSolutionValue);
        var chosenCoins = solutionGenerator.GenerateCoinsFromDiap(coinMin, coinMax, coinNumber);
        // List<int> chosenCoins = new List<int>();

        // chosenCoins.Add(8);
        // chosenCoins.Add(7);
        // chosenCoins.Add(4);

        Solution[] allSolutions = solutionGenerator.FindAllSolutionsNew(chosenCoins, maxSolutionValue);

        Debug.Log($"Coins {LogList(chosenCoins)}");
        LogAllSolutions(allSolutions);

        // Solution sol = new Solution(5);

        // List<int> s1 = new List<int>();
        // s1.Add(1);
        // s1.Add(2);
        // s1.Add(2);

        // List<int> s2 = new List<int>();
        // s2.Add(2);
        // s2.Add(2);
        // s2.Add(1);

        // List<int> s3 = new List<int>();
        // s3.Add(2);
        // s3.Add(1);
        // s3.Add(2);

        // List<int> s4 = new List<int>();
        // s4.Add(3);
        // s4.Add(2);

        // sol.Sequences.Add(s1);
        // sol.Sequences.Add(s2);
        // sol.Sequences.Add(s3);
        // sol.Sequences.Add(s4);

        // Debug.Log("+++BEFORE CUT+++");
        // Debug.Log(sol.ToString());
        // Debug.Log("+++AFTER CUT+++");

        // sol.CutSolution();
        // Debug.Log(sol.ToString());

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

    public void LogAllSolutions(Solution[] allSolutions){
        foreach(var l in allSolutions)
        {
            Debug.Log(l.ToString());
        }
    }
}
