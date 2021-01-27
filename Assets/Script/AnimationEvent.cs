using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationEvent : MonoBehaviour
{
    public void activate()
    {
        gameObject.SetActive(false);
    }

    public void ChangeScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }
    
}
