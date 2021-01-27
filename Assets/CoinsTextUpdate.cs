using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsTextUpdate : MonoBehaviour
{
    public Text coins;

    private void Start()
    {
        coins.text = PlayerPrefs.GetInt("Money", 50).ToString();
    }

    private void Update()
    {
        coins.text = PlayerPrefs.GetInt("Money", 50).ToString();
    }
}
