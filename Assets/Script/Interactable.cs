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
        Item,
        Dialogue
    };

    public Interaction action;
    [Tooltip("0 = Bottom\n1 = Right\n2 = Top\n3 = Left")]
    public int directionNeeded;
    public string text;
    public bool inAction;
    public bool canAction;
    private GameObject player;
    public Text textBox;
    public string yesDialogue;
    public string noDialogue;
    public GameObject answerPanel;
    public GameObject toActivate;
    
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
        if (canAction && !inAction)
        {
            if (Input.GetKeyDown(KeyCode.E) && !inAction &&
                directionNeeded == player.GetComponent<CharacterMovement>().direction)
            {
                player.GetComponent<CharacterMovement>()._rb.velocity = Vector2.zero;
                inAction = true;
                DoAction();
            }
        }
    }

    void DoAction()
    {
        textBox.text = text;
        if (action == Interaction.Dialogue)
        {
            answerPanel.SetActive(true);
        }
        else
        {
            inAction = false;
        }
        //Debug.Log(text);
    }

    public void YesAnswer()
    {
        textBox.text = yesDialogue;
        answerPanel.GetComponent<Animator>().Play("ExitAnimation");
        StartCoroutine(ActionDuration(1f));
        if (toActivate != null)
        {
            toActivate.SetActive(true);
        }
    }

    public void NoAnswer()
    {
        textBox.text = noDialogue;
        answerPanel.GetComponent<Animator>().Play("ExitAnimation");
        StartCoroutine(ActionDuration(2f));
    }

    IEnumerator ActionDuration(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        inAction = false;
        textBox.text = "";
    }
}
