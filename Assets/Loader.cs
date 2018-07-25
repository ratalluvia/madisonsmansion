using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour {

    public GameObject gameState;

    void Awake () {
		if(GameState.instance == null)
        {
            Instantiate(gameState);
        }
	}

}
