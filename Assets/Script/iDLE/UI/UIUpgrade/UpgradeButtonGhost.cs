using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeButtonGhost : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ghost;
    bool adaupghost;
    GhostIdentity ghostid;
    private int lvl, harga, famepoin, upgradeawalx, upgradeakhirx, upgradehitunganx, lvlhitungan;
    private float upgradeawaly, hitungany, upgradeakhiry, upgradehitungany;


    // Canvas TIMEEE
    [SerializeField]private GameObject ButtonText1,ButtonText2, Button, Max;
    
    [SerializeField]private TextMeshProUGUI LevelNum, Harga, FP;



    // buat si info
    [SerializeField]private GameObject mainparentinfo;
    [SerializeField]private GameObject InfoCanvas, nextupgrade, Maxlevel, upgradeObject;
    [SerializeField]private TextMeshProUGUI Nama1, LevelNum1, x1, y1, LevelNum2, x2, y2;
    private void Awake() {
        ghostid = ghost.GetComponent<GhostIdentity>();
    }
    void Start()
    {
        InfoCanvas.gameObject.SetActive(false);
        mainparentinfo.gameObject.SetActive(false);
        Maxlevel.gameObject.SetActive(false);
        Max.gameObject.SetActive(false);

        adaupghost = false;

        ambildata();
        upgradeawalx = ghostid.getKerakTelorAwal();
        upgradeawaly = ghostid.getWaktuDatangAwal();
        hitungany = ghostid.gethitunganyGhost();


        if(lvl == 0){
            ButtonText1.gameObject.SetActive(true);
            ButtonText2.gameObject.SetActive(false);
  
        }
        else{
            ButtonText2.gameObject.SetActive(true);
            ButtonText1.gameObject.SetActive(false);
    
        }
        count();
        string nama = ghostid.getnamaghost();
        Nama1.text = nama;
        textchange();
       
    }

    // Update is called once per frame
    void Update()
    {
       
        if(lvl == 20){
            Button.gameObject.SetActive(false);
            Max.gameObject.SetActive(true);
            upgradeObject.gameObject.SetActive(false);
            nextupgrade.gameObject.SetActive(false);
            Maxlevel.gameObject.SetActive(true);
        }
        
        if(adaupghost){
            adaupghost = false;
            ambildata();
            count();
            textchange();
        }
        


    }

    void textchange(){

        LevelNum.text = lvl.ToString();
        LevelNum1.text = lvl.ToString();
        LevelNum2.text = lvlhitungan.ToString();
        
        float hrg;
        if(harga >= 1000000000){
            hrg = (float)harga/1000000000;
            Harga.text = hrg.ToString("F2") + " Ml";
        }
        else if(harga >= 1000000){
            hrg = (float)harga/1000000;
            Harga.text = hrg.ToString("F2") + " Jt";
        }
        else if(harga >= 100000){
            hrg = harga/1000;
            Harga.text = hrg.ToString() + " Rb";
        }
        else{
            Harga.text = harga.ToString();
        }

        FP.text = famepoin.ToString();

        x1.text = upgradeakhirx.ToString();
        x2.text = upgradehitunganx.ToString();

        y1.text = upgradeakhiry.ToString();
        y2.text = upgradehitungany.ToString();
    }

    public void upgradetoko(){
        adaupghost = true;
        ghostid.upgrade_Level();
        if(ButtonText1.gameObject.activeSelf){
            if(ghostid.berhasil()){
                ButtonText2.gameObject.SetActive(true);
                ButtonText1.gameObject.SetActive(false);
            }
            
        }
    }

    void ambildata(){
        lvl = ghostid.getLevel();
        harga = ghostid.getHargaKoin();
        famepoin = ghostid.getHargaFP();
        upgradeakhirx = ghostid.getKerakTelor();
        upgradeakhiry = ghostid.getWaktuDatang();
    }

    void count(){
        lvlhitungan = lvl+1;

        upgradehitunganx = upgradeawalx * lvlhitungan;
        
        upgradehitungany = upgradeawaly - (lvlhitungan-1) * hitungany;
        
    }


    public void infoButtonMakanan0(){
        mainparentinfo.gameObject.SetActive(true);
        InfoCanvas.gameObject.SetActive(true);
    }

    public void backMakanan0(){
        InfoCanvas.gameObject.SetActive(false);
        mainparentinfo.gameObject.SetActive(false);
    }

}
