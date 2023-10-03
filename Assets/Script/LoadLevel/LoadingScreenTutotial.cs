using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoadingScreenTutotial : MonoBehaviour
{


    public GameObject[] tutorial;
    int xtutorial;
    public Slider slide;
    void Start()
    {
        // xtutorial = 0;
        slide.gameObject.SetActive(false);

    }
    public void loadPlace()
    {

        slide.gameObject.SetActive(true);
        StartCoroutine(LoadAsync("Jakarta"));
        
        
        // click.gameObject.SetActive(false);
        // slide.gameObject.SetActive(true);
        
    }
    IEnumerator LoadAsync(string nama){
        AsyncOperation operation = SceneManager.LoadSceneAsync(nama);
        
        while(!operation.isDone){
            float prog = Mathf.Clamp01(operation.progress / .9f);
            // Debug.Log(progress);
            slide.value = prog;

            yield return null;
        }
    }

    public void next(){

    }
}
