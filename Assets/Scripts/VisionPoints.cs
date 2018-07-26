using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisionPoints : MonoBehaviour {

    public int visionPoints;
    public Text v_text;
    public GameState gs;

    void Start () {
        visionPoints = 0;
        TotalVisionPoints();
    }
	
    public void AddVisionPoints(string objName)
    {
        visionPoints = 0;

        if(objName == "Book")
            gs.book = true;

        if (objName == "Piano")
            gs.piano = true;

        if (objName == "Clock")
            gs.clock = true;

        if (objName == "Painting")
            gs.painting = true;

        TotalVisionPoints();
    }

    private void TotalVisionPoints()
    {
        if (gs.book) visionPoints += 20;
        if (gs.piano) visionPoints += 35;
        if (gs.clock) visionPoints += 25;
        if (gs.painting) visionPoints += 20;

        v_text.text = visionPoints.ToString();
    }
}
