using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public int TotalToCollect;
    public LoadScene loadScene;
    public UIController uiController;
    public int nextScene = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            int currentThings = uiController.GetNumThings();
            if (currentThings >= TotalToCollect)
            {
                Debug.Log("Win");
                loadScene.ChangeToScene(nextScene);
            }
            else
            {
                Debug.Log("too soon");
            }
        }
    }
}
