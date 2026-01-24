using UnityEngine;

public class ButtonInteractable : MonoBehaviour
{
    [SerializeField] private int buttonID;
    private bool isActive = false;

    private LevelManager levelManager;
    private Renderer rend;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        levelManager = FindFirstObjectByType<LevelManager>();
        rend = GetComponent<Renderer>();
    }

    public void PressButton() {
        if (isActive) return;

        isActive = true;
        rend.material.color = Color.green;

        levelManager.ButtonPressed(buttonID);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
