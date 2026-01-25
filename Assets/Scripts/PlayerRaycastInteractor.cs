using UnityEngine;

public class PlayerRaycastInteractor : MonoBehaviour
{
    [SerializeField] private float interactionDistance = 3f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            Debug.DrawRay(transform.position, transform.forward * interactionDistance, Color.red, 1f);

            if (Physics.Raycast(ray, out hit, interactionDistance))
            {
                Debug.Log("Hit: " + hit.collider.name);

                if (hit.collider.CompareTag("Button"))
                {
                    hit.collider
                        .GetComponent<ButtonInteractable>()
                        ?.PressButton();
                }

                if (hit.collider.CompareTag("Skull"))
                {
                    SkullToggle skull = hit.collider.GetComponentInParent<SkullToggle>();

                    if (skull != null)
                    {
                        skull.Toggle();
                        skull.Highlight(true);
                    }
                }


            }
        }
    }
}
