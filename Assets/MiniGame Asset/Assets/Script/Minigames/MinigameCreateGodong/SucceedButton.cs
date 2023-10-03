using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SucceedButton : MonoBehaviour
{
    public CookingGodongManager cookingManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        // MinigameManager miniManager = GameObject.FindWithTag("MinigameManager").GetComponent<MinigameManager>();
        // miniManager.fromMinigame = true;
        // int coinAddition = 0;
        // int famePercent = 0;
        // switch(cookingManager.failureCount)
        // {
        // case 0:
        //     coinAddition = 450;
        //     famePercent = 100;
        //     break;
        // case 1:
        //     coinAddition = 350;
        //     famePercent = 75;
        //     break;
        // case 2:
        //     coinAddition = 150;
        //     famePercent = 25;
        //     break;
        // }
        // Debug.Log(GameObject.FindWithTag("Gameplay"));
        SceneManager.LoadScene("Jakarta");
    }
    //fame poin dan koin dalam int
    //total koin yang dikasih 450 & total fame poin yg didapet 12 -> kalo menang semua, fame poin total juga ditambah dari upgrade ritual place

    //dapetin data ritual place ud kuambil dr script miniboss bagian YESLAYANI yg pas mau pindah scene


    //Salah 1 doang -> 350, 75%
    //Salah 2 -> 150 , 25%
      


    //ini catetan buat 2-2nya
    //Ini nanti mending buat script baru yang dihubungin ke player, yg di mana scrptnya manggil function player yaitu changekoin() ama changeFP() - tiap minigame selesai gitu i guess

    //trus kalo ini kan takut si player cuma ada koin 100 doang atau fp bahkan ga ada, plg dicek kek kalo kurang dr itu, itu sisanya dijadiin 0 haha  -- buat cek fp ama koin player, ada di function di script player juga yaitu getkoin ama getfp


    //also bgm and sfx, itu disimpen di playerprefss di script musiccontrol, ud gua buatin scrit tersendiri utk yg di minigame
    

}
