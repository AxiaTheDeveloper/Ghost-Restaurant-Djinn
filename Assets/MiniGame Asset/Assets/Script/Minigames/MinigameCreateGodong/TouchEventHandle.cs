using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MasakGodong {

public class TouchEventHandle : MonoBehaviour
{
    public LineTracing lineTracing;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0) 
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began) 
            {
                lineTracing.HandleTouchBegin(touch.position);
            } 
            else if(touch.phase == TouchPhase.Moved) 
            {
                lineTracing.HandleTouchMoved(touch.position);
            }
            else if(touch.phase == TouchPhase.Ended)
            {
                lineTracing.HandleTouchStopped(touch.position);
            }
        }
        if(Input.GetMouseButtonDown(0)) 
        {
            lineTracing.HandleTouchBegin(Input.mousePosition);
        }
    }
}

}
