using System;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;

public class SolutionGenerator
{
    private int _coinMin;
    private int _coinMax;
    private int _coinNumber;
    private int _maxSolutionValue;

    public SolutionGenerator()
    {

    }

    public SolutionGenerator(int coinMin, int coinMax, int coinNumber, int maxSolutionValue)
    {
        SetSettings(coinMin, coinMax, coinNumber, maxSolutionValue);
    }

    public void SetSettings(int coinMin, int coinMax, int coinNumber, int maxSolutionValue)
    {
        _coinMin = coinMin;
        _coinMax = coinMax;
        _coinNumber = coinNumber;
        _maxSolutionValue = maxSolutionValue;
    }

    public (List<int>, List<Solution>) GenerateSolutions()
    {
        List<int> allCoins = GenerateCoinsFromDiap(_coinMin, _coinMax, _coinNumber);

        List<Solution> allSolutions = FindAllSolutionsNew(allCoins, _maxSolutionValue);

        return (allCoins, allSolutions);
    }

    public List<Solution> FindAllSolutionsNew(List<int> coins, int _maxSolutionValue)
    {
        Solution[] allSolutions = new Solution[_maxSolutionValue+1];

        for(int i = 0; i < _maxSolutionValue + 1; ++i)
            allSolutions[i] = new Solution(i);

        for(int i = 1; i <= _maxSolutionValue; ++i)
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

        List<Solution> solves = new List<Solution>();

        foreach(var s in allSolutions)
        {
            if(s.HasSolution && s.DifferentLegnghts.Count >= 3)
            {
                solves.Add(s);
                s.Coins = new List<int>(coins);
            }
        }

        return solves;
    }


    public List<int> GenerateCoinsFromDiap(int _coinMin, int _coinMax, int _coinNumber)
    {
        int curCoin = _coinMin;

        int[] coins = new int[_coinMax - _coinMin];

        while(curCoin < _coinMax)
            coins[curCoin - _coinMin] = curCoin++;

        Shuffle(coins);

        curCoin = 0;
        List<int> chosenCoins = new List<int>();

        while(curCoin < _coinNumber)
        {
            int cn = coins[curCoin++];

            // bool notValid = false;

            // foreach(var c1 in chosenCoins)
            // {
            //     if(notValid)
            //         break;

            //     foreach(var c2 in chosenCoins)
            //         if(cn == c1 + c2 || c1 == cn + c2 || c2 == c1 + cn)
            //         {
            //             notValid  = true;
            //             break;
            //         }
            // }

            // if(notValid)
            //     continue;

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
