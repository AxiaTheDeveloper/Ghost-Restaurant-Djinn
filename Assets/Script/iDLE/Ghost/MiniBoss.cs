using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class MiniBoss : MonoBehaviour
{
    [SerializeField] private  float waktuDatangAwal;
    [SerializeField] private  int negatifLambatAwal;
    [SerializeField] private  float negatifKurangAwal;
    private  float waktuDatangAkhir;
    private  int negatifLambatAkhir;
    private  float negatifKurangAkhir;
    [SerializeField] private  int famepoinGiftxtotal = 10; // poin lipet
    [SerializeField] private  int famepoinGiftytotal = 12;//poin masak

    bool adaupgradeToko, udasampe;

    public GameObject player;
    Toko tokoupgrade;

    // gerak
    [SerializeField] private Transform pos1, pos2;
    // private Vector3 tujuan;
    private float simpanWaktu1,timer;
    [SerializeField]private float simpanWaktu2;
    private float kecepatan, jarak1;


    public GameObject yesnoquestion;
    public GameObject buttonghost;


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
    int n;//biar ngitung ga berkali kali...


    [SerializeField] private AudioSource SFXdatang;
    private void Awake() {
        tokoupgrade = player.GetComponent<Toko>();

        G1 = Ghost1.GetComponent<GhostIdentity>();
        G2 = Ghost2.GetComponent<GhostIdentity>();
        G3 = Ghost3.GetComponent<GhostIdentity>();
        G4 = Ghost4.GetComponent<GhostIdentity>();
        G5 = Ghost5.GetComponent<GhostIdentity>();
        G6 = Ghost6.GetComponent<GhostIdentity>();
        G7 = Ghost7.GetComponent<GhostIdentity>();
    }

    [SerializeField]private TextMeshProUGUI miniT,lambatT,kurangT;

    public GameObject gambar;

    // Start is called before the first frame update 
    void Start()
    {
        jarak1 = pos1.position.x - pos2.position.x;
        adaupgradeToko = false;
        udasampe = false;
        // simpanWaktu2 = 250;
        kecepatan = jarak1/simpanWaktu2;
        hitungboss();
        n = 0;

        yesnoquestion.gameObject.SetActive(false);
        buttonghost.gameObject.SetActive(false);

        miniT.text = waktuDatangAkhir.ToString();
        lambatT.text = '+' + negatifLambatAkhir.ToString();
        kurangT.text = '+' + negatifKurangAkhir.ToString();
        gambar.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        miniT.text = waktuDatangAkhir.ToString() + " s";
        lambatT.text = '+' + negatifLambatAkhir.ToString() + " %";
        kurangT.text = '-' + negatifKurangAkhir.ToString() + " %";
        if(adaupgradeToko){
            adaupgradeToko = false;
            hitungboss();
            sampai();
        }
        
        if(transform.position != pos2.position){
            n = 1;
        }
        if(transform.position == pos1.position && timer > 0){
            timer -= Time.deltaTime;
        }
        else if(timer <= 0){
            move();
            gambar.gameObject.SetActive(true);
        }

        if(transform.position == pos2.position){
            timer = simpanWaktu1;
            udasampe = true;
            
            if(n==1){
                SFXdatang.Play();
                sampai();
                n= n-1;;
                // Debug.Log("n = "+ n);
                buttonghost.gameObject.SetActive(true);
            }
            
        }
    }

    public float getnegatifkurang(){
        if(udasampe){
            return negatifKurangAkhir;
        }
        else{
            return 0;
        }
    }

    public int getnegatiflambat(){
        if(udasampe){
            return negatifLambatAkhir;
        }
        else{
            return 0;
        }
    }

    public void sampai(){
        G1.count();
        G2.count();
        G3.count();
        G4.count();
        G5.count();
        G6.count();
        G7.count();

        G1.dtg();
        G2.dtg();
        G3.dtg();
        G4.dtg();
        G5.dtg();
        G6.dtg();
        G7.dtg();
    }

    public void adaupToko(bool tokosx){
        adaupgradeToko = tokosx;
    }

    public void opentab(){
        yesnoquestion.gameObject.SetActive(true);
        // gameobject
    }
    public void yeslayani(){
        // code utk next scene, yg nanti di random antara minigame 1 ato 2
        // trus tutup gameobjectnya
        // SFXdatang.Stop();
        yesnoquestion.gameObject.SetActive(false);
        buttonghost.gameObject.SetActive(false);
        gambar.gameObject.SetActive(false);
        transform.position = pos1.position;
        udasampe = false;
        sampai();


        //Inidata dari si ritualplace
        int upgradeakhirtokoritual = tokoupgrade.getDataMiniGame(1);
        MinigameManager miniManager = GameObject.FindWithTag("MinigameManager").GetComponent<MinigameManager>();
        miniManager.fameUpgrade = upgradeakhirtokoritual;
        SceneManager.LoadScene("MinigameCookingGodong");
    }

    public void nolayani(){
        
        //tutup gameobjectnya
        yesnoquestion.gameObject.SetActive(false);
        
    }

    void hitungboss(){
        int sesajen = tokoupgrade.getDataInt(5);
        float ritual = tokoupgrade.getDataFloat(6);
        float SDT = tokoupgrade.getDataFloat(7);

        int minibungkus = tokoupgrade.getDataMiniGame(0);
        int minimasak = tokoupgrade.getDataMiniGame(1);


        waktuDatangAkhir = waktuDatangAwal - SDT;
        negatifKurangAkhir = negatifKurangAwal - ritual;
        negatifLambatAkhir = negatifLambatAwal - sesajen;
        famepoinGiftxtotal -= minibungkus;
        famepoinGiftytotal -= minimasak;

        simpanWaktu1 = waktuDatangAkhir - simpanWaktu2;
        timer = simpanWaktu1;
    }

    void move(){
        transform.position = Vector3.MoveTowards(transform.position, pos2.position, kecepatan * Time.deltaTime);
        // Debug.Log("Maju " + kecepatan +" "+ tujuan);
    }
}
