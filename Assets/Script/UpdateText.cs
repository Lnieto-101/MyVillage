using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateText : MonoBehaviour
{
    public string item;
    public Text itemText;

    private void Update()
    {
        itemText.text = PlayerPrefs.GetInt(item, 0).ToString();
    }
}
