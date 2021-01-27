using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public GameObject cursorObj;
    public Image CursorObjImage;
    public Image _image;
    public bool itemInSlot;
    public FollowCursor followCursor;

    private void Start()
    {
        if (_image.enabled)
        {
            itemInSlot = true;
        }

        followCursor = cursorObj.GetComponent<FollowCursor>();
    }

    public void TakeItem()
    {
        if (itemInSlot && !followCursor.full)
        {
            CursorObjImage.sprite = _image.sprite;
            _image.enabled = false;
            itemInSlot = false;
            followCursor.full = true;
        }
        else if(itemInSlot && followCursor.full)
        {
            Sprite temp = CursorObjImage.sprite;
            CursorObjImage.sprite = _image.sprite;
            _image.sprite = temp;
            followCursor.full = true;
        }
        else if(followCursor.full)
        {
            _image.enabled = true;
            _image.sprite = CursorObjImage.sprite;
            cursorObj.GetComponent<FollowCursor>().SetDefault();
            itemInSlot = true;
            followCursor.full = false;
        }
    }
    
    
}
