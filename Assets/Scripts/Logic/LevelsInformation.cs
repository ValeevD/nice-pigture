using System;
// using System.Collections;
using System.Collections.Generic;
// using UnityEngine;

public class LevelsInformation
{
    struct GenSettings
    {
        public int coinsCount;
        public int minCoin;
        public int maxCoin;
        public int lvlCount;
        public int levelSum;

        public GenSettings(int _coinsCount, int _minCoin, int _maxCoin, int _lvlCount, int _levelSum)
        {
            coinsCount = _coinsCount;
            minCoin = _minCoin;
            maxCoin = _maxCoin;
            lvlCount = _lvlCount;
            levelSum = _levelSum;
        }
    }

    private SolutionGenerator? _generator;

    //[ContextMenu("Show Level")]
    public void ShowLevel()
    {
        _generator = new SolutionGenerator();

        int bestLen = 0;
        int bestDifCoins = 0;

        List<GenSettings> generatorSettings = new List<GenSettings>();
        generatorSettings.Add(new GenSettings(3, 5, 15, 5, 30));//4-3
        generatorSettings.Add(new GenSettings(4, 5, 20, 10, 40));//4-4
        generatorSettings.Add(new GenSettings(5, 5, 30, 10, 60));//5-5
        generatorSettings.Add(new GenSettings(6, 5, 35, 10, 90)); //5-5
        generatorSettings.Add(new GenSettings(7, 10, 40, 10, 130)); //5-5
        generatorSettings.Add(new GenSettings(8, 15, 50, 10, 200));
        generatorSettings.Add(new GenSettings(9, 20, 70, 10, 230));

        for(int k = 0; k < generatorSettings.Count; ++k)
        {
            GenSettings set = generatorSettings[k];
            Console.WriteLine($"----------------LEVEL {k + 3} ----------------");

            for(int x = 0; x < set.lvlCount; ++x)
            {
                int n = 500;
                Solution? bestSolution = null;
                bestLen = 0;
                bestDifCoins = 0;

                while(n-- > 0)
                {
                    int currentSum = set.levelSum + 5 * x;
                    _generator.SetSettings(set.minCoin, set.maxCoin, set.coinsCount, currentSum);

                    (List<int>, List<Solution>) solutionInformation = _generator.GenerateSolutions();

                    int sum = 0;

                    foreach(var q in solutionInformation.Item1)
                        sum += q;

                    foreach(var s in solutionInformation.Item2)
                    {
                        if(s == null)
                            continue;

                        if(s.Sum == sum)
                            continue;

                        if(s.HasSolution && s.DifferentLegnghts.Count >= 3 && s.bestLen >= bestLen && s.bestDifCoins > bestDifCoins)
                        {
                            bestSolution = s;
                            bestLen = s.bestLen;
                            bestDifCoins = s.bestDifCoins;
                        }
                    }

                    if(n==0 && bestSolution == null)
                        n = 200;
                }


                if(bestSolution != null)
                {
                    //Console.WriteLine($"Sub level: {x + 1} \n Coins {GeneratorTester.LogList(bestSolution.Coins)} \n bestlen = {bestSolution.bestLen}, bestDifCoins = {bestSolution.bestDifCoins} \n {bestSolution.ToString()}");
                    Console.WriteLine($"Sub level: {x + 1} \n {bestSolution.LvlSettingsToString()}");
                }
            }
        }

    }
}
