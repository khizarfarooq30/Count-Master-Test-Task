using System;
using UnityEngine;

public class EnemyController : MonoBehaviour
{ 
    [SerializeField] private Animator animator;
    [SerializeField] private ParticleSystem killEffect;
    
    [SerializeField] private float speed = 10f;
    [SerializeField] private float targetDetectRadius = 5f;
    [SerializeField] private LayerMask targetMask;

    private PlayerTarget target;

    private bool isRunning;
    private static readonly int Run = Animator.StringToHash("Run");

    private EnemyCrowd enemyCrowd;

    private bool hasDetected;
    
    private enum EnemyState
    {
        Idle,
        Chase
    }

    private EnemyState enemyState = EnemyState.Idle;

    private void Awake()
    {
        enemyCrowd = GetComponentInParent<EnemyCrowd>();
    }

    private void Update()
    {
        switch (enemyState)
        {
           
            case EnemyState.Chase:
                ChasePlayer();
                break;
        }
    }

    private void LateUpdate()
    {
        switch (enemyState)
        {
            case EnemyState.Idle:
                LookForPlayer();
                break;
        }
    }

    private void LookForPlayer()
    {
        if(hasDetected) return;

        Collider[] nearbyTargets = Physics.OverlapSphere(transform.position, targetDetectRadius, targetMask);

        for (int i = 0; i < nearbyTargets.Length; i++)
        {
            if (nearbyTargets[i].TryGetComponent(out PlayerTarget playerTarget))
            {
                if (playerTarget.hasDetected) continue;
                playerTarget.hasDetected = true;
                if (!hasDetected)
                {
                    hasDetected = true;
                    target = playerTarget;
                    enemyState = EnemyState.Chase;
                }
            }
        }
    }

    private void ChasePlayer()
    {
        if (target)
        {
            if (!isRunning)
            {
                isRunning = true;
                animator.SetTrigger(Run);
            }
            
            var targetPos = target.transform.position;
            var currentPos = transform.position;

            float distance = Vector3.Distance(targetPos, currentPos);

            transform.LookAt(targetPos);
            
            transform.position = Vector3.MoveTowards(currentPos, targetPos, speed * Time.deltaTime);
            target.transform.position = Vector3.MoveTowards(targetPos, currentPos, speed * Time.deltaTime);
            
            if (distance < 0.5f)
            {
                target.Kill();
                enemyCrowd.KillEnemy();

                killEffect.transform.parent = null;
                killEffect.Play();
                
                Destroy(gameObject);
            }
        }
    }


#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, targetDetectRadius);
    }
#endif
   
}