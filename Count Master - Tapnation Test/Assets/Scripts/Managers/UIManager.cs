using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
   public static UIManager Instance { get; private set; }

   [SerializeField] private GameObject inGamePanel;
   
   [SerializeField] private Image levelProgressImage;
   [SerializeField] private TextMeshProUGUI levelText;
   
   [SerializeField] private CanvasGroup levelFailCanvasGroup;
   [SerializeField] private CanvasGroup levelWinCanvasGroup;


   private void Awake()
   {
      if (Instance == null && Instance != this)
      {
         Instance = this;
      }
   }

   private void Start()
   {
      GameManager.Instance.OnGameWin += OnGameWin;
      GameManager.Instance.OnGameFail += OnGameFail;
      
      levelText.SetText($"Level {PlayerPrefs.GetInt("Level") + 1}");
   }

   private void OnDisable()
   {
      GameManager.Instance.OnGameWin -= OnGameWin;
      GameManager.Instance.OnGameFail -= OnGameFail;
   }

   private void OnGameWin()
   {
      inGamePanel.SetActive(false);
      levelWinCanvasGroup.gameObject.SetActive(true);
      levelWinCanvasGroup.DOFade(1f, 1f);
   }
   
   private void OnGameFail()
   {
      inGamePanel.SetActive(false);
      levelFailCanvasGroup.gameObject.SetActive(true);
      levelFailCanvasGroup.DOFade(1f, 1f);
   }

   public void SetLevelProgressFillAmount(float newAmount)
   {
      levelProgressImage.fillAmount = newAmount;
   }
}
