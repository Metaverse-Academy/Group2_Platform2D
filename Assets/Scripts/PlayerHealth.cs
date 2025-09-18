using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour

{
    [SerializeField] private TextMeshProUGUI playerHPText;

    [SerializeField] private int playerHP = 3;
    private int currentHP;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHP = playerHP;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        Debug.Log("Player HP: " + currentHP);
        playerHPText.text = currentHP.ToString();
        if (currentHP <= 0)
        {
            
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }
    }
}