using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePersistent
{
    private static ScorePersistent _instance;
    private static float _RecentScore = -1;

    public static ScorePersistent Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new ScorePersistent();
            }
            return _instance;
        }
    }

    public static float RecentScore
    {
        get
        {
            return _RecentScore;
        }

        set
        {
            _RecentScore = value;
        }
    }
}
