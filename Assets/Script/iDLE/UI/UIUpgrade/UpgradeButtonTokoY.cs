using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeButtonTokoY : MonoBehaviour
{
    public GameObject player;
    bool adaupTKy;
    Toko toko;
    [SerializeField]private int tokoy;
    private int rank,lvl, rankhitungan, lvlhitungan;
    private float upgradeawaly, hitungany, upgradeakhiry, upgradehitungany;

    

    // Canvas TIMEEE
    [SerializeField]private TextMeshProUGUI y1, y2;
    private void Awake() {
        toko = player.GetComponent<Toko>();
    }
    void Start()
    {

        adaupTKy = false;

        ambildata();
        upgradeawaly = toko.getDATATOKOY_AWAL(tokoy-5);
        hitungany = toko.gethitunganyToko(tokoy-5);

        count();

        textchange();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(adaupTKy){
            adaupTKy = false;
            ambildata();
            count();
            textchange();
        }
        
    }

    public void adaupgradeY(){
        // Debug.Log("Hi!");
        adaupTKy = true;
    }

    void textchange(){

        y1.text = upgradeakhiry.ToString();
        y2.text = upgradehitungany.ToString();
    }


    void ambildata(){
        rank = toko.getRankToko(tokoy);
        lvl = toko.getLevelToko(tokoy);
        upgradeakhiry = toko.getDATATOKOY(tokoy-5);
    //     Debug.Log(upgradeakhiry);
    //     Debug.Log(upgradehitungany);
    }

    void count(){
        if(rank == 1 && lvl == 25){
            lvlhitungan = 1;
            rankhitungan = 2;
        }
        else{
            lvlhitungan = lvl+1;
            rankhitungan = rank;
        }
        if(rankhitungan==1){
            upgradehitungany = upgradeawaly + 2*(lvlhitungan/10);
                    
        }
        else{
            upgradehitungany = upgradeawaly + 2*((lvlhitungan+25)/10) + hitungany;     
        }  
    }



}
