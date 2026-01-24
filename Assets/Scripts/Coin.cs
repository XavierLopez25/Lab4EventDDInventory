using UnityEngine;

public class Coin : MonoBehaviour
{
    private LevelManager levelManager;

    void Start()
    {
        levelManager = FindFirstObjectByType<LevelManager>();
    }

    void Update()
    {
        transform.Rotate(0, 45 * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            levelManager.IncreaseScore();
            Destroy(gameObject);
        }
    }
}
