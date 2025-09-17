using UnityEngine;

public class Score : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private int score = 0;
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
            Debug.Log("Score: " + score);
            Destroy(other.gameObject);
        }
    }
}
