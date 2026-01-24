using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private int requiredCoins = 3;
    private int score = 0;

    [SerializeField] private Door door;

    void Update()
    {
        // Solo para debug
        Debug.Log("Coins: " + score);
    }

    public void IncreaseScore()
    {
        score++;

        if (score >= requiredCoins)
        {
            Debug.Log("Obtained all keys");
            door.OpenDoor();
        }
    }
}
