using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public float chaseRadius = 1f;
    public float chaseSpeed = 2f;

    [SerializeField] private float attackRadius = 1f;
    [SerializeField] private float attackCooldown = 1f;
    [SerializeField] private int damageAmount = 1;

    private EnemyState currentState;
    private float lastAttackTime = -Mathf.Infinity;

    void Start()
    {
        ChangeState(new IdleState(this));
    }

    void Update()
    {
        currentState.Update();
        CheckAttack();
    }

    public void ChangeState(EnemyState newState)
    {
        if (currentState != null)
            currentState.Exit();

        currentState = newState;
        currentState.Enter();
    }

    private void CheckAttack()
    {
        if (player == null) return;
        float distance = Vector2.Distance(transform.position, player.position);
        if (distance < attackRadius && Time.time >= lastAttackTime + attackCooldown)
        {
            DoDamageToPlayer();
            lastAttackTime = Time.time;
        }
    }

    private void DoDamageToPlayer()
    {
        PlayerController playerMovement = player.GetComponent<PlayerController>();
        if (playerMovement != null)
        {
            playerMovement.TakeDamage(damageAmount);
        }
    }
}
