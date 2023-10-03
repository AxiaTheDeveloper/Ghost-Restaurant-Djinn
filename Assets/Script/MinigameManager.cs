using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameManager : MonoBehaviour
{
    private static GameObject instance = null;
    public bool fromMinigame = false;
    public int coinChanges = 0;
    public int fameChanges = 0; //receives percentage instead of hard number
    public int fameUpgrade = 0;
    // Start is called before the first frame update
    void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = gameObject;
            DontDestroyOnLoad(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
