using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    string path = Application.persistentDataPath + "/save.dat";
    /**
     * reference script bahan makanan u ntuk digunakan ketika mensave game
     */
    public BahanMakanan bm;
    void Awake()
    {
        //code untuk load save file di dalam sini
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnApplicationFocus(bool hasFocus)
    {
        DataToSave data = new DataToSave();
    
        /**
         * mengesave bahan makanan
         */
        int bmCount = bm.getBanyakBM();
        for(int i = 0; i < bmCount; ++i)
        {
            string bmName = bm.getName(i);
            int bmRank = bm.getRankBM(i);
            int bmLevel = bm.getLevelBM(i);
            data.bmRankData.Add(bmName, bmRank);
            data.bmLevelData.Add(bmName, bmLevel);
        }

        File.WriteAllText(path, JsonUtility.ToJson(data));
    }

    void SaveProgress()
    {

    }
}
