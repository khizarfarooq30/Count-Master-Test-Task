using UnityEngine;

public class PlayerController : MonoBehaviour
{
   [SerializeField] private PlayerCrowd playerCrowd;
   [SerializeField] private Transform levelEndTransform;
   
   [SerializeField] private float moveSpeed = 5f;
   [SerializeField] private float swerveSpeed = 5f;
   [SerializeField] private float clampPosX = 3f;
   
   private Transform playerTransform;
   
   private Vector3 screenTouchStartPos;
   private Vector3 screenTouchCurrentPos;
   private Vector3 playerStartPos;

   private bool startGame;


   private float levelDistance;
   private UIManager uiManager;
   

   private void Start()
   {
      playerTransform = transform;

      levelDistance = Vector3.Distance(playerTransform.position, levelEndTransform.position);
      
      uiManager = UIManager.Instance;

      GameManager.Instance.OnGameFail += EndLevel;
      GameManager.Instance.OnGameWin += EndLevel;
      GameManager.Instance.OnGameStart += StartGame;
   }


   private void OnDisable()
   {
      GameManager.Instance.OnGameFail -= EndLevel;   
      GameManager.Instance.OnGameWin -= EndLevel;
      GameManager.Instance.OnGameStart -= StartGame;
   }


   private void StartGame()
   {
      startGame = true;
   }

   private void EndLevel()
   {
      moveSpeed = 0f;
      playerCrowd.enabled = false;
      enabled = false;
   }

   private void Update()
   {
      if(!startGame) return;

      HandleForwardMovement();
      HandleSwerveMovement();
   }

   private void HandleSwerveMovement()
   {
      if (Input.GetMouseButtonDown(0))
      {
         screenTouchStartPos = Input.mousePosition;
         playerStartPos = transform.position;
      }
      else if (Input.GetMouseButton(0))
      {
         screenTouchCurrentPos = Input.mousePosition - screenTouchStartPos;
         screenTouchCurrentPos.x *= swerveSpeed / Screen.width;

         var position = playerTransform.position;
        
         position.x = screenTouchCurrentPos.x + playerStartPos.x;
         position.x = Mathf.Clamp(position.x, -clampPosX + playerCrowd.GetCrowdRadius(),
            clampPosX - playerCrowd.GetCrowdRadius());
         
         playerTransform.position = position;

         uiManager.SetLevelProgressFillAmount(position.z / levelDistance);
      }
   }

   private void HandleForwardMovement()
   {
      playerTransform.position += moveSpeed * Time.deltaTime * Vector3.forward;
      
   }

}
