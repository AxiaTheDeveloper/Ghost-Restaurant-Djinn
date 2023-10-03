using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeButtonToko : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject player;
    bool adaupTK;
    Toko toko;
    [SerializeField]private int tokox;
    private int rank,lvl,harga,rankhitungan, lvlhitungan;
    private float upgradeawalx, hitunganx, upgradeakhirx, upgradehitunganx;
    UpgradeButtonTokoY but;


    // Canvas TIMEEE
    [SerializeField]private GameObject ButtonText1,ButtonText2, Button, Max, RankUpButton;
    
    [SerializeField]private TextMeshProUGUI RankNum, LevelNum, Harga;

    [SerializeField]private GameObject image1,image2;

    // buat si info
    [SerializeField]private GameObject mainparentinfo;
    [SerializeField]private GameObject InfoCanvas, nextupgrade, Maxlevel, upgradeObject, rankupObject;
    [SerializeField]private TextMeshProUGUI Nama1, RankNum1, LevelNum1, x1, RankNum2, LevelNum2, x2;
    [SerializeField]private GameObject imageI1,imageI2;
    private void Awake() {
        toko = player.GetComponent<Toko>();
        but = GetComponentInParent<UpgradeButtonTokoY>();
    }
    void Start()
    {
        
        InfoCanvas.gameObject.SetActive(false);
        mainparentinfo.gameObject.SetActive(false);
        Maxlevel.gameObject.SetActive(false);
        Max.gameObject.SetActive(false);
        RankUpButton.gameObject.SetActive(false);
        rankupObject.gameObject.SetActive(false);

        adaupTK = false;

        ambildata();
        upgradeawalx = toko.getDATATOKOX_AWAL(tokox);
        hitunganx = toko.gethitunganxToko(tokox);

        if(rank == 1){
            image1.gameObject.SetActive(true);
            image2.gameObject.SetActive(false);
            imageI1.gameObject.SetActive(true);
            imageI2.gameObject.SetActive(false);
        }
        else{
            image1.gameObject.SetActive(false);
            image2.gameObject.SetActive(true);
            imageI1.gameObject.SetActive(false);
            imageI2.gameObject.SetActive(true);
        }


        if(lvl == 0){
            ButtonText1.gameObject.SetActive(true);
            ButtonText2.gameObject.SetActive(false);
        }
        else{
            ButtonText2.gameObject.SetActive(true);
            ButtonText1.gameObject.SetActive(false);
        }
        count();
        string nama = toko.getNameToko(tokox);

        Nama1.text = nama;
        textchange();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(rank == 2){
            image1.gameObject.SetActive(false);
            image2.gameObject.SetActive(true);
            imageI1.gameObject.SetActive(false);
            imageI2.gameObject.SetActive(true);
        }
        if((tokox == 0 && rank == 2 && lvl == 5) || ((tokox>=1 && tokox<=4) && rank == 2 && lvl == 20) || ((tokox>=5 && tokox<=7) && rank == 2 && lvl == 25) || ((tokox>=8 && tokox<=11) && rank == 1 && lvl == 20)){
            Button.gameObject.SetActive(false);
            Max.gameObject.SetActive(true);
            upgradeObject.gameObject.SetActive(false);
            nextupgrade.gameObject.SetActive(false);
            Maxlevel.gameObject.SetActive(true);
        }


        if(adaupTK){
            adaupTK = false;
            ambildata();
            count();
            textchange();
        }
        


    }

    void textchange(){
        RankNum.text = rank.ToString();
        RankNum1.text = rank.ToString();
        RankNum2.text = rankhitungan.ToString();

        LevelNum.text = lvl.ToString();
        LevelNum1.text = lvl.ToString();
        LevelNum2.text = lvlhitungan.ToString();

        Harga.text = harga.ToString();

        x1.text = upgradeakhirx.ToString();
        x2.text = upgradehitunganx.ToString();
    }

    public void upgradetoko(){
        // Debug.Log("cek1");
        adaupTK = true;
        
        if(tokox == 5 || tokox == 6){
            but.adaupgradeY();
        }
        
        
        toko.upgradeToko(tokox);
        // Debug.Log("cek4");
        
        if(ButtonText1.gameObject.activeSelf){
            if(toko.berhasiluptoko(tokox)){
                ButtonText2.gameObject.SetActive(true);
                ButtonText1.gameObject.SetActive(false);
            }
            
        }
        // Debug.Log("cek5");
       
    }

    void ambildata(){
        rank = toko.getRankToko(tokox);
        lvl = toko.getLevelToko(tokox);
        harga = toko.getHarga(tokox);
        upgradeakhirx = toko.getDATATOKOX(tokox);
    }

    void count(){
        if(((tokox == 0||(tokox>=5 && tokox<=7)) && rank == 1 && lvl == 25) || ((tokox>=1 && tokox<=4) && rank == 1 && lvl == 20)){
            RankUpButton.gameObject.SetActive(true);
            rankupObject.gameObject.SetActive(true);
            lvlhitungan = 1;
            rankhitungan = 2;
            if(tokox == 4){
                upgradeawalx = 40;
            }
        }
        else{
            RankUpButton.gameObject.SetActive(false);
            rankupObject.gameObject.SetActive(false);
            lvlhitungan = lvl+1;
            rankhitungan = rank;
        }
        if(rankhitungan==1){
            if(tokox == 0||tokox >=6){
                upgradehitunganx = upgradeawalx * lvlhitungan;
            }
            else if(tokox ==1){
                upgradehitunganx = upgradeawalx + (lvlhitungan/5);
            }
            else if(tokox == 2){
                upgradehitunganx = upgradeawalx + 2*(lvlhitungan/5);
            }
            else if(tokox == 3){
                upgradehitunganx = upgradeawalx + 3*(lvlhitungan/5);
            }
            else if(tokox == 4){
                upgradehitunganx = upgradeawalx + 2*(lvlhitungan-1);
            }
            else if(tokox == 5){
                upgradehitunganx = 10 + upgradeawalx * (lvlhitungan-1);
            }
                    
        }
        else{
            if(tokox == 0||tokox >=6){
                upgradehitunganx = upgradeawalx * (lvlhitungan+25) + hitunganx;
            }
            else if(tokox == 1){
                upgradehitunganx = upgradeawalx + ((lvlhitungan+20)/5) + hitunganx;
            }
            else if(tokox == 2){
                upgradehitunganx = upgradeawalx + 2*((lvlhitungan+20)/5) + hitunganx;
            }
            else if(tokox == 3){
                upgradehitunganx = upgradeawalx + 3*((lvlhitungan+20)/5) + hitunganx;
            }
            else if(tokox == 4){
                upgradehitunganx = upgradeawalx + 2*(lvlhitungan-1);
            }
            else if(tokox == 5){
                upgradehitunganx = 10 + upgradeawalx * ((lvlhitungan+25)) + hitunganx;
            }
                    
        }  
    }


    public void infoButtonMakanan0(){
        mainparentinfo.gameObject.SetActive(true);
        InfoCanvas.gameObject.SetActive(true);
        // if(rank == 1){
        //     imageI1.gameObject.SetActive(true);
        //     imageI2.gameObject.SetActive(false);
        // }
        // if(rank == 2){
        //     imageI1.gameObject.SetActive(false);
        //     imageI2.gameObject.SetActive(true);
        // }
    }
    public void backMakanan0(){
        InfoCanvas.gameObject.SetActive(false);
        mainparentinfo.gameObject.SetActive(false);
    }

    



}
