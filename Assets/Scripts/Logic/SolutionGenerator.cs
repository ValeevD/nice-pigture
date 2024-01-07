using System;
using System.Collections;
using System.Collections.Generic;

public class SolutionGenerator
{
    public List<Solution> allSolutions;
    public List<int> allCoins;

    public void GenerateSolutions(int coinMin, int coinMax, int coinNumber, int maxSolutionValue)
    {
        allCoins = GenerateCoinsFromDiap(coinMin, coinMax, coinNumber);

        allSolutions = FindAllSolutionsNew(allCoins, maxSolutionValue);
    }

    public List<Solution> FindAllSolutionsNew(List<int> coins, int maxSolutionValue)
    {
        Solution[] allSolutions = new Solution[maxSolutionValue+1];

        for(int i = 0; i < maxSolutionValue + 1; ++i)
            allSolutions[i] = new Solution(i);

        for(int i = 1; i <= maxSolutionValue; ++i)
        {
            Solution curSolution = allSolutions[i];

            foreach(int coin in coins)
            {
                if(coin == i){
                    curSolution.AddSolutionWithOneCoin(coin);
                    continue;
                }

                int curSum = i - coin;

                if(curSum < 1 || !allSolutions[curSum].HasSolution)
                    continue;

                curSolution.FillFromSolutionWithCoin(allSolutions[curSum], coin);
            }

            curSolution.CutSolution();
        }

        List<Solution> solves = new List<Solution>(allSolutions);
        return solves;
    }


    public List<int> GenerateCoinsFromDiap(int coinMin, int coinMax, int coinNumber)
    {
        int curCoin = coinMin;

        int[] coins = new int[coinMax - coinMin];

        while(curCoin < coinMax)
            coins[curCoin - coinMin] = curCoin++;

        Shuffle(coins);

        curCoin = 0;
        List<int> chosenCoins = new List<int>();

        while(curCoin < coinNumber)
        {
            int cn = coins[curCoin++];
            // if(cn != 2 && cn != 5)
            chosenCoins.Add(cn);
        }

        return chosenCoins;
    }

    public static void Shuffle<T> (T[] array)
    {
        Random rng = new Random();

        int n = array.Length;
        while (n > 1)
        {
            int k = rng.Next(n--);
            (array[k], array[n]) = (array[n], array[k]);
        }
    }
}
