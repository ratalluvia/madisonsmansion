using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuController : MonoBehaviour {

    public SceneChanger sc;

	public void LoadOpening()
    {
        sc.FadeToLevel("Opening");
    }
}
