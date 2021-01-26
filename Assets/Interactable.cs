using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    public enum Interaction
    {
        Text,
        Quest,
        Item
    };

    public Interaction action;
    [Tooltip("0 = Bottom\n1 = Right\n2 = Top\n3 = Left")]
    public int directionNeeded;
    public string text;
    public bool inAction;
    public bool canAction;
    private GameObject player;
    public Text textBox;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.gameObject;
            canAction = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        canAction = false;
    }

    private void Update()
    {
        if (canAction)
        {
            if (Input.GetKeyDown(KeyCode.E) && !inAction && directionNeeded == player.GetComponent<CharacterMovement>().direction)
            {
                inAction = true;
                DoAction();
            }
        }
    }

    void DoAction()
    {
        textBox.text = text;
        //Debug.Log(text);
        StartCoroutine(ActionDuration(2f));
    }

    IEnumerator ActionDuration(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        inAction = false;
        textBox.text = "";
    }
}
