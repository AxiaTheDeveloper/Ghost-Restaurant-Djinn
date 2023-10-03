using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameplay : MonoBehaviour
{
    public static GameObject instance = null;
    // Start is called before the first frame update
    void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = gameObject;
            DontDestroyOnLoad(this);
        }
    }
    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "MinigameCookingGodong")
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
            MinigameManager miniManager = GameObject.FindWithTag("MinigameManager").GetComponent<MinigameManager>();
            if(miniManager.fromMinigame)
            {
                miniManager.fromMinigame = false;
                Player player = GetComponentInChildren<Player>();
                int koin = player.getKoin();
                int famep = player.getFP();
                int cekkoin = miniManager.coinChanges;
                int cekfp = miniManager.fameChanges;
                if(cekkoin < 0){
                    cekkoin*= -1;
                    if(koin >= cekkoin){
                        player.changeKoin(miniManager.coinChanges);
                    }
                }
                else{
                    player.changeKoin(miniManager.coinChanges);
                }
                if(cekfp < 0){
                    cekfp*= -1;
                    if(famep >= cekfp){
                        player.changeFP(miniManager.fameChanges);
                    }
                }
                else{
                    player.changeFP(miniManager.fameChanges);
                }
                
                
                
            }
        }
    }
}
