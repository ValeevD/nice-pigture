using System.Collections;
using System.Collections.Generic;

public class Solution
{
    public int Sum;
    public int MinCoinNumber;
    public List<int> Coins;

    public Solution(List<int> _Coins)
    {
        Coins = _Coins;
        MinCoinNumber = Coins.Count;
        Sum = 0;

        foreach(int n in Coins)
        {
            Sum += n;
        }
    }
}
