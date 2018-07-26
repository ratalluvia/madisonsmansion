using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoSceneController : MonoBehaviour {

    public GameState gs;
    public SceneChanger sc;
	
	// Update is called once per frame
	void Update () {
		if(Input.GetAxisRaw("Submit") > 0)
        {
            sc.FadeToLevel("Entryway");
        }
	}
}
