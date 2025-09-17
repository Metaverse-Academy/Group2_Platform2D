using UnityEngine;

public class ChaseState : EnemyState
{
    public ChaseState(Enemy enemy) : base(enemy) { }

    public override void Enter() { }

    public override void Update()
    {
        Vector2 direction = (enemy.player.position - enemy.transform.position).normalized;
        enemy.transform.position += (Vector3)direction * enemy.chaseSpeed * Time.deltaTime;

        float distance = Vector2.Distance(enemy.transform.position, enemy.player.position);
        if (distance > enemy.chaseRadius)
        {
            enemy.ChangeState(new IdleState(enemy));
        }
    }

    public override void Exit() { }
}
