using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour {

    public static GameState instance = null;

    public bool book;
    public bool piano;

    void Awake()
    {
        book = false;
        piano = false;

        if(instance == null)
            instance = this;

        if (instance != null)
            Destroy(this);

        DontDestroyOnLoad(this);
    }
}
