﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopSlot : MonoBehaviour
{
    public Sprite[] hat;
    public Image hatImage;
    public ChangeSide sideValue;
    public int price;
    public Text priceText;

    public void ChangeHat()
    {
        sideValue.actualHat = gameObject.GetComponent<ShopSlot>();
        hatImage.sprite = hat[sideValue.side];
        priceText.text = price.ToString();
    }

}
