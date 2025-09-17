using UnityEngine;

public class Traps : MonoBehaviour

{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private int playerHP = 5;
    [SerializeField] private int amount = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Trap"))
        {
            rb.AddForceY(10, ForceMode2D.Impulse);
    
            playerHP -= amount;
            playerHP = Mathf.Max(playerHP, 0);
            Debug.Log("Player HP: " + playerHP);
            
        

            if (playerHP == 0)
            {
                Debug.Log("Player is dead!");
                // Add death or UI update logic here if needed
                // Restart the game
                UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
            }
        }
    }
     public void TakeDamage(int amount)
        {
            playerHP -= amount;
            playerHP = Mathf.Max(playerHP, 0);
            Debug.Log("Player HP: " + playerHP);
            // Add death or UI update logic here if needed
        }
}
