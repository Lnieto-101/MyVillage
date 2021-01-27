using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSide : MonoBehaviour
{
    public Sprite[] character;
    public int side = 0;
    public Image charVisualizer;
    public ShopSlot actualHat;
    public HatSide hat;

    public void SideChange(int value)
    {
        side = side + value;
        if (side > 3)
        {
            side = 0;
        }

        if (side < 0)
        {
            side = 3;
        }

        charVisualizer.sprite = character[side];
        actualHat.ChangeHat();
    }

    public void BuyHat()
    {
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money", 50) - actualHat.price);
        hat.hat = actualHat.hat;
    }
}
