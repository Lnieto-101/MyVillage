using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct MyHat
     {
         public Sprite hatFace3;
         public Sprite hatFace0;
         public Sprite hatFace1;
         public Sprite hatFace2;
     }
public class ChangeHat : MonoBehaviour
{
    
    public MyHat[] hats;
    public bool[] haveHat;
    public List<MyHat> myHats;
    public HatSide HatSide;
    public Image mainHat;

    private int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.GetInt("HatSelector", );
        
    }

    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Hats");

        if (objs.Length > 1)
        {
            Destroy(gameObject);
        }
        
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextHat()
    {
        if (myHats.Count > 0)
        {
            i++;
            if (i > myHats.Count - 1)
            {
                i = 0;
            }
            Sprite[] newHat = new Sprite[4];
            newHat[0] = myHats[i].hatFace3;
            newHat[1] = myHats[i].hatFace0;
            newHat[2] = myHats[i].hatFace1;
            newHat[3] = myHats[i].hatFace2;
            HatSide.hat = newHat;
            mainHat.sprite = myHats[i].hatFace3;
        }
    }
    
    public void PreviousHat()
    {
        if (myHats.Count > 0)
        {
            i--;
            if (i < 0)
            {
                i = myHats.Count - 1;
            }

            Sprite[] newHat = new Sprite[4];
            newHat[0] = myHats[i].hatFace3;
            newHat[1] = myHats[i].hatFace0;
            newHat[2] = myHats[i].hatFace1;
            newHat[3] = myHats[i].hatFace2;
            HatSide.hat = newHat;
            mainHat.sprite = myHats[i].hatFace3;
        }
    }
}
