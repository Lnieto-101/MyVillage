using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

public class ChangeClothes : MonoBehaviour
{
    public AnimatorController[] Amelia;
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
        ameliaAnimator.runtimeAnimatorController = Amelia[PlayerPrefs.GetInt("Cloth", 0)];
        charImage.sprite = ameliaSprite[PlayerPrefs.GetInt("Cloth", 0)];
    }
}
