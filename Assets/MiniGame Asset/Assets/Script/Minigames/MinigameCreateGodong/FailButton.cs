using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FailButton : MonoBehaviour
{
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
        SceneManager.LoadScene("Jakarta");
    }

    //-250 koin -25 fp
    

    //ini catetan buat 2-2nya
    //Ini nanti mending buat script baru yang dihubungin ke player, yg di mana scrptnya manggil function player yaitu changekoin() ama changeFP() - tiap minigame selesai gitu i guess

    //trus kalo ini kan takut si player cuma ada koin 100 doang atau fp bahkan ga ada, plg dicek kek kalo kurang dr itu, itu sisanya dijadiin 0 haha  -- buat cek fp ama koin player, ada di function di script player juga yaitu getkoin ama getfp
    //also bgm and sfx, itu disimpen di playerprefss di script musiccontrol, ud gua buatin scrit tersendiri utk yg di minigame
}
