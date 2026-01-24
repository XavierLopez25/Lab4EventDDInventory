using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Vector3 openOffset = new Vector3(0, 3f, 0);
    [SerializeField] private float openSpeed = 2f;

    private Vector3 closedPosition;
    private Vector3 openPosition;
    private bool open = false;

    void Start()
    {
        closedPosition = transform.position;
        openPosition = closedPosition + openOffset;
    }

    void Update()
    {
        if (open)
        {
            transform.position = Vector3.Lerp(
                transform.position,
                openPosition,
                Time.deltaTime * openSpeed
            );
        }
    }

    public void OpenDoor()
    {
        open = true;
    }
}
