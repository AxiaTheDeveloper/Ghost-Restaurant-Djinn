using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBehavio : MonoBehaviour
{
    [SerializeField] private Transform pos1, tengah1, tengah2, pos2;
    GhostIdentity GhostID;
    // private int KerakTelor;//Mikir dl..
    private float waktuDatang;

    private Vector3 tujuan;
    private float simpanWaktu1,simpanWaktu2,simpanWaktu3,timer;//bagi jam jd 3, jd 1 buat awal ke tengah, 2 nunggu tengah bntr,3 tengah ke akhir

    public bool adaUpgrade1; //gabisa minta dr sebelah, soalnya lsg ke false, eh tp gatau de...


    private int numberRandom;
    private float kecepatan, jarak11, jarak12, jarak21, jarak22;


    //sprite object
    public GameObject gambar1, gambar2;

    [SerializeField] private AudioSource koin;


    private void Awake() {
        GhostID = GetComponentInParent<GhostIdentity>();
    }
    // Start is called before the first frame update
    void Start()
    {
        jarak11 = pos1.position.x - tengah1.position.x;//DARI KIRI
        jarak12 = tengah1.position.x - pos2.position.x;//DARI KIRI
        jarak21 = tengah2.position.x - pos2.position.x;//DARI KANAN
        jarak22 = pos1.position.x - tengah2.position.x;//DARI KANAN
        hitung();
        tujuan = pos1.position;
        adaUpgrade1 = false;
        numberRandom = 1;

        gambar1.gameObject.SetActive(true);
        gambar2.gameObject.SetActive(false);
        // kecepatan = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(KerakTelor);
        // Debug.Log(waktuDatang);
        
        if(GhostID.getLevel() >= 1){
            if(adaUpgrade1 && (transform.position == pos1.position ||transform.position == pos2.position)) {
                hitung(); // kalo ada upgrade hrs hitung ulang dl tp kalo si target dh nyampe posisi
                adaUpgrade1 = false;
                // Debug.Log(adaUpgrade1);
            }
            else if(transform.position == pos1.position ||transform.position == pos2.position){
                if(numberRandom == 2){
                    transform.Rotate(0, 180, 0);
                }
                gambar1.gameObject.SetActive(true);
                gambar2.gameObject.SetActive(false);
                numberRandom = Random.Range(1,3);
                // Debug.Log("2gas");
                // Debug.Log("1" + numberRandom);
                if(numberRandom == 1){
                    transform.position = pos1.position;
                    kecepatan = jarak11/simpanWaktu1;
                    tujuan = tengah1.position;
                    
                    
                    //INI NTR ROTASI JGN LUPA 
                }
                else{
                    transform.position = pos2.position;
                    kecepatan = jarak21/simpanWaktu1;
                    tujuan = tengah2.position;
                    transform.Rotate(0, 180, 0);
                    //INI NTR ROTASI JGN LUPA 
                }
                // Debug.Log(kecepatan + " " + simpanWaktu1 + jarak11 + jarak21);
                
            }
            else if(transform.position == tengah1.position || transform.position == tengah2.position){
                //WAIT
                timer -= Time.deltaTime;
                if(timer <=0){
                    GhostID.beli();
                    timer = simpanWaktu2;
                    gambar2.gameObject.SetActive(true);
                    gambar1.gameObject.SetActive(false);
                    koin.Play();
                    if(numberRandom == 1){
                        kecepatan = jarak12/simpanWaktu3;
                        tujuan = pos2.position;
                            
                    }
                    else if(numberRandom == 2){
                        kecepatan = jarak22/simpanWaktu3;
                        tujuan = pos1.position;
                    }
                        
                }

                    
            }
            move();
        }
        // else{
        //     kecepatan = 0;
        // }
        


    }

    public Vector3 getTujuan(){
        return tujuan;
    }
    void move(){
        transform.position = Vector3.MoveTowards(transform.position, tujuan, kecepatan * Time.deltaTime);
        // Debug.Log("Maju " + kecepatan +" "+ tujuan);
    }


    void hitung(){
        // KerakTelor = GhostID.getKerakTelor();
        waktuDatang = GhostID.getWaktuDatang();


        simpanWaktu1 = waktuDatang/2;
        simpanWaktu3 = waktuDatang - simpanWaktu1;
        simpanWaktu2 = simpanWaktu3/2;
        timer = simpanWaktu2;
        simpanWaktu3 = simpanWaktu3-simpanWaktu2;
    }
}
