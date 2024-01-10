using System;
using System.Collections;
using System.Collections.Generic;


[Serializable]
public class LevelSettings
{
    public int _index;
    public int _sum;
    public int _minCoins;
    public int _coinsCount;
    public List<int> _coins;

    public LevelSettings()
    {
        _coins = new List<int>();

        _index = 1;
        _sum = 33;
        _coinsCount = 5;
        _minCoins = 3;

        _coins.Add(3);
        _coins.Add(4);
        _coins.Add(5);
        _coins.Add(6);
    }
}
