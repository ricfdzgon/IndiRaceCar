using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class ScoreData : IComparable<ScoreData>
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

    public int CompareTo(ScoreData otherScoreData)
    {
        if (this.time > otherScoreData.time)
        {
            return 1;
        }
        else if (this.time == otherScoreData.time)
        {
            return 0;
        }
        return -1;
    }
}

[Serializable]
public class ScoreDataList
{
    public List<ScoreData> list = new List<ScoreData>();
}