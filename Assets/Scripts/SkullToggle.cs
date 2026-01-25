using UnityEngine;

public class SkullToggle : MonoBehaviour
{

    [SerializeField] private int skullIndex;
    [SerializeField] private GameObject openMouthModel;
    [SerializeField] private GameObject closedMouthModel;

    private bool isOpen = false;
    private LevelManager levelManager;

    private Renderer rend;
    private Color originalColor;

    private void Awake()
    {
        rend = GetComponentInChildren<Renderer>();
        originalColor = rend.material.color;
    }

    public void Highlight(bool active) { 
        rend.material.color = active ? Color.yellow : originalColor;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        levelManager = FindFirstObjectByType<LevelManager>();
        UpdateVisual();
    }

    public void Toggle() {
        isOpen = !isOpen;
        UpdateVisual();

        levelManager.SkullToggled(skullIndex, isOpen);
    }

    private void UpdateVisual() { 
        openMouthModel.SetActive(isOpen);
        closedMouthModel.SetActive(!isOpen);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
