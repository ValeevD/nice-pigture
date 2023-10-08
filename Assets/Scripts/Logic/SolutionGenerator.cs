using System;
using System.Collections;
using System.Collections.Generic;

public class SolutionGenerator
{
    public Solution GenerateSolution(int coinMin, int coinMax, int coinNumber, int maxSolutionValue)
    {
        List<int> chosenCoins = GenerateCoinsFromDiap(coinMin, coinMax, coinNumber);

        List<int>[] allSolutions = FindAllSolutions(chosenCoins, maxSolutionValue);

        return null;
    }

    public List<int>[] FindAllSolutions(List<int> coins, int maxSolutionValue)
    {
        List<int>[] allSolutions = new List<int>[maxSolutionValue+1];

        for(int i = 0; i < maxSolutionValue + 1; ++i)
            allSolutions[i] = new List<int>();

        for(int i = 1; i <= maxSolutionValue; ++i)
        {
            int bestCoinNumber = maxSolutionValue + 1;
            int usedSolution = -1;
            int usedCoin = 0;

            foreach(int coin in coins)
            {
                if(coin == i){
                    bestCoinNumber = 1;
                    usedCoin = coin;
                    break;
                }

                int curSum = i - coin;

                if(curSum < 1 || allSolutions[curSum].Count == 0)
                    continue;

                if(allSolutions[curSum].Count + 1 < bestCoinNumber)
                {
                    usedSolution = curSum;
                    usedCoin = coin;
                    bestCoinNumber = allSolutions[curSum].Count + 1;
                }
            }

            if(usedCoin == 0)
                continue;

            List<int> curSol = allSolutions[i];

            if(bestCoinNumber != 1)
                foreach(int n in allSolutions[usedSolution])
                    curSol.Add(n);

            curSol.Add(usedCoin);
        }

        return allSolutions;
    }


    public List<int> GenerateCoinsFromDiap(int coinMin, int coinMax, int coinNumber)
    {
        int curCoin = coinMin;

        int[] coins = new int[coinMax - coinMin + 2];

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
