using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisionSceneController : MonoBehaviour {

    public GameState gs;
    public SceneChanger sc;

    public Text text;

    public TextAsset vision1;
    public TextAsset vision2;
    public TextAsset vision3;
    public TextAsset vision4;
 
    private void Start()
    {
        switch (gs.visionLevel)
        {
            case 0:
                Debug.LogError("Vision loaded incorrectly");
                return;
            case 1:
                text.text = vision1.text;
                break;
            case 2:
                text.text = vision2.text;
                break;
            case 3:
                text.text = vision3.text;
                break;
            case 4:
                text.text = vision4.text;
                break;
        }
    }

    void Update()
    {
        if (Input.GetAxisRaw("Submit") > 0)
        {
            sc.FadeToLevel(gs.currentScene);
        }
    }
}
