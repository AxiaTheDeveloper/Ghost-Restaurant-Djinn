using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] private string nama;
    [SerializeField] private string tempat;
    [SerializeField]private bool udaBeliPalembang;
    [SerializeField] private int koinDarah = 0 ;
    [SerializeField] private int famePoint = 0;
    private int hargaKerakTelorAwal = 1;
    private int hargaKerakTelorAkhir;

    public TextMeshProUGUI NilaiHarga, NilaiKoin, NilaiFP;
    public TextMeshProUGUI Nama, hargaT, koinT, FPT;

    public GameObject pegangan1,pegangan2,dropdown;
    public GameObject playernotenough;

    // Start is called before the first frame update
    void Start()
    {
        pegangan1.gameObject.SetActive(true);
        pegangan2.gameObject.SetActive(false);
        dropdown.gameObject.SetActive(false);

        playernotenough.gameObject.SetActive(false);
        
        if (PlayerPrefs.HasKey("boolTempat") == false)
        {
            
            PlayerPrefs.SetInt("boolTempat", 1);
            koinDarah = 1250;
            famePoint = 25;
            //loadLevel();
        }
        
        //ya ini ntr dibarengin ama kalo load save aja kali jd abis load save ditambah transfer
        if(tempat == "Palembang"){
            if(PlayerPrefs.HasKey("booltfPlg")){
                if(PlayerPrefs.GetInt("booltfPlg") == 1){
                    int x = PlayerPrefs.GetInt("totaltfPlg");
                    koinDarah += x;
                    Debug.Log("Ada Transfered!!");
                    PlayerPrefs.SetInt("booltfPlg", 0);
                    PlayerPrefs.SetInt("totaltfPlg", 0);
                }
            }
        }
        else{
            if(PlayerPrefs.HasKey("booltfJkt")){
                if(PlayerPrefs.GetInt("booltfJkt") == 1){
                    int x = PlayerPrefs.GetInt("totaltfJkt");
                    koinDarah += x;
                    Debug.Log("Ada Transfered!!");
                    PlayerPrefs.SetInt("booltfJkt", 0);
                    PlayerPrefs.SetInt("totaltfJkt", 0);
                }
            }
        }
        



        
        counting();
        Nama.text = nama.ToString();
        hargaT.text = hargaKerakTelorAkhir.ToString();
        koinT.text = koinDarah.ToString();
        FPT.text = famePoint.ToString();

        /**
         * loading data dari PersistentGameData setelah siap minigame
         */
        
        // GameObject.FindWithTag("Persistent").GetComponent<PersistentGameData>().player = GetComponent<Player>();
        
        LoadSave();
        InitiateAutoSave();
    }

    void LoadSave()
    {
        SavingData.ghostCount = 7;
        BahanMakanan bm = GetComponent<BahanMakanan>();
        Toko t = GetComponent<Toko>();

        GhostIdentity[] gi = new GhostIdentity[SavingData.ghostCount];
        gi[0] = t.Ghost1.GetComponent<GhostIdentity>();
        gi[1] = t.Ghost2.GetComponent<GhostIdentity>();
        gi[2] = t.Ghost3.GetComponent<GhostIdentity>();
        gi[3] = t.Ghost4.GetComponent<GhostIdentity>();
        gi[4] = t.Ghost5.GetComponent<GhostIdentity>();
        gi[5] = t.Ghost6.GetComponent<GhostIdentity>();
        gi[6] = t.Ghost7.GetComponent<GhostIdentity>();

        Player p = GetComponent<Player>();
        SavingData.LoadData(bm, t, gi, p);
    }

    void InitiateAutoSave()
    {
        InvokeRepeating("AutoSave", 0.0f, 60.0f);
    }

    void AutoSave()
    {
        BahanMakanan bm = GetComponent<BahanMakanan>();
        Toko t = GetComponent<Toko>();

        GhostIdentity[] gi = new GhostIdentity[SavingData.ghostCount];
        gi[0] = t.Ghost1.GetComponent<GhostIdentity>();
        gi[1] = t.Ghost2.GetComponent<GhostIdentity>();
        gi[2] = t.Ghost3.GetComponent<GhostIdentity>();
        gi[3] = t.Ghost4.GetComponent<GhostIdentity>();
        gi[4] = t.Ghost5.GetComponent<GhostIdentity>();
        gi[5] = t.Ghost6.GetComponent<GhostIdentity>();
        gi[6] = t.Ghost7.GetComponent<GhostIdentity>();

        Player p = GetComponent<Player>();

        SavingData.SaveData(bm, t, gi, p);
    }
    private void counting(){
        float harga, koin, fp;
        if(hargaKerakTelorAkhir >= 1000000000){
            harga = (float)hargaKerakTelorAkhir/1000000000;
            NilaiHarga.text = harga.ToString("F2") + " Ml";
        }
        else if(hargaKerakTelorAkhir >= 1000000){
            harga = (float)hargaKerakTelorAkhir/1000000;
            NilaiHarga.text = harga.ToString("F2") + " Jt";
        }
        else if(hargaKerakTelorAkhir >= 100000){
            harga = hargaKerakTelorAkhir/1000;
            NilaiHarga.text = harga.ToString() + " Rb";
        }
        else{
            NilaiHarga.text = hargaKerakTelorAkhir.ToString();
        }

        if(koinDarah >= 1000000000){
            koin = (float)koinDarah/1000000000;
            NilaiKoin.text = koin.ToString("F2") + " Ml";
        }
        else if(koinDarah >= 1000000){
            koin = (float)koinDarah/1000000;
            NilaiKoin.text = koin.ToString("F2") + " Jt";
        }
        else if(koinDarah >= 100000){
            koin = koinDarah/1000;
            NilaiKoin.text = koin.ToString() + " Rb";
        }
        else{
            NilaiKoin.text = koinDarah.ToString();
        }

        if(famePoint >= 1000000000){
            fp = (float)famePoint/1000000000;
            NilaiFP.text = fp.ToString("F2") + " Ml";
        }
        else if(famePoint >= 1000000){
            fp = (float)famePoint/1000000;
            NilaiFP.text = fp.ToString("F2") + " Jt";
        }
        else if(famePoint >= 100000){
            fp = famePoint/1000;
            NilaiFP.text = fp.ToString() + " Rb";
        }
        else{
            NilaiFP.text = famePoint.ToString();
        }

    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("Hargakeraktelor " + hargaKerakTelorAkhir);
        // Debug.Log(koinDarah);
        counting();
        Nama.text = nama.ToString();
        hargaT.text = hargaKerakTelorAkhir.ToString();
        koinT.text = koinDarah.ToString();
        FPT.text = famePoint.ToString();
    }

    public void dropdownn(){
        // Debug.Log("Clicked!!");
        pegangan1.gameObject.SetActive(false);
        dropdown.gameObject.SetActive(true);
        pegangan2.gameObject.SetActive(true);
    }

    public void tarikatas(){
        pegangan1.gameObject.SetActive(true);
        dropdown.gameObject.SetActive(false);
        pegangan2.gameObject.SetActive(false);
    }


    public int getKoin(){ //kalo org mo upgrade cek ini
        return koinDarah;
    }
    public void changeKoin(int koin){ //masukkin + - kalo mo pake
        koinDarah += koin;
    }
    public string gettempat(){
        return tempat;
    }
    public bool getBeliPalembang(){
        return udaBeliPalembang;
    }
    public void changePalembang(){
        udaBeliPalembang = true;
    }



    public int getFP(){ //kalo org mo upgrade cek ini
        return famePoint;
    }
    public void changeFP(int poin){ //masukkin + - kalo mo pake
        famePoint += poin;
    }

    //Kalo player ga punya uang cukup utk upgrade
    public void notEnough(){
        playernotenough.gameObject.SetActive(true);
    }
    public void okNotEnough(){
        playernotenough.gameObject.SetActive(false);
    }
    public void sudahMaxUpgrade(){
        //Ntr ada Canvas d sini yg blg not enough begitu.
    }

    public int getHarga(){ //Kalo org mo beli kan cek ini
        return hargaKerakTelorAkhir;
    }
    public void changeHarga(int hargaKT){ //masukkin + - kalo mo pake
        hargaKerakTelorAkhir = hargaKerakTelorAwal + hargaKT;
    }

    public void setKoin(int x)
    {
        koinDarah = x;
    }

    public void setFP(int x)
    {
        famePoint = x;
    }
}
