using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public bool wantChange;
    public int sceneToLoad = 0;
    public GameObject transition;
    public string animationName;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            wantChange = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            wantChange = false;
        }
    }

    private void Update()
    {
        if (wantChange && Input.GetKeyDown(KeyCode.E))
        {
            wantChange = false;
            //SceneManager.LoadScene(sceneToLoad);
            transition.GetComponent<Animator>().Play(animationName);
        }
    }
}
