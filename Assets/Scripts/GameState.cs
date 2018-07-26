using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour {

    public static GameState instance = null;

    public int visionLevel = 0;

    public bool book;
    public bool piano;
    public bool clock;
    public bool painting;

    public string currentScene;

    void Awake()
    {
        book = false;
        piano = false;
        clock = false;

        if(instance == null)
            instance = this;

        if (instance != null)
            Destroy(this);

        DontDestroyOnLoad(this);
    }
}
