using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutoButton : MonoBehaviour
{
    // Start is called before the first frame update
     public void loadPlace()
    {
        
        StartCoroutine(LoadAsync("Jakarta"));
        
        
        // click.gameObject.SetActive(false);
        // slide.gameObject.SetActive(true);
        
    }
    IEnumerator LoadAsync(string nama){
        AsyncOperation operation = SceneManager.LoadSceneAsync(nama);
        
        while(!operation.isDone){
            // float prog = Mathf.Clamp01(operation.progress / .9f);
            // Debug.Log(progress);
            // slide.value = prog;

            yield return null;
        }
    }
}
