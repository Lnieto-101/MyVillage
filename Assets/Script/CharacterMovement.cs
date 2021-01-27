using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMovement : MonoBehaviour
{
    public Rigidbody2D _rb;
    public Animator anim;
    
    public float speed = 5f;

    public Text textBox;
    public Interactable interact_props;

    public GameObject inventory;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private float horizontal = 0;
    private float vertical = 0;
    
    //0 = bottom, 1 = right, 2 = top, 3 = left
    public int direction = 0;
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal"); 
        vertical = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Q))
        {
            inventory.SetActive(!inventory.activeSelf);
        }

        if (!inventory.activeSelf)
        {
            if (interact_props != null)
            {
                if (!interact_props.inAction)
                {
                    if (horizontal != 0 || vertical != 0)
                    {
                        _rb.velocity = new Vector2(horizontal * speed, vertical * speed);
                        textBox.text = "";
                    }
                    else
                    {
                        _rb.velocity = Vector2.zero;
                    }

                    PlayAnimation();
                }
            }
            else
            {
                if (horizontal != 0 || vertical != 0)
                {
                    _rb.velocity = new Vector2(horizontal * speed, vertical * speed);
                    textBox.text = "";
                }
                else
                {
                    _rb.velocity = Vector2.zero;
                }

                PlayAnimation();
            }
        }
        else
        {
            _rb.velocity = Vector2.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Interactable"))
        {
            interact_props = other.gameObject.GetComponent<Interactable>();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Interactable"))
        {
            interact_props = null;
        }
    }

    void PlayAnimation()
    {
        if (vertical > 0)
        {
            anim.Play("runTop");
            direction = 2;
        }
        else if (vertical < 0)
        {
            anim.Play("runBot");
            direction = 0;
        }
        else if (horizontal > 0)
        {
            anim.Play("runRight");
            direction = 1;
        }
        else if (horizontal < 0)
        {
            anim.Play("runLeft");
            direction = 3;
        }
        else
        {
            switch (direction)
            {
                case 0:
                    anim.Play("Idle");
                    break;
                case 1:
                    anim.Play("IdleRight");
                    break;
                case 2:
                    anim.Play("IdleTop");
                    break;
                case 3:
                    anim.Play("IdleLeft");
                    break;
                default:
                    anim.Play("Idle");
                    break;
            }
        }
    }
}
