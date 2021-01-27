using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money", 50) + 10);
        Destroy(gameObject);
    }
}
