using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
   [SerializeField] private Animator animator;
   private static readonly int Run1 = Animator.StringToHash("Run");
   private static readonly int Win = Animator.StringToHash("Win");

   private void Start()
   {
      GameManager.Instance.OnGameStart += Run;
      GameManager.Instance.OnGameWin += OnGameWin;
   }

  
   private void OnDisable()
   {
      GameManager.Instance.OnGameStart -= Run;
      GameManager.Instance.OnGameWin -= OnGameWin;
   }

   public void Run()
   {
      animator.SetTrigger(Run1);
   }
   
   private void OnGameWin()
   {
      animator.SetTrigger(Win);
   }

}
