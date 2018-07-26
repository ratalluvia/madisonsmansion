using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningController : MonoBehaviour {

    public GameState gs;
    public SceneChanger sc;

    private void Start()
    {
        gs.book = false;
        gs.piano = false;
    }

    void Update () {
        if (Input.GetAxisRaw("Submit") > 0)
        {
            gs.currentScene = "Entryway";
            sc.FadeToLevel("Entryway");
        }
	}
}
