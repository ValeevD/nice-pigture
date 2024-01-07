using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigView : MonoBehaviour
{
    private int _sumValue;
    private TextMesh textMesh;

    private void Awake()
    {
        textMesh = GetComponentInChildren<TextMesh>();
    }

    public void SetSum(int newValue)
    {
        _sumValue = newValue;
        textMesh.text = _sumValue.ToString();
    }
}
