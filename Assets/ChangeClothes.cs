using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine.Animations;

public class ChangeClothes : MonoBehaviour
{
    public RuntimeAnimatorController[] amelia;
    public Sprite[] ameliaSprite;
    public Image charImage;
    public Animator ameliaAnimator;

    public void ChangeAmelia()
    {
        PlayerPrefs.SetInt("Cloth", PlayerPrefs.GetInt("Cloth", 0) + 1);
        if (PlayerPrefs.GetInt("Cloth", 0) > 1)
        {
            PlayerPrefs.SetInt("Cloth", 0);
        }
        ameliaAnimator.runtimeAnimatorController = amelia[PlayerPrefs.GetInt("Cloth", 0)];
        charImage.sprite = ameliaSprite[PlayerPrefs.GetInt("Cloth", 0)];
    }
}
