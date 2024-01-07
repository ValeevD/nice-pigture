using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPositionView : MonoBehaviour
{
    public Transform CoinTransform => _transform;

    private Transform _transform;

    private void Awake()
    {
        _transform = this.transform;
    }
}
