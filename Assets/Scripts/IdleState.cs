using UnityEngine;

public class IdleState : EnemyState
{
    public IdleState(Enemy enemy) : base(enemy) { }

    public override void Enter() { }

    public override void Update()
    {
        float distance = Vector2.Distance(enemy.transform.position, enemy.player.position);
        if (distance < enemy.chaseRadius)
        {
            enemy.ChangeState(new ChaseState(enemy));
        }
    }

    public override void Exit() { }
}
