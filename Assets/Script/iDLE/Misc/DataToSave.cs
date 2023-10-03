using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DataToSave
{
    public class RankData: Dictionary<string, int> {}
    public class LevelData: Dictionary<string, int> {}

    /**
     * data simpanan buat bahan makanan
     */
    public RankData bmRankData = new RankData();
    public LevelData bmLevelData = new LevelData();
}