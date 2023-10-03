using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using UnityEngine;

public class CoinClick : MonoBehaviour
{

    Vector2 touchPosWorld;

    TouchPhase touchPhase = TouchPhase.Ended;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == touchPhase)
        {
            UnityEngine.Debug.Log("Touched");
            touchPosWorld = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

            Vector2 touchPosWorld2D = new Vector2(touchPosWorld.x, touchPosWorld.y);

            RaycastHit2D hitInformation = Physics2D.Raycast(touchPosWorld2D, Camera.main.transform.forward);

            if(hitInformation.collider != null)
            {
                GameObject touchedObject = hitInformation.transform.gameObject;

                UnityEngine.Debug.Log("Touched" + touchedObject.transform.name);
            }
        }
    }
    
}
