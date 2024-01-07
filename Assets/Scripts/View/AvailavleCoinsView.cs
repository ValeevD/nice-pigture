using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvailavleCoinsView : MonoBehaviour
{
    public CoinView CoinPrefab;

    private CoinView[] _availableCoins;

    private void Awake()
    {
        CoinPositionView[] positions = GetComponentsInChildren<CoinPositionView>();

        Debug.Log(positions.Length);
        // foreach(var pos in positions)
        //     Debug.Log(pos);
    }
}
