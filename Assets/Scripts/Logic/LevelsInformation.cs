using System;
// using System.Collections;
// using System.Collections.Generic;
//using UnityEngine;

public class LevelsInformation
{
    private SolutionGenerator? _generator;

    //[ContextMenu("Show Level")]
    public void ShowLevel()
    {
        _generator = new SolutionGenerator(5, 15, 3, 60);
        Solution? bestSolution = null;
        int bestLen = 0;
        int bestDifCoins = 0;

        //for(int i = 0; i < 10000; ++i)
        int n = 5000;

        while(n-- > 0)
        {
            (List<int>, List<Solution>) solutionInformation = _generator.GenerateSolutions();

            // bestLen = 0;
            // bestDifCoins = 0;

            foreach(var s in solutionInformation.Item2)
            {
                // if(s.HasSolution && s.DifferentLegnghts.Count >= 2 && s.bestLen + s.bestDifCoins > bestLen)
                // {
                //     bestSolution = s;
                //     bestLen = s.bestLen + s.bestDifCoins;
                // }

                if(s.HasSolution && s.DifferentLegnghts.Count >= 2 && s.bestLen >= bestLen && s.bestDifCoins > bestDifCoins)
                // if(s.HasSolution && s.DifferentLegnghts.Count >= 2 && s.bestDifCoins > bestDifCoins)
                {
                    bestSolution = s;
                    bestLen = s.bestLen;
                    bestDifCoins = s.bestDifCoins;
                }
            }

            // if (bestLen + bestDifCoins >= 9 && bestSolution != null)
            // {
            //     Console.WriteLine($"bestlen = {bestSolution.bestLen}, bestDifCoins = {bestSolution.bestDifCoins}");
            //     break;
            // }
        }

        Console.WriteLine($"bestlen = {bestSolution.bestLen}, bestDifCoins = {bestSolution.bestDifCoins}");

        if(bestSolution != null)
        {
            Console.WriteLine($"Coins {GeneratorTester.LogList(bestSolution.Coins)}");
            Console.WriteLine(bestSolution.ToString());
        }
    }
}
