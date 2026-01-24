using UnityEngine;

public class LevelManager : MonoBehaviour
{

    [Header("Coin Puzzle")]
    [SerializeField] private int requiredCoins = 3;
    private int score = 0;
    [SerializeField] private Door coinDoor;

    [Header("Button Puzzle")]
    private bool[] buttons = new bool[3];
    [SerializeField] private Door buttonDoor;

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
            coinDoor.OpenDoor();
        }
    }

    public void ButtonPressed(int id) {
        if (id < 0 || id >= buttons.Length)
            return;

        buttons[id] = true;
        Debug.Log($"Button {id} pressed");

        if (buttons[0] && buttons[2]) {
            if (buttonDoor != null)
            {
                buttonDoor.OpenDoor();
            }
            else {
                Debug.LogError("Button Door not assigned in LevelManager");
            }
        }
    }
}
