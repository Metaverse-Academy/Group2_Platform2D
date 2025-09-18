using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private int score = 0;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip collectableSound;   
   [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI youWinText;
    public Button myButton;
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
        if (other.gameObject.CompareTag("Collectible"))
        {
            score++;
            audioSource.PlayOneShot(collectableSound);
            scoreText.text = score.ToString();
            Debug.Log("Score: " + score);
            Destroy(other.gameObject);
        }
        
        if (other.gameObject.CompareTag("Cat"))
        {
            Debug.Log("Player Has Won!");
            youWinText.text = "You Win! Congratulations! Score: " + score;
            youWinText.gameObject.SetActive(true);
            myButton.gameObject.SetActive(true);
            // Add death or UI update logic here if needed
            // Restart the game
            Time.timeScale = 0f;
           // UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }
    }
    public void Rematch()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
