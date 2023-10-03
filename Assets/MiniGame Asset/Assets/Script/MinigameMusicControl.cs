using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameMusicControl : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private AudioSource BGM;
    void Start()
    {
        loadVol();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadVol()
    {
        float nilaiVolBGM = PlayerPrefs.GetFloat("saveBGM");
        BGM.volume = nilaiVolBGM;
    }
}
