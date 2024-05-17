using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    public int countdown;
    public int acquired;
    public float health;
    public Slider healthbar;
    public AudioSource[] hurtNoise;
    public TextMeshProUGUI counterText;
    public TextMeshPro countdownText;
    public LoadScene loadScene;
    public int nextScene = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Pickup()
    {
        countdown -= 1;
        acquired += 1;
        counterText.text = acquired.ToString();
        countdownText.text = countdown.ToString();
    }
    public void TakeDMG(int amount)
    {
        health -= amount;
        healthbar.value = health;
        int r = Random.Range(0, hurtNoise.Length);
        hurtNoise[r].Play();
        if (health <= 0)
        {
            loadScene.ChangeToScene(nextScene);
        }
    }
    public int GetNumThings()
    {
        return acquired;
    }
}
