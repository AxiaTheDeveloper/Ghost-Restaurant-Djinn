using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonCloneGhost : MonoBehaviour
{
    //Clone Ghost
    public GameObject ghostOri;
    public GameObject parentClone;
    [SerializeField] private Transform pos1, pos2;
    GameObject GhostClone;
    GhostBehavio ghost;


    //Slider
    public GameObject slides;
    SliderCode sCode;
    private int totalclick;
    private int totalboost;
    private int totalboosthantu;
    private bool Clicked;//utk durasi
    private float timer;
    [SerializeField]private TextMeshProUGUI LevelNum;
    [SerializeField]private GameObject boom;
    public GameObject GhostDjinn;
    GhostIdentity gi;
    private void Awake() {
        sCode = slides.GetComponent<SliderCode>();
        gi = GhostDjinn.GetComponent<GhostIdentity>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        // ghost = GhostClone.GetComponent<GhostBehavio>();
        boom.gameObject.SetActive(false);
        timer = 15;
        totalclick = 10;
        totalboost = 1;
        totalboosthantu = 0;
        sCode.changeSliderContent(totalclick);
        Clicked = false;
        LevelNum.text = totalboost.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // if(transform.position == pos1.position || GhostClone.position == pos2.position)
        // if(GhostClone){
        //     if(GhostClone.transform.position == pos1.position){
        //         Destroy(this.gameObject);
        //     }
        // }
        if(totalclick < 200){
            totalboosthantu = 0;
            gi.changetotalhntuboost(totalboosthantu);
        }
        if(totalclick == 200){
            boom.gameObject.SetActive(true);
            totalboost = 7;
            LevelNum.text = totalboost.ToString(); 
            // Debug.Log("200");
            // Debug.Log("hantu + " + totalboosthantu);
        }
        else if(totalclick >= 140){
            totalboost = 5;
            LevelNum.text = totalboost.ToString();
        }
        else if(totalclick >= 80){
            totalboost = 2;
            LevelNum.text = totalboost.ToString();
        }
        else{
            totalboost = 1;
            LevelNum.text = totalboost.ToString();
        }
        //Slider
        if(Clicked){
            timer -= Time.deltaTime;
            if(timer <= 0){
                timer = 15;
                Clicked = false;
            }
        }
        if(Clicked == false && totalclick > 10){
            totalclick = totalclick - 1;
            sCode.changeSliderContent(totalclick);
        }
    }

    public void boost(){
        Clicked = true;
        timer = 15;
        if(totalclick < 200){
            totalclick = totalclick + 1;
            
        }
        if(totalclick == 200){
            if(totalboosthantu < 5){
                totalboosthantu = totalboosthantu + 1;
                gi.changetotalhntuboost(totalboosthantu);
            }
            
        }
        
        sCode.changeSliderContent(totalclick);
    }
    
    public int getBoost(){
        return totalboost;
    }
    

    // public void createGhost(){
    //     // int numberRandom = Random.Range(1,3);
    //     // Vector3 posisi;
    //     // if(numberRandom == 1){
    //     //     posisi = pos1.position;
    //     // }
    //     // else if(numberRandom == 2){
    //     //     posisi = pos2.position;
    //     // }
    //     GhostClone = Instantiate(ghostOri, pos2.position, Quaternion.identity);
    //     GhostClone.transform.parent = parentClone.transform;
    //     // Debug.Log("Clone Created" + ghost.getTujuan().x);

    // }
}
