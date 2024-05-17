using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using static Unity.Burst.Intrinsics.X86.Avx;

public class Lava : MonoBehaviour
{
    public int damage;
    public bool hit = false;
    public float cooldown;
    private float timer;
    public AudioSource sizzle;
    public Volume volume;
    private Vignette vig;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        Vignette tmp;
        if ( volume.profile.TryGet<Vignette>(out tmp))
        {
            vig = tmp;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (hit)
        {
            timer += Time.deltaTime;
            if (timer > cooldown)
            {
                timer = 0;
                player.GetComponent<UIController>().TakeDMG(damage);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.ToString());
        if (!hit && other.gameObject.CompareTag("Player"))
        {
            hit = true;
            other.gameObject.GetComponent<UIController>().TakeDMG(damage);
            sizzle.Play();
            vig.intensity.value = 0.5f;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (hit && other.gameObject.CompareTag("Player"))
        {
            hit = false;

            sizzle.Stop();
            vig.intensity.value = 0f;
            }
        }
}
