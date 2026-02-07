using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private VictoryManager victoryManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            victoryManager.Win();
        }
    }
}
