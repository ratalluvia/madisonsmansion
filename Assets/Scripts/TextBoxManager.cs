using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour {
    public Canvas textBox;

    public Text theText;

    MadisonController player;

    public GameState gs;

    private bool isActive;

    void Start()
    {
        isActive = false;
        player = FindObjectOfType<MadisonController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
            player.canMove = false;

        if (!isActive)
            player.canMove = true;

    }

    public void EnableTextBox()
    {
        Debug.Log("Enabled the Text Box");
        textBox.enabled = true;
        isActive = true;
    }

    public void DisableTextBox()
    {
        Debug.Log("Disabled the Text Box");
        textBox.enabled = false;
        isActive = false;
    }
}
