using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private Transform playerCrowdParent;
    
    public Action OnGameStart;
    public Action OnGameWin;
    public Action OnReachLevelEnd;
    public Action OnGameFail;

    private bool isLevelEndReached;
    
    
    private void Awake()
    {
        if (Instance == null && Instance != this)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        Application.targetFrameRate = 120;
        QualitySettings.vSyncCount = 0;
        
        PlayerCrowd.OnSubractCrowd += CheckGameResult;
    }

    private void OnDisable()
    {
        DOTween.KillAll();
        PlayerCrowd.OnSubractCrowd -= CheckGameResult;
    }

    public static void GameFail()
    {
        if(Instance.isLevelEndReached) return;
        Instance.OnGameFail?.Invoke();
    }

    public static void GameStart()
    {
        Instance.OnGameStart?.Invoke();
    }
    
    public static void GameWin()
    {
        Instance.OnGameWin?.Invoke();
    }
    
    public static void ReachedLevelEnd()
    {
        Instance.isLevelEndReached = true;
        PlayerCrowd.OnSubractCrowd -= Instance.CheckGameResult;
        Instance.OnReachLevelEnd?.Invoke();
    }
    
    private void CheckGameResult()
    {
        if(Instance.isLevelEndReached) return;
        
        if (playerCrowdParent.childCount <= 0)
        {
            GameFail();
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        LevelManager.instance.IncrementLevel();

        int currentBuildIndex = SceneManager.GetActiveScene().buildIndex;
        currentBuildIndex++;
        currentBuildIndex %= SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene(currentBuildIndex);
    }
}
