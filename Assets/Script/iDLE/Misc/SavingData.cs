using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
class BMData
{
    public int[] level;
    public int[] rank;
}

[System.Serializable]
class TokoData
{
    public int[] level;
    public int[] rank;
}

[System.Serializable]
class GhostData
{
    public int[] level;
}

[System.Serializable]
class PlayerData
{
    public int coin;
    public int fp;
}

public class SavingData : MonoBehaviour
{
    public static int ghostCount;
    public static void SaveData(BahanMakanan bm, Toko t, GhostIdentity[] gi, Player p)
    {
        string basePath = Application.persistentDataPath;
        string bmPath = Path.Combine(basePath, "bm.dat");
        string tPath = Path.Combine(basePath, "t.dat");
        string ghostPath = Path.Combine(basePath, "g.dat");

        string pPath = Path.Combine(basePath, "p.dat");

        BMData bmData = new BMData();
        bmData.level = new int[bm.getBanyakBM()];
        bmData.rank = new int[bm.getBanyakBM()];

        for(int i = 0; i < bm.getBanyakBM(); ++i)
        {
            bmData.level[i] = bm.getLevelBM(i);
            bmData.rank[i] = bm.getRankBM(i);
        }

        TokoData tData = new TokoData();
        tData.level = new int[t.getBanyakToko()];
        tData.rank = new int[t.getBanyakToko()];

        for(int i = 0; i < t.getBanyakToko(); ++i)
        {
            tData.level[i] = t.getLevelToko(i);
            tData.rank[i] = t.getRankToko(i);
        }

        GhostData gData = new GhostData();
        gData.level = new int[ghostCount];
        for(int i = 0; i < ghostCount; ++i)
        {
            gData.level[i] = gi[i].getLevel();
        }

        PlayerData pData = new PlayerData();
        pData.coin = p.getKoin();
        pData.fp = p.getFP();

        File.WriteAllText(bmPath, JsonUtility.ToJson(bmData));
        File.WriteAllText(tPath, JsonUtility.ToJson(tData));
        File.WriteAllText(ghostPath, JsonUtility.ToJson(gData));
        File.WriteAllText(pPath, JsonUtility.ToJson(pData));


        // File.WriteAllText(bmPath, JsonUtility.ToJson(bm));
        // File.WriteAllText(tPath, JsonUtility.ToJson(t));

        // for(int i = 0; i < ghostCount; ++i)
        // {
        //     File.WriteAllText(ghostPath[i], JsonUtility.ToJson(gi[i]));
        // }

        // File.WriteAllText(pPath, JsonUtility.ToJson(p));
    }

    public static void LoadData(BahanMakanan bm, Toko t, GhostIdentity[] gi, Player p)
    {

        string basePath = Application.persistentDataPath;
        string bmPath = Path.Combine(basePath, "bm.dat");
        string tPath = Path.Combine(basePath, "t.dat");
        string ghostPath = Path.Combine(basePath, "g.dat");

        string pPath = Path.Combine(basePath, "p.dat");

        if(!File.Exists(bmPath))
        {
            return;
        }

        BMData bmData = JsonUtility.FromJson<BMData>(File.ReadAllText(bmPath));
        TokoData tData = JsonUtility.FromJson<TokoData>(File.ReadAllText(tPath));
        GhostData gData = JsonUtility.FromJson<GhostData>(File.ReadAllText(ghostPath));
        PlayerData pData = JsonUtility.FromJson<PlayerData>(File.ReadAllText(pPath));

        for(int i = 0; i < bmData.level.Length; ++i)
        {
            bm.setLevel(i, bmData.level[i]);
            bm.setRank(i, bmData.rank[i]);
        }

        for(int i = 0; i < tData.level.Length; ++i)
        {
            t.setLevel(i, tData.level[i]);
            t.setRankToko(i, tData.rank[i]);
        }

        for(int i = 0; i < ghostCount; ++i)
        {
            gi[i].setLevel(gData.level[i]);
        }

        p.setKoin(pData.coin);
        p.setFP(pData.fp);


        // string[] ghostPath = new string[ghostCount];
        // for(int i = 0; i < ghostCount; ++i)
        // {
        //     ghostPath[i] = Path.Combine(basePath, String.Format("Ghost{0}.dat", i));
        // }

        // string pPath = Path.Combine(basePath, "p.dat");

        // if(!File.Exists(bmPath))
        // {
        //     return;
        // }

        // BahanMakanan bmToLoad = JsonUtility.FromJson<BahanMakanan>(File.ReadAllText(bmPath));

        // for(int i = 0; i < bmToLoad.getBanyakBM(); ++i)
        // {
        //     bm.setLevel(i, bmToLoad.getLevelBM(i));
        //     bm.setRank(i, bmToLoad.getRankBM(i));
        // }

        // Toko tToLoad = JsonUtility.FromJson<Toko>(File.ReadAllText(tPath));

        // for(int i = 0; i < tToLoad.getBanyakToko(); ++i)
        // {
        //     t.setLevel(i, tToLoad.getLevelToko(i));
        //     t.setRankToko(i, tToLoad.getRankToko(i));
        // }

        // // GhostIdentity[] giToLoad = new GhostIdentity[ghostCount];
        // for(int i = 0; i < ghostCount; ++i)
        // {
        //     GhostIdentity temp = JsonUtility.FromJson<GhostIdentity>(File.ReadAllText(ghostPath[i]));
        //     gi[i].setLevel(temp.getLevel());
        // }

        // Player pToLoad = JsonUtility.FromJson<Player>(File.ReadAllText(pPath));
        
        // p.setKoin(pToLoad.getKoin());
        // p.setFP(pToLoad.getFP());
    }
}