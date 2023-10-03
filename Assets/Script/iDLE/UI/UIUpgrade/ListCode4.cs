using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ListCode4 : MonoBehaviour
{
    //apakah punya palembang ? kalo tmptnya d palemabng ini jadiin yes aja
    Player players;
    public GameObject player;
    bool udabeliplmbng;
    [SerializeField]private int hargakoin,hargafamepoint;
    private int leveltf, levelbiaya, levelfamepoin, totalkoinpemain;

    public GameObject tempatSama, inginBeli, yakinBeli, udaBeli, Bank, tidakbisaBank, yakinTransfer, muteSFX, muteBGM, belumBeli;

    public GameObject pick1,pick2,pick3,pick4;
    [SerializeField]private TextMeshProUGUI tf, biaya, famepoin;

    public GameObject loadscreen;
    LoadingScreen2 load;

    public GameObject musiccontroler;
    MusicControl mc;

    private void Awake() {
        players = player.GetComponent<Player>();
        load = loadscreen.GetComponent<LoadingScreen2>();
        mc = musiccontroler.GetComponent<MusicControl>();
    }

    // Start is called before the first frame update
    void Start()
    {
        udabeliplmbng = players.getBeliPalembang();
        

        tempatSama.gameObject.SetActive(false);
        // bangun.gameObject.SetActive(false);
        inginBeli.gameObject.SetActive(false);
        yakinBeli.gameObject.SetActive(false);
        udaBeli.gameObject.SetActive(false);

        Bank.gameObject.SetActive(false);
        tidakbisaBank.gameObject.SetActive(false);
        belumBeli.gameObject.SetActive(false);
        yakinTransfer.gameObject.SetActive(false);
        pick1.gameObject.SetActive(false);
        pick2.gameObject.SetActive(false);
        pick3.gameObject.SetActive(false);
        pick4.gameObject.SetActive(false);
        leveltf = levelbiaya = levelfamepoin = 0;
        //Buat playerprefs~~
        
        if (PlayerPrefs.HasKey("saveBGM") == false)
        {
            muteSFX.gameObject.SetActive(false);

            muteBGM.gameObject.SetActive(false);
        }

        loadscreen.gameObject.SetActive(false);
    }

    //cuma buat d start aja
    public void muteSFXnya(){
        muteSFX.gameObject.SetActive(true);
    }
    public void muteBGMnya(){
        muteBGM.gameObject.SetActive(true);
    }



    

    //Kalo Klik Jakarta/Palembang (sesuai tempat - di button)
    public void tekanTempatSama(){
        tempatSama.gameObject.SetActive(true);
    }
    public void oktekanTempatSama(){
        tempatSama.gameObject.SetActive(false);
    }

    
    public void tekanBedaTempat(){
        //Kalo klik plmbng belum beli
        if(!udabeliplmbng){
            inginBeli.gameObject.SetActive(true);
        }
        else{
            //Kalo klik plmbng uda beli
            udaBeli.gameObject.SetActive(true);
        }
    }
    //kalo Palembang ga updet
    // public void sedangbangun(){
    //     bangun.gameObject.SetActive(false);
    // }
    //Kalo klik plmbng belum beli
    public void yestekaninginbeli(){
        inginBeli.gameObject.SetActive(false);
        yakinBeli.gameObject.SetActive(true);
    }
    public void notekaninginbeli(){
        inginBeli.gameObject.SetActive(false);
    }
    
    public void yesyakininginbeli(){
        yakinBeli.gameObject.SetActive(false);
        int koinplayer = players.getKoin();
        int fpplayer = players.getFP();
        if(koinplayer >= hargakoin && fpplayer >= hargafamepoint){
            players.changeKoin(-hargakoin);
            players.changeFP(-hargafamepoint);
            players.changePalembang();
            udabeliplmbng = true;
        }
        else{
            players.notEnough();
        }
    }
    public void noyakininginbeli(){
        yakinBeli.gameObject.SetActive(false);
    }

    //Kalo klik plmbng uda beli
    public void yesPindahTempat(){
        udaBeli.gameObject.SetActive(false);
        //
        if(players.gettempat() == "Jakarta"){
            PlayerPrefs.SetInt("boolTempat", 2);
            
        }
        else{
            PlayerPrefs.SetInt("boolTempat", 1);
        }
        loadscreen.gameObject.SetActive(true);
        load.loadPlace();
        
        //pindah ke scene lain~~
    }
    public void noPindahTempat(){
        udaBeli.gameObject.SetActive(false);
    }

    //Kalo klik plmbng uda beli
    public void BukaBank(){
        totalkoinpemain = players.getKoin();
        if(totalkoinpemain > 1000){
            Bank.gameObject.SetActive(true);
            pick1.gameObject.SetActive(true);
            pick2.gameObject.SetActive(false);
            pick3.gameObject.SetActive(false);
            pick4.gameObject.SetActive(false);
            
            hitungTransfer(totalkoinpemain,25,10);
        }
        else{
            tidakbisaBank.gameObject.SetActive(true);
        }
    }
    public void yesTransfer(){
        Bank.gameObject.SetActive(false);
        if(!players.getBeliPalembang()){
            belumBeli.gameObject.SetActive(true);
        }
        else{
            yakinTransfer.gameObject.SetActive(true);
        }
        
    }
    public void okbelumbeli(){
        belumBeli.gameObject.SetActive(false);
    }
    public void noTransfer(){
        Bank.gameObject.SetActive(false);
    }
    private void masukTextBank(){
        tf.text = leveltf.ToString();
        biaya.text = levelbiaya.ToString();
        famepoin.text = levelfamepoin.ToString();
    }

    private void hitungTransfer(int koin, int persen, int potong){
        leveltf = koin*persen/100;
        levelbiaya = leveltf*potong/100;
        if(leveltf <= 100000 ){
            levelfamepoin = 5;
        }
        else if(leveltf > 100000 && leveltf <= 1000000){
            levelfamepoin = 15;
        }
        else if(leveltf > 1000000 && leveltf <= 10000000){
            levelfamepoin = 25;
        }
        else if(leveltf > 10000000 && leveltf <= 100000000){
            levelfamepoin = 40;
        }
        else if(leveltf > 100000000 && leveltf <= 1000000000){
            levelfamepoin = 55;
        }
        else if(leveltf > 1000000000){
            levelfamepoin = 75;
        }
        masukTextBank();
    }

    public void pickp1(){
        pick1.gameObject.SetActive(true);
        pick2.gameObject.SetActive(false);
        pick3.gameObject.SetActive(false);
        pick4.gameObject.SetActive(false);
        hitungTransfer(totalkoinpemain,25,10);
    }
    public void pickp2(){
        pick1.gameObject.SetActive(false);
        pick2.gameObject.SetActive(true);
        pick3.gameObject.SetActive(false);
        pick4.gameObject.SetActive(false);
        hitungTransfer(totalkoinpemain,50,15);
    }
    public void pickp3(){
        pick1.gameObject.SetActive(false);
        pick2.gameObject.SetActive(false);
        pick3.gameObject.SetActive(true);
        pick4.gameObject.SetActive(false);
        hitungTransfer(totalkoinpemain,75,20);
    }
    public void pickp4(){
        pick1.gameObject.SetActive(false);
        pick2.gameObject.SetActive(false);
        pick3.gameObject.SetActive(false);
        pick4.gameObject.SetActive(true);
        hitungTransfer(totalkoinpemain,100,25);
    }
    public void TutupBank(){
        Bank.gameObject.SetActive(false);
    }

    public void okBank(){
        tidakbisaBank.gameObject.SetActive(false);
    }

    public void yesyakintransfer(){
        yakinTransfer.gameObject.SetActive(false);
        int fpplayer = players.getFP();
        
        if(fpplayer >= levelfamepoin){
            players.changeKoin(-leveltf);
            players.changeFP(-levelfamepoin);
            string place = players.gettempat();
            leveltf -= levelbiaya;
            if(place == "Jakarta"){
                PlayerPrefs.SetInt("booltfPlg", 1);
                PlayerPrefs.SetInt("totaltfPlg", leveltf);
                Debug.Log("Transfered!!");
               
            }
            else if(place == "Palembang"){
                PlayerPrefs.SetInt("booltfJkt", 1);
                PlayerPrefs.SetInt("totaltfJkt", leveltf);
                Debug.Log("Transfered!!");
                
            }
        }
        else{
            players.notEnough();
        }
        

    }
    public void noyakintransfer(){
        yakinTransfer.gameObject.SetActive(false);
    }


    //ini entar ya ada pengaturan musik, bgm ya bgm 1 aja, sfx ya sfx aja 1 aja sfx koin, ama sfx boss i guess
    public void muteBGm(){
        mc.turnoffBGM();
        muteBGM.gameObject.SetActive(true);
        
    }
    public void unmuteBGm(){
        mc.turnonBGM();
        muteBGM.gameObject.SetActive(false);
        
    }
    public void muteSFx(){
        mc.turnoffSFX();
        muteSFX.gameObject.SetActive(true);
        
    }
    public void unmuteSFx(){
        mc.turnonSFX();
        muteSFX.gameObject.SetActive(false);
    }
}
