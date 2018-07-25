using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {

    public Animator animator;

    private string levelToLoad;

    public void FadeToLevel(string sceneName)
    {
        levelToLoad = sceneName;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(levelToLoad);

    }
}
