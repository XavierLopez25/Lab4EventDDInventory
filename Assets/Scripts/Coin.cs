using UnityEngine;

public class Coin : MonoBehaviour
{
    private LevelManager levelManager;
    [SerializeField] private AudioClip collectSound;

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
            AudioSource.PlayClipAtPoint(collectSound, transform.position);
            levelManager.IncreaseScore();
            Destroy(gameObject);
        }
    }
}
