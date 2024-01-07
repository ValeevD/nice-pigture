using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinView : MonoBehaviour
{
    private int _coinValue;
    private TextMesh textMesh;

    private void Awake()
    {
        textMesh = GetComponentInChildren<TextMesh>();
    }

    public void SetCoinValue(int newValue)
    {
        _coinValue = newValue;
        textMesh.text = _coinValue.ToString();
    }

    public void SetPosition(Vector2 newPosition)
    {
        transform.position = newPosition;
    }
}
