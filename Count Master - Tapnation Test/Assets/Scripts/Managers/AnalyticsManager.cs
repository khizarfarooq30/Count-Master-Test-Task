using System;
using GameAnalyticsSDK;
using UnityEngine;

public class AnalyticsManager : MonoBehaviour
{
    void Start()
    {
        GameAnalytics.Initialize();

        GameManager.Instance.OnGameStart += OnLevelStart;
        GameManager.Instance.OnGameFail += OnLevelFail;
        GameManager.Instance.OnGameWin += OnLevelComplete;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnGameStart -= OnLevelStart;
        GameManager.Instance.OnGameFail -= OnLevelFail;
        GameManager.Instance.OnGameWin -= OnLevelComplete;
    }

    private void OnLevelStart()
    {
        GameAnalytics.NewProgressionEvent 
            (GAProgressionStatus.Start, $"{PlayerPrefs.GetInt("Level")}"); 
    }
    
    private void OnLevelFail()
    {
        GameAnalytics.NewProgressionEvent 
            (GAProgressionStatus.Fail, $"{PlayerPrefs.GetInt("Level")}"); 
    }
    
    private void OnLevelComplete()
    {
        GameAnalytics.NewProgressionEvent 
            (GAProgressionStatus.Complete, $"{PlayerPrefs.GetInt("Level")}"); 
    }
}
