using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBawah : MonoBehaviour
{
    //UI
    [SerializeField] private GameObject BahanMakananOption;
    [SerializeField] private GameObject TokoOption;
    [SerializeField] private GameObject PromosiOption;
    [SerializeField] private GameObject EmpatOption;
    
    
    // Start is called before the first frame update
    void Start()
    {
        BahanMakananOption.gameObject.SetActive(true);
        TokoOption.gameObject.SetActive(false);
        PromosiOption.gameObject.SetActive(false);
        EmpatOption.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BMOption(){
        BahanMakananOption.gameObject.SetActive(true);
        TokoOption.gameObject.SetActive(false);
        PromosiOption.gameObject.SetActive(false);
        EmpatOption.gameObject.SetActive(false);
    }
    public void TKOption(){
        BahanMakananOption.gameObject.SetActive(false);
        TokoOption.gameObject.SetActive(true);
        PromosiOption.gameObject.SetActive(false);
        EmpatOption.gameObject.SetActive(false);
    }
    public void POption(){
        BahanMakananOption.gameObject.SetActive(false);
        TokoOption.gameObject.SetActive(false);
        PromosiOption.gameObject.SetActive(true);
        EmpatOption.gameObject.SetActive(false);
    }
    public void EOption(){
        BahanMakananOption.gameObject.SetActive(false);
        TokoOption.gameObject.SetActive(false);
        PromosiOption.gameObject.SetActive(false);
        EmpatOption.gameObject.SetActive(true);
    }
}

