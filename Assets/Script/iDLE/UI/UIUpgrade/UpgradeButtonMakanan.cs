using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeButtonMakanan : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject player;
    bool adaupBM;
    BahanMakanan bahanmakanan;
    [SerializeField]private int bahanmakananx;
    private int rank,lvl,harga,upgradeawal, hitunganx, upgradeakhir, upgradehitungan, rankhitungan, lvlhitungan;


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
        bahanmakanan = player.GetComponent<BahanMakanan>();
    }
    void Start()
    {
        
        InfoCanvas.gameObject.SetActive(false);
        mainparentinfo.gameObject.SetActive(false);
        Maxlevel.gameObject.SetActive(false);
        Max.gameObject.SetActive(false);
        RankUpButton.gameObject.SetActive(false);
        rankupObject.gameObject.SetActive(false);
        

        adaupBM = false;

        ambildata();
        upgradeawal = bahanmakanan.getUpgradeawal(bahanmakananx);
        hitunganx = bahanmakanan.gethitunganx(bahanmakananx);
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
        string nama = bahanmakanan.getName(bahanmakananx);
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
        if(rank == 2 && lvl == 25){
            Button.gameObject.SetActive(false);
            Max.gameObject.SetActive(true);
            upgradeObject.gameObject.SetActive(false);
            nextupgrade.gameObject.SetActive(false);
            Maxlevel.gameObject.SetActive(true);
        }
        if(adaupBM){
            adaupBM = false;
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

        x1.text = upgradeakhir.ToString();
        x2.text = upgradehitungan.ToString();
    }

    public void upgradetoko(){
        adaupBM = true;
        bahanmakanan.upgrade_levBahan(bahanmakananx);
        if(bahanmakanan.berhasilupbahan(bahanmakananx)){
            ButtonText2.gameObject.SetActive(true);
            ButtonText1.gameObject.SetActive(false);
        }
    }

    void ambildata(){
        rank = bahanmakanan.getRankBM(bahanmakananx);
        lvl = bahanmakanan.getLevelBM(bahanmakananx);
        harga = bahanmakanan.getHargaBM(bahanmakananx);
        upgradeakhir = bahanmakanan.getUpgrade(bahanmakananx);
    }

    void count(){
        if(lvl == 25 && rank == 1){
            RankUpButton.gameObject.SetActive(true);
            rankupObject.gameObject.SetActive(true);
            lvlhitungan = 1;
            rankhitungan = 2;
        }
        else{
            RankUpButton.gameObject.SetActive(false);
            rankupObject.gameObject.SetActive(false);
            lvlhitungan = lvl+1;
            rankhitungan = rank;
        }
        if(rankhitungan==1){
            upgradehitungan = upgradeawal * lvlhitungan;
        }
        else{
            upgradehitungan = upgradeawal * (lvlhitungan+25) + hitunganx;
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
