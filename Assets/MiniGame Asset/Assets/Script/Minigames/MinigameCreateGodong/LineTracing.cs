using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MasakGodong;

public class LineTracing : MonoBehaviour
{
    NGonRenderer lines;
    int lineCount;
    float lineWidth;

    int currentLine;
    
    Camera cam;

    /**
     * this variable is used in order to store the time it takes for player
     * to complete the line tracing
     */
    float timeTaken;

    /**
     * define the time range on which player should finish the line tracing.
     * if player finishes slower then the result is burnt
     * if player finishses too fast, then th e result is raw
     * They are in the form of 
     */
    public float timeLower;
    public float timeHigher;

    public GameObject perfectGodong;
    public GameObject burntGodong;
    public GameObject rawGodong;
    public CookingGodongManager manager;

    bool doTracing;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        lines = GetComponent<NGonRenderer>(); 

        currentLine = -1;

        doTracing = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(!doTracing)
        {
            return;
        }
        if(currentLine >= 0) 
        {
            timeTaken += Time.deltaTime;
            if(timeTaken > timeHigher) 
            {
                burntGodong.SetActive(true);
                manager.TraceFail();
                doTracing = false;
            }
        }
    }

    public void HandleTouchBegin(Vector2 position) 
    {
        if(!doTracing)
        {
            return;
        }
        Vector2 touchWorldSpace = cam.ScreenToWorldPoint(position); 
        int temp = lines.PointInLines(touchWorldSpace);
        if(temp == 0)
        {
            currentLine = 0;
        }
    }

    public void HandleTouchMoved(Vector2 position) 
    {
        if(!doTracing)
        {
            return;
        }
        Vector2 touchWorldSpace = cam.ScreenToWorldPoint(position);
        int temp = lines.PointInLines(touchWorldSpace);
        if(temp < currentLine) 
        {
            rawGodong.SetActive(true);
            manager.TraceFail();
            doTracing = false;
        } 
        else 
        {
            currentLine = temp;
        }


        if(lines.IsLast(temp)) 
        {
            if(timeTaken < timeLower) 
            {
                rawGodong.SetActive(true);
                manager.TraceFail();
                doTracing = false;
            }
            else 
            {
                perfectGodong.SetActive(true);
                manager.TraceSucceed();
                doTracing = false;
            }
        }
    }

    public void HandleTouchStopped(Vector2 position) 
    {
        if(!doTracing || currentLine == -1 || perfectGodong.activeSelf)
        {
            return;
        }
        rawGodong.SetActive(true);
        manager.TraceFail();
        doTracing = false;
    }

    public void Reset()
    {
        burntGodong.SetActive(false);
        rawGodong.SetActive(false);
        perfectGodong.SetActive(false);
        timeTaken = 0;
        doTracing = true;
        currentLine = -1;
    }
}
