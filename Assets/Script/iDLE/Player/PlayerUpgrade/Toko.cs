using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toko : MonoBehaviour
{
    // List bahan makananan~~~~~ urutan makanan ikutin tabel content stats~~
    [SerializeField] private string[] nama;
    [SerializeField] private int[] hargaawal;

    // uh.. ya
    private int[] hargaAkhir = {0,0,0,0,0,0,0,0,0,0,0,0};
    [SerializeField]private int[] hitunganharga;
    private int[] level = {0,0,0,0,0,0,0,0,0,0,0,0};
    private int[] Rank = {1,1,1,1,1,1,1,1,1,1,1,1};
    [SerializeField] private float[] upgrade_awal;
    [SerializeField] private float[] upgrade_awal_y;
    private float[] upgrade_Akhir = {0,1,0,0,0,0,0,0,0,0,0,0};
    private float[] upgrade_Akhir_y = {0,0};
    [SerializeField] private float[] hitunganx;
    [SerializeField] private float[] hitungany;

    private bool[] berhasilup = {false,false,false,false,false,false,false,false,false,false,false,false};

    Player player;
    public GameObject Ghost1;
    
    public GameObject Ghost2;
    public GameObject Ghost3;
    public GameObject Ghost4;
    public GameObject Ghost5;
    public GameObject Ghost6;
    public GameObject Ghost7;
    GhostIdentity G1;
    GhostIdentity G2;
    GhostIdentity G3;
    GhostIdentity G4;
    GhostIdentity G5;
    GhostIdentity G6;
    GhostIdentity G7;

    private bool adaUpdateToko;


    public GameObject miniboss;
    MiniBoss mb;
    
    
    private void Awake() {
        player = GetComponentInParent<Player>();
        G1 = Ghost1.GetComponent<GhostIdentity>();
        G2 = Ghost2.GetComponent<GhostIdentity>();
        G3 = Ghost3.GetComponent<GhostIdentity>();
        G4 = Ghost4.GetComponent<GhostIdentity>();
        G5 = Ghost5.GetComponent<GhostIdentity>();
        G6 = Ghost6.GetComponent<GhostIdentity>();
        G7 = Ghost7.GetComponent<GhostIdentity>();

        mb = miniboss.GetComponent<MiniBoss>();
    }
    // Start is called before the first frame update
    void Start()
    {
        adaUpdateToko = false;
        counts();
        if(Rank[4] == 2){
            upgrade_awal[4] = 40;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(adaUpdateToko){
            adaUpdateToko = false;
            counts();
            giveUpdateNotif();
        }
        // Debug.Log(upgrade_Akhir_y[0]);
    }

    void giveUpdateNotif(){
        adaUpdateToko = false;
        
        G1.adaUpgradetoko = true;
        G2.adaUpgradetoko = true;
        G3.adaUpgradetoko = true;
        G4.adaUpgradetoko = true;
        G5.adaUpgradetoko = true;
        G6.adaUpgradetoko = true;
        G7.adaUpgradetoko = true;

        mb.adaupToko(true);
    }

    public int getDataInt(int x){ //Semua kecuali 6 & 7, miniboss di 5 & 6 & 7
        // Debug.Log("Outletnya" + (int)upgrade_Akhir[1]);
        // Debug.Log("Outletnya" + upgrade_Akhir[1]);
        return (int)upgrade_Akhir[x];
    }

    public float getDataFloat(int x){ // 6 & 7
        return upgrade_Akhir[x];
    }

    public int getDataMiniGame(int x){ // 0 & 1 sadja urusan minigame
        return (int)upgrade_Akhir_y[x];
    }



    public float getDATATOKOX(int x){ //HANYA BUAT BUTTON AJA OKE
        return upgrade_Akhir[x];
    }
    public float getDATATOKOY(int x){ //HANYA BUAT BUTTON AJA OKE
    //    Debug.Log("A "+level[x+5]+ " " + upgrade_awal_y[x] + " " +upgrade_Akhir_y[x]);
        return upgrade_Akhir_y[x];
    }
    public float getDATATOKOX_AWAL(int x){ //HANYA BUAT BUTTON AJA OKE
        return upgrade_awal[x];
    }
    public float getDATATOKOY_AWAL(int x){ //HANYA BUAT BUTTON AJA OKE
        return upgrade_awal_y[x];
    }
    public float gethitunganxToko(int x){ //HANYA BUAT BUTTON AJA OKE
        return hitunganx[x];
    }
    public float gethitunganyToko(int x){ //HANYA BUAT BUTTON AJA OKE
        return hitungany[x];
    }

    public int getLevelToko(int x){
        if((x == 0 || (x>=5 && x<=7)) && Rank[x] == 2) {
            return level[x] - 25;
        }
        else if((x>=1 && x<=4) && Rank[x] == 2){
            return level[x] - 20;
        }
        else{
            return level[x];
        }
        
    }
    public int getRankToko(int x){
        return Rank[x];
    }
    public int getHarga(int x){
        return hargaAkhir[x];
    }
    public string getNameToko(int x){
        return nama[x];
    }

    public int getBanyakToko()
    {
        return nama.Length;
    }

    public void setRankToko(int idx, int x)
    {
        Rank[idx] = x;
    }

    public void setHarga(int idx, int x)
    {
        hargaAkhir[idx] = x;
    }

    public void setNameToko(int idx, string x)
    {
        nama[idx] = x;
    }
    
    public void setLevel(int idx, int x)
    {
        level[idx] = x;
    }


    public bool berhasiluptoko(int x){
        return berhasilup[x];
    }
    public void upgradeToko(int x){

        if((x == 0 && level[x] == 30) || ((x>=1 && x<=4) && level[x] == 40) || ((x>=5 && x<=7) && level[x] == 50) || ((x>=8 && x<=11) && level[x] == 20)){
            player.sudahMaxUpgrade();
        }
        else{
            if(player.getKoin()>=hargaAkhir[x]){
                if(level[x] == 0){
                    berhasilup[x] = true;
                }
                level[x]++;
                if(((x == 0 || (x>=5 && x<=7)) && level[x] == 26) || ((x>=1 && x<=4) && level[x] == 21)){
                    Rank[x] = 2;
                }
                if(level[4] == 21){
                    upgrade_awal[4] = 40;
                }
                player.changeKoin(-hargaAkhir[x]);
                adaUpdateToko = true;
            }
            else{
                
                player.notEnough();
            }
        }

    }

    void counts(){
        for(int i=0;i<12;i++){
            if(i>= 5 && i <=7){
                hargaAkhir[i] = hargaawal[i] + hitunganharga[i]*(level[i]);
            }
            else{
                hargaAkhir[i] += hitunganharga[i]*(level[i]);
            }
            if(level[i]>0){
                if(Rank[i]==1){
                    if(i == 0||i>=6){
                        upgrade_Akhir[i] = upgrade_awal[i]*level[i];
                        
                    }
                    else if(i==1){
                        upgrade_Akhir[i] = upgrade_awal[i]+(level[i]/5);
                        
                    }
                    else if(i == 2){
                        upgrade_Akhir[i] = upgrade_awal[i] + (2*(level[i]/5));
                    }
                    else if(i == 3){
                        upgrade_Akhir[i] = upgrade_awal[i] + (3*(level[i]/5));
                    }
                    else if(i == 4){
                        upgrade_Akhir[i] = upgrade_awal[i] + (2*(level[i]-1));
                    }
                    else if(i == 5){
                        upgrade_Akhir[i] = 10 + upgrade_awal[i]*(level[i]-1);
                    }
                    
                   
                   

                }
                else{
                    if(i == 0||i>=6){
                        upgrade_Akhir[i] = upgrade_awal[i]*level[i] + hitunganx[i];
                    }
                    else if(i==1){
                        upgrade_Akhir[i] = upgrade_awal[i]+(level[i]/5)+hitunganx[i];
                        
                    }
                    else if(i == 2){
                        upgrade_Akhir[i] = upgrade_awal[i] + (2*(level[i]/5)) + hitunganx[i];
                    }
                    else if(i == 3){
                        upgrade_Akhir[i] = upgrade_awal[i] + (3*(level[i]/5)) + hitunganx[i];
                    }
                    else if(i == 4){
                        upgrade_Akhir[i] = upgrade_awal[i] + (2*(level[i]-20-1));//jgn lupa ganti up awal kalo rank 2
                    }
                    else if(i == 5){
                        upgrade_Akhir[i] = 10 + upgrade_awal[i]*(level[i]) + hitunganx[i];
                    }
                    
                    
                }
            }
            else{
                if(i==1){
                    upgrade_Akhir[i] = 1;
                }
                else{
                    upgrade_Akhir[i] = 0;
                }
                if(i>=0 && i <=4){
                    hargaAkhir[i] = hargaawal[i];
                }
            }
            
        }
        for(int i=0;i<2;i++){
            if(level[i]>0){
                if(Rank[i+5]==1){
                    upgrade_Akhir_y[i] = upgrade_awal_y[i] + 2*(level[i+5]/10);
                }
                else{
                    upgrade_Akhir_y[i] = upgrade_awal_y[i] + 2*(level[i+5]/10) + hitungany[i];
                }
            }
            

        }
    }






}
