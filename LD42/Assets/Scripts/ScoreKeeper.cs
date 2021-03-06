﻿using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    public Text ScoreValText = null;

    public float _ScoreVal = 0;

    private void OnEnable()
    {
        _ScoreVal = 0;
        ScoreValText.text = _ScoreVal.ToString("0");
    }

    private void OnDisable()
    {
        ScorePersistent.RecentScore = _ScoreVal;
    }

    private void Update()
    {
        if (TimeAuthority.DeltaTime != 0.0f)
        {
            _ScoreVal += (2.0f * TimeAuthority.DeltaTime);
            ScoreValText.text = _ScoreVal.ToString("0");
        }
    }
}
