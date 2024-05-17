using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIAnimator : MonoBehaviour
{
    public GameObject[] dialogue;
    public GameObject panel;
    private bool introCamera = true;
    private bool finished = false;
    public float cooldown;
    private float timer = 0;
    private int dialogeLength;
    private int currentDialogue = 0;
    public AudioSource blahblahblah;
    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
        dialogeLength = dialogue.Length;
        dialogue[0].SetActive(true);   
    }

    // Update is called once per frame
    void Update()
    {
        if (!introCamera && !finished)
        {
            timer += Time.deltaTime;
            if (timer > cooldown)
            {
                if (currentDialogue < dialogeLength)
                {
                    if(currentDialogue + 1 < dialogeLength)
                    {
                        currentDialogue += 1;
                    }
                    dialogue[currentDialogue - 1].SetActive(false);
                    dialogue[currentDialogue].SetActive(true);
                    timer = 0f;
                }
                else if(currentDialogue == dialogeLength)
                {
                    panel.SetActive(false );
                    finished = true;
                }
            }
        }
        
    }
    public void IntroDelay()
    {
        introCamera = false;
        panel.SetActive (true);
        blahblahblah.Play();

    }
}
