using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CookingGodongManager : MonoBehaviour
{
    public LineTracing lineTracing;
    public GameObject[] lineHelper;
    
    [Header("UI Elements")]
    public TextMeshPro godongCountLabel;

    [Header("Mistakes")]
    public int failureCount;
    public GameObject[] mistakes;

    [Header("Result")]
    public GameObject cross;
    public GameObject checkmark;

    [Header("Result Fail")]
    public GameObject failParent;
    public TextMeshPro failFame;
    public TextMeshPro failCoin;

    [Header("Result Succeed")]
    public GameObject succeedParent;
    public GameObject succeedMist1;
    public GameObject succeedMist2;
    public GameObject succeedFame;
    public GameObject succeedCoin;
    public int godongCount;
    /**
     * 0 means minigame is still going on
     * 1 means minigame has failed
     * 2 means minigame has succeeded
     */
    int minigameStatus;

    bool resultActive;
    // Start is called before the first frame update
    void Start()
    {
        failureCount = 0;
        resultActive = false;
        /**
         * turning off the gameobject here
         * so that there's no mistakes made if
         * we were to forget to turn them off in the editor
         */
        for(int i = 0; i < mistakes.Length; ++i)
        {
            mistakes[i].SetActive(false);
        }
        cross.SetActive(false);
        checkmark.SetActive(false);
        godongCountLabel.text = godongCount.ToString();

        failParent.SetActive(false);

        succeedParent.SetActive(false);
        succeedMist1.SetActive(false);
        succeedMist2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TraceFail() 
    {
        if(resultActive)
        {
            return;
        }
        failureCount++;
        mistakes[failureCount - 1].SetActive(true);
        if(failureCount == 3)
        {
            TraceCompletedFail();
        }
        cross.SetActive(true);
        StartCoroutine(CoroutineShowResult());
        resultActive = true;

        godongCount -= 1;
        godongCountLabel.text = godongCount.ToString();
    }

    void TraceCompletedFail()
    {
        minigameStatus = 1;
        failParent.SetActive(true);
        MinigameManager miniManager = GameObject.FindWithTag("MinigameManager").GetComponent<MinigameManager>();
        miniManager.fromMinigame = true;
        miniManager.coinChanges = -250;
        miniManager.fameChanges = -25;
        failFame.text = miniManager.coinChanges.ToString();
        failCoin.text  = miniManager.fameChanges.ToString();
    }

    public void TraceSucceed() 
    {
        if(resultActive)
        {
            return;
        }
        checkmark.SetActive(true);
        godongCount -= 1;
        if(godongCount == 0)
        {
            TraceCompletedSucceed();
        }
        StartCoroutine(CoroutineShowResult());
        resultActive = true;

        godongCountLabel.text = godongCount.ToString();
    }

    void TraceCompletedSucceed()
    {
        MinigameManager miniManager = GameObject.FindWithTag("MinigameManager").GetComponent<MinigameManager>();
        minigameStatus = 2;
        succeedParent.SetActive(true);
        int coinAddition = 0;
        int famePercent = 0;
        if(failureCount == 0)
        {
            coinAddition = 450;
            famePercent = 100;
        }
        else if(failureCount > 0)
        {
            succeedMist1.SetActive(true);
            coinAddition = 350;
            famePercent = 75;
        }
        else if(failureCount > 1)
        {
            succeedMist2.SetActive(true);
            coinAddition = 150;
            famePercent = 25;
        }
        else if(failureCount > 2)
        {
            //this code shouldn't be possible to be entered
            Debug.Log("WITCH CRAFT");
        }

        /**
         * Handle minigame manager to be loaded from
         * main game scene
         */
        miniManager.fromMinigame = true;
        miniManager.fameChanges = (12 + miniManager.fameUpgrade) * famePercent;
        miniManager.fameChanges = miniManager.fameChanges / 100;
        miniManager.coinChanges = coinAddition;

        succeedFame.GetComponent<TMP_Text>().text = miniManager.fameChanges.ToString();
        succeedCoin.GetComponent<TMP_Text>().text = miniManager.coinChanges.ToString();
    }


    IEnumerator CoroutineShowResult()
    {
        lineTracing.gameObject.SetActive(false);
        foreach(var line in lineHelper)
        {
            line.SetActive(false);
        }
        yield return new WaitForSeconds(2);
        if(minigameStatus == 0)
        {
            lineTracing.Reset();
            cross.SetActive(false);
            checkmark.SetActive(false);
            lineTracing.gameObject.SetActive(true);
            foreach(var line in lineHelper)
            {
                line.SetActive(true);
            }
            resultActive = false;
        }
    }
}
