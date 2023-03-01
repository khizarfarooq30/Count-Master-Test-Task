using TMPro;
using UnityEngine;

public class PlayerCrowdCounter : MonoBehaviour
{
    [SerializeField] private TextMeshPro counterText;

    private void Start()
    {
        GameManager.Instance.OnGameStart += OnGameStart;
        GameManager.Instance.OnGameWin += OnGameEnd;
        GameManager.Instance.OnGameFail += OnGameEnd;
    }


    private void OnDisable()
    {
        GameManager.Instance.OnGameStart -= OnGameStart;
        GameManager.Instance.OnGameWin -= OnGameEnd;
        GameManager.Instance.OnGameFail -= OnGameEnd;
    }

    private void OnGameStart()
    {
        ShowCounter();
    }

    private void OnGameEnd()
    {
        HideCounter();
    }

    private void ShowCounter()
    {
        gameObject.SetActive(true);
    }

    private void HideCounter()
    {
        gameObject.SetActive(false);
    }

    public void SetCrowdCounterText(int count)
    {
        counterText.SetText(count.ToString());
    }
}
