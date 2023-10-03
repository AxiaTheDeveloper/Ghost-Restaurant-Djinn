using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockButton : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ghost;
    public GameObject locks1,locks2;
    GhostIdentity ghostid;
    int level;

    private void Awake() {
        ghostid = ghost.GetComponent<GhostIdentity>();
    }
    void Start()
    {
        locks1.gameObject.SetActive(true);
        locks2.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(locks1.gameObject.activeSelf){
            level = ghostid.getLevel();
            if(level == 1){
                locks1.gameObject.SetActive(false);
                locks2.gameObject.SetActive(false);
            }
        }
        
    }
}
