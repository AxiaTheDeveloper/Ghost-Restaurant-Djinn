using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private AudioSource BGM;

    private AudioSource SFXKoin1, SFXKoin2, SFXKoin3, SFXKoin4, SFXKoin5, SFXKoin6,SFXKoin7, SFXBoss;

    public GameObject miniboss, ghost1, ghost2, ghost3, ghost4, ghost5, ghost6, ghost7;

    public GameObject aturSFX;
    ListCode4 lc4;



    // bool BGMs,SFX;

    private void Awake() {
        SFXKoin1 = ghost1.GetComponent<AudioSource>();
        SFXKoin2 = ghost2.GetComponent<AudioSource>();
        SFXKoin3 = ghost3.GetComponent<AudioSource>();
        SFXKoin4 = ghost4.GetComponent<AudioSource>();
        SFXKoin5 = ghost5.GetComponent<AudioSource>();
        SFXKoin6 = ghost6.GetComponent<AudioSource>();
        SFXKoin7 = ghost7.GetComponent<AudioSource>();

        SFXBoss = miniboss.GetComponent<AudioSource>();

        lc4 = aturSFX.GetComponent<ListCode4>();

        
    }
    void Start()
    {
        if (PlayerPrefs.HasKey("saveBGM") == false)
        {

            PlayerPrefs.SetFloat("saveBGM", 0.5f);
            PlayerPrefs.SetFloat("saveSFX", 0.5f);
            PlayerPrefs.SetFloat("saveSFXBoss", 0.6f);
            loadVol();
        }
        else
        {

            loadVol();
            if(BGM.volume  == 0){
                lc4.muteBGMnya();
            }
            if(SFXKoin1.volume == 0){
                lc4.muteSFXnya();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void savechangeVolBGM(float nilaiVol)
    {
        PlayerPrefs.SetFloat("saveBGM", nilaiVol);
        loadVol();
    }
    public void savechangeVolSFX(float nilaiVol, float nilaivolboss)
    {
        PlayerPrefs.SetFloat("saveSFX", nilaiVol);
        PlayerPrefs.SetFloat("saveSFXBoss", nilaivolboss);
        loadVol();
    }
    public void loadVol()
    {
        float nilaiVolBGM = PlayerPrefs.GetFloat("saveBGM");
        float nilaiVolSFX = PlayerPrefs.GetFloat("saveSFX");
        float nilaiVolSFXB = PlayerPrefs.GetFloat("saveSFXBoss");
        BGM.volume = nilaiVolBGM;
        SFXKoin1.volume = nilaiVolSFX;
        SFXKoin2.volume = nilaiVolSFX;
        SFXKoin3.volume = nilaiVolSFX;
        SFXKoin4.volume = nilaiVolSFX;
        SFXKoin5.volume = nilaiVolSFX;
        SFXKoin6.volume = nilaiVolSFX;
        SFXKoin7.volume = nilaiVolSFX;
        SFXBoss.volume = nilaiVolSFXB;
    }

    public void turnonBGM(){
        savechangeVolBGM(0.5f);

    }

    public void turnoffBGM(){
        savechangeVolBGM(0);

    }

    public void turnonSFX(){
        savechangeVolSFX(0.5f, 0.6f);

    }

    public void turnoffSFX(){
        savechangeVolSFX(0,0);

    }


}
