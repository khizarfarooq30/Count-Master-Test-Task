using System;
using GameAnalyticsSDK;
using UnityEngine;

public class AnalyticsManager : MonoBehaviour
{
    void Start()
    {
        GameAnalytics.Initialize();

        GameManager.Instance.OnGameStart += OnLevelStart;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnGameStart -= OnLevelStart;
    }

    private void OnLevelStart()
    {
        GameAnalytics.NewProgressionEvent 
            (GAProgressionStatus.Start, $"{PlayerPrefs.GetInt("Level")}"); 
    }
}
