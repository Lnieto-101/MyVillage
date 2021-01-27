using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatSide : MonoBehaviour
{
    public CharacterMovement getSide;
    private Animator _animator;
    public Sprite[] hat;
    private SpriteRenderer actualHat;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        actualHat = GetComponent<SpriteRenderer>();
        actualHat.sprite = hat[getSide.direction];
    }

    private int lastDir;
    private void Update()
    {
        /*if (lastDir != getSide.direction)
        {
            _animator.Play("HatIdle");
            lastDir = getSide.direction;
        }*/
         actualHat.sprite = hat[getSide.direction];
    }
}
