using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostIdentity : MonoBehaviour
{
    // Masih byk yg blm di sini yaaa
    
    //Di sini semua hitungan (dr upgrade upgrade) bakal ada di sini sebelum ntr dimasukkin ke behavio (jalan + total makanan yg dibeli)
    [SerializeField] private  string nama;
    [SerializeField] private  int levelUpgrade;
    //Gausa rank jgn lupa~~
    [SerializeField] private  int totalKerakTelorawal;
    [SerializeField] private  float waktuDatangawal;
    [SerializeField] private  float hitunganwaktuDatang; //INI CEK RUMUS DI EXCEL

    // Harga Upgrade
    [SerializeField] private int hargaKoinUpgradeawal;
    [SerializeField] private int hargaFPUpgradeawal;
    [SerializeField] private int hitunganhargaKoinUpgrade;

    private int totalHantuDatangawal = 1;

    //jgn lupa minta data-data dr class lain
    public GameObject player;
    Player Players;
    Toko tokoupgrade;

    public GameObject miniboss;
    MiniBoss mb;
    

    //Variable buat hitungan
    private int totalKerakTelorAkhir;
    private float waktuDatangAkhir;
    private int totalHantuDatangAkhir;
    private int hargaKoinUpgradeAkhir;
    private int hargaFPUpgradeAkhir;

    bool adaUpgrade;//notif dr code lain jg
    public bool adaUpgradetoko;//Ini biar ngitung di sini aja ga di ghostbehavio
    bool minidatang;

    GhostBehavio GhostB;

    private int totalhntuboost;

    // buat tau ini ghost yg mana (8,9,10,11 --> ini buat ghost yg ada efek d toko, sisanya 0)
    [SerializeField] private int ghost;

    //slider boos
    public GameObject buttonspam;
    ButtonCloneGhost buttonspaam;

    bool berhasilup;


    void Awake() { //THIS IS ONLY UTK KASIHTAU KE YG LAIN ADA UPGRADE GA AAPLAGI BUAT YG GA ADA HUBUNGANNYA AMA SHOP
        GhostB = GetComponentInParent<GhostBehavio>();
        Players = player.GetComponent<Player>();
        tokoupgrade = player.GetComponent<Toko>();
        mb = miniboss.GetComponent<MiniBoss>();
        buttonspaam = buttonspam.GetComponent<ButtonCloneGhost>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
        count();
        adaUpgrade = false;
        adaUpgradetoko = false;
        minidatang = false;
        totalhntuboost = 0;
        berhasilup = false;
    }

    // Update is called once per frame
    void Update()
    {
        // if(levelUpgrade == 0){
        //     gameObject.SetActive(false);
        // }
        // else{
        //     gameObject.SetActive(true);
        // }
        if(adaUpgrade){
            GhostB.adaUpgrade1 = true;
            count();
            adaUpgrade = false;
        }
        if(adaUpgradetoko){
            count();
            adaUpgradetoko = false;
        }
        if(minidatang){
            GhostB.adaUpgrade1 = true;
            minidatang = false;
        }

    }

    public void changetotalhntuboost(int ttl){
        totalhntuboost = ttl;
    }
    public void dtg(){
        Debug.Log("Samapai");
        minidatang = true;
    }

    public string getnamaghost(){
        return nama;
    }
    public int getKerakTelor(){
        return totalKerakTelorAkhir;
    }
    public int getKerakTelorAwal(){
        return totalKerakTelorawal;
    }
    public int getTotalHantu(){
        return totalHantuDatangAkhir;
    }
    
    public float getWaktuDatang(){
        return waktuDatangAkhir;
    }
    public float getWaktuDatangAwal(){
        return waktuDatangawal;
    }

    public float gethitunganyGhost(){
        return hitunganwaktuDatang;
    }

    public int getLevel(){
        return levelUpgrade;
    }
  
    public int getHargaKoin(){
        return hargaKoinUpgradeAkhir;
    }
    public int getHargaFP(){
        return hargaFPUpgradeAkhir;
    }

    public void setLevel(int level)
    {
        levelUpgrade = level;
    }

    public bool berhasil(){
        return berhasilup;
    }
    public void upgrade_Level(){ //INI buat button Upgrade
        if(levelUpgrade == 20){
            Players.sudahMaxUpgrade();
        }
        else{
            if(Players.getKoin() >= hargaKoinUpgradeAkhir && Players.getFP() >= hargaFPUpgradeAkhir){
                if(levelUpgrade == 0){
                    berhasilup = true;
                }
                levelUpgrade++;
                Players.changeKoin(-hargaKoinUpgradeAkhir);
                Players.changeFP(-hargaFPUpgradeAkhir);
                // jgn lupa ganti hargaupgradenya, eh tp gausa ya?
                adaUpgrade = true;
            }
            else{
                
                Players.notEnough();
                
            }
        }
        
        
    }

    public void beli(){
        int sempanHarga = Players.getHarga();
        int totalHarga = totalKerakTelorAkhir * sempanHarga;
        // Data toko
        int Kompor = tokoupgrade.getDataInt(2);//persenan dr total awal
        int wajanK = tokoupgrade.getDataInt(3);// sama

        //bonus dr clicking
        int boost = buttonspaam.getBoost();

        int total = (totalHarga + Kompor/100*totalHarga + wajanK/100*totalHarga)*boost; //Ntr ditambahin bonus : Kompor, Wajan Kecil, 
        
        int ttlhantu = totalHantuDatangAkhir + totalhntuboost;
        Players.changeKoin(total*ttlhantu);
        Debug.Log("Koin Player :" +Players.getKoin());

        // Debug.Log("1)" + totalKerakTelorAkhir);
        // Debug.Log(totalHantuDatangAkhir);
        // Debug.Log(total*totalHantuDatangAkhir);
    }

    public void count(){

        Debug.Log("HITUNG");
        // Data toko
        int TerompetData = tokoupgrade.getDataInt(0);//ditambah
        int Outlet = tokoupgrade.getDataInt(1);//dikali ke total awal
        int papan = tokoupgrade.getDataInt(4);//persenan dr total awal

        // efek miniboss
        float miniBosskurang = mb.getnegatifkurang();
        int miniBosslambat = mb.getnegatiflambat();
        
        // Debug.Log("outlet " + Outlet);
        
        //TotalKerakTelor
        int totalKerakTelor1 = (totalKerakTelorawal*levelUpgrade);
        
        
        //Cek Upg Toko 1. Outlet 2. Papan Reklame 3.Item msg msg hantu kalo ada 4. Efek negative dari miniBoss //mungkin nanti kita vikin syarat aja buat bedain ghost bioasa ama yg ada item tmbhn.

        if(ghost != 0){
            int tambahan = tokoupgrade.getDataInt(ghost);
            totalKerakTelor1 += tambahan;
        }
        int totalKerakTelor2 = totalKerakTelor1*Outlet + totalKerakTelor1*papan/100;
        if(totalKerakTelor2 == 1){
            totalKerakTelorAkhir = totalKerakTelor2;
        }
        else{
            float totalKerakTelor3 = (float)totalKerakTelor2 - (float)totalKerakTelor2*miniBosskurang/100;
            totalKerakTelorAkhir = (int)totalKerakTelor3;
        }

        //WaktuDatang
        float waktuDatangAkhir1 = waktuDatangawal - (hitunganwaktuDatang*(levelUpgrade-1));//negatif miniboss jgn lupa dimasukkin ~ stlh ditotalin
        waktuDatangAkhir = waktuDatangAkhir1 + waktuDatangAkhir1*(float)miniBosslambat/100;

        Debug.Log(waktuDatangAkhir);


        //totalHantu
        totalHantuDatangAkhir = totalHantuDatangawal + TerompetData;//Cek Upg Toko 1. Terompet Tanduk
        hargaKoinUpgradeAkhir = hargaKoinUpgradeawal + hitunganhargaKoinUpgrade*levelUpgrade;
        
        hargaFPUpgradeAkhir = hargaFPUpgradeawal*(levelUpgrade+1);
        
    }

}
