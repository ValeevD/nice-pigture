using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvailableCoinsView : MonoBehaviour
{
    public CoinView CoinPrefab;
    private CoinPositionView[] positions;

    private void Awake()
    {
        positions = GetComponentsInChildren<CoinPositionView>();

        //Debug.Log(positions.Length);
        // foreach(var pos in positions)
        //     Debug.Log(pos);
    }

    public void AddCoins(List<int> coins)
    {
        for(int i = 0; i < coins.Count; ++i)
        {
            CoinView newCoin = Instantiate(CoinPrefab);
            newCoin.SetCoinValue(coins[i]);
            newCoin.SetPosition(positions[i].CoinTransform.position);
        }
    }
}
