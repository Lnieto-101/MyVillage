using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class FollowCursor : MonoBehaviour
{
    public Image cursor;
    public bool full;
    public Sprite defaultCursor;
    private void Start()
    {
        Cursor.visible = false;
    }

    private void Update()
    {
        transform.position = Input.mousePosition;

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("rightclic");
        }
    }

    public void SetDefault()
    {
        cursor.sprite = defaultCursor;
    }
}
