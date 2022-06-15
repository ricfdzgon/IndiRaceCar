using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class ScoreData
{
    public string playerName;
    public double time;
    public string sceneName;

    public ScoreData(string playerName, double time, string sceneName)
    {
        this.playerName = playerName;
        this.time = time;
        this.sceneName = sceneName;
    }
}

[Serializable]
public class ScoreDataList
{
    public List<ScoreData> list = new List<ScoreData>();
}