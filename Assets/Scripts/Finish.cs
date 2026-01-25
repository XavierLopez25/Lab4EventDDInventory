using UnityEngine;

public class Finish : MonoBehaviour
{

    [SerializeField] private GameObject finishText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            finishText.SetActive(true);
            Time.timeScale = 0f;
            Debug.Log("Level Completed!");
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
