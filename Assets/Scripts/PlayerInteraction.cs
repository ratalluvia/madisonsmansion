
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerInteraction : MonoBehaviour {

    SpriteRenderer m_spriteRenderer; //Used to change the colors on interactable sprites.
    public Canvas i_canvas; //Used to turn text on/off
    public Text i_text;
    Interactable m_interactable;
    public GameState gs;
    VisionPoints visionPoints;
    public TextBoxManager s_textBoxManager;
    private bool submit_pressed;

    public SceneChanger sc;

    private AudioSource music;
    public AudioMixer mixer;

    private float timecheck;

    private void Start()
    {
        music = gs.GetComponent<AudioSource>();

        visionPoints = FindObjectOfType<VisionPoints>();
    }

    private void Update()
    {
        if((gs.visionLevel + 1) <= visionPoints.visionPoints / 100)
        {
            Debug.Log("Load Vision");
            gs.visionLevel += 1;
            sc.FadeToLevel("VisionScene");
        }

        if (Input.GetAxisRaw("Cancel") != 0)
        {
            Debug.Log("Quit!");
            Application.Quit();
        }

        if (Input.GetAxisRaw("Submit") > 0)
        {
            if(submit_pressed == false)
            {
                s_textBoxManager.DisableTextBox();
                submit_pressed = true;
            }
        }

        if (Input.GetAxisRaw("Submit") == 0) submit_pressed = false;

        if (!music.isPlaying)
        {
            timecheck += Time.deltaTime;
            if (timecheck > 0.5f)
            {
                mixer.SetFloat("MusicVolume", -10.0f);
                timecheck = 0.0f;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        float submit = Input.GetAxisRaw("Submit");
        if (submit > 0 && !submit_pressed && collision.CompareTag("Interactable"))
        {
            GameObject item = collision.gameObject;
            m_interactable = item.GetComponent<Interactable>();

            if (!m_interactable.used && !s_textBoxManager.textBox.enabled && m_interactable.visionPoints)
            {
                m_interactable.used = true;
                visionPoints.AddVisionPoints(item.name);
                s_textBoxManager.theText.text = m_interactable.onUseMessage.text;
                s_textBoxManager.EnableTextBox();
                submit_pressed = true;
            }

            else if(!s_textBoxManager.textBox.enabled && m_interactable.visionPoints)
            {
                s_textBoxManager.theText.text = m_interactable.onReuseMessage.text;
                s_textBoxManager.EnableTextBox();
                submit_pressed = true;
            }

            if (m_interactable.doorway)
            {
                Debug.Log("Doorway");
                gs.currentScene = m_interactable.nextScene;
                sc.FadeToLevel(m_interactable.nextScene);
            }

            if (m_interactable.soundSource)
            {
                Debug.Log("Sound Source");
                mixer.SetFloat("MusicVolume", -80.0f);
                music = item.GetComponent<AudioSource>();
                music.PlayDelayed(0.5f);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Interactable"))
        {
            GameObject item = collision.gameObject;
            m_spriteRenderer = item.GetComponent<SpriteRenderer>();
            m_spriteRenderer.color = Color.magenta;

            m_interactable = item.GetComponent<Interactable>();
            i_text.text = m_interactable.message;
            i_canvas.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Interactable"))
        {
            GameObject item = collision.gameObject;
            m_spriteRenderer = item.GetComponent<SpriteRenderer>();
            m_spriteRenderer.color = Color.white;

            i_text.text = "";
            i_canvas.enabled = false;
        }
    }

    private void FadeScene()
    {

    }
}
