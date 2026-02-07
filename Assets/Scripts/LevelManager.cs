using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{

    [Header("Coin Puzzle")]
    [SerializeField] private int requiredCoins = 3;
    private int score = 0;
    [SerializeField] private Door coinDoor;

    [Header("Button Puzzle")]
    private bool[] buttons = new bool[3];
    [SerializeField] private Door buttonDoor;

    [Header("Skull Puzzle")]
    [SerializeField] private Door skullDoor;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI coinText;

    private bool[] skullStates = new bool[5];
    private bool[] correctCombination = new bool[5] { true, true, true, true, true };

    private void UpdateCoinUI() 
    {
        if (coinText != null)
        {
            coinText.text = $"Coins: {score} / {requiredCoins}";
        }
    }

    void Start() 
    {
        UpdateCoinUI();
    }
    
    void Update()
    {
        // Solo para debug
        Debug.Log("Coins: " + score);
    }

    public void IncreaseScore()
    {
        score++;

        UpdateCoinUI();

        if (score >= requiredCoins)
        {
            Debug.Log("Obtained all keys");
            coinDoor.OpenDoor();
        }
    }


    public void CheckSkullCombination() {
        for (int i = 0; i < correctCombination.Length; i++) {
            if (skullStates[i] != correctCombination[i])
                return;

            Debug.Log(
                $"Skulls: {skullStates[0]}, {skullStates[1]}, {skullStates[2]}, {skullStates[3]}, {skullStates[4]}"
            );
        }

        


        Debug.Log("Correct skull combination");
        skullDoor.OpenDoor();
    }

    public void SkullToggled(int index, bool isOpen) { 
        skullStates[index] = isOpen;
        CheckSkullCombination();
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
