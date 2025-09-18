using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public float chaseRadius = 1f;
    public float chaseSpeed = 1.5f;
     [SerializeField] private TextMeshProUGUI youLoseText;

    [SerializeField] private float attackRadius = 1f;
    
    [SerializeField] private int damageAmount = 1;
    public Score scoreManager;

    private EnemyState currentState;
    public Button myButton;
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
        if (distance < attackRadius )
        {
            DoDamageToPlayer();
            
        }
    }

    private void DoDamageToPlayer()
    {
        youLoseText.text = "You Lose! Try Again!";
        
        youLoseText.gameObject.SetActive(true);
        myButton.gameObject.SetActive(true);
        Time.timeScale = 0f;
        
        
        
        // UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
