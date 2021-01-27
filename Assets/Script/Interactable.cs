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
    
    private GameObject player;

    [Header("Basic need")]
    public Interaction action;
    [Tooltip("-1 = any\n0 = Bottom\n1 = Right\n2 = Top\n3 = Left")]
    public int directionNeeded;
    public string text;
    [HideInInspector]
    public bool inAction;
    [HideInInspector]
    public bool canAction;
    
    
    public Text textBox;
    
    [Header("Dialogue dependencies")]
    [Space(10)]
    public string yesDialogue;
    public string noDialogue;
    public GameObject answerPanel;
    public GameObject toActivate;
    
    [Header("Item dependencies")]
    [Space(10)]
    public float breakTime;
    public GameObject dropPrefab;
    public Animator objectAnimator;
    public GameObject loadingBreak;
    public Image fillImage;
    
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
                (directionNeeded == player.GetComponent<CharacterMovement>().direction || directionNeeded == -1))
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
        else if (action == Interaction.Item)
        {
            BreakObject();
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

    public void BreakObject()
    {
        loadingBreak.SetActive(true);
        fillImage.fillAmount = 0;
        StartCoroutine(BreakTiming(breakTime));
    }

    IEnumerator BreakTiming(float seconds)
    {
        while (seconds > 0)
        {
            objectAnimator.enabled = true;
            objectAnimator.Play("BreakObject", -1, 0f);
            fillImage.fillAmount += 1 / breakTime;
            seconds -= 1;
            yield return new WaitForSeconds(1);
        }

        if (dropPrefab != null)
        {
            GameObject dropInstance = Instantiate(dropPrefab);
            dropInstance.transform.position = transform.position;
        }
        
        inAction = false;
        textBox.text = "";
        loadingBreak.SetActive(false);
        fillImage.fillAmount = 0;
        Destroy(gameObject);
    }
    
}
