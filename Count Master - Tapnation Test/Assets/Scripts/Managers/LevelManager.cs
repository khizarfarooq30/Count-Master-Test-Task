using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance { get; private set; }
    
    private int levelNumber;

    private void Awake()
    {
        if (instance == null && instance != this)
        {
            instance = this;
        }
    }

    public void IncrementLevel()
    {
        levelNumber = PlayerPrefs.GetInt("Level");
        levelNumber++;
        PlayerPrefs.SetInt("Level", levelNumber);
    }
}