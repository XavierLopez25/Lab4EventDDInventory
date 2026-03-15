using UnityEngine;
using StarterAssets;
using System.Collections;

public class PlayerStats : MonoBehaviour
{
    private ThirdPersonController controller;
    private float baseSpeed;

    void Start()
    {
        controller = GetComponentInChildren<ThirdPersonController>();
        baseSpeed = controller.MoveSpeed;
    }

    public void ModifySpeed(float multiplier, float duration)
    {
        StopAllCoroutines();
        StartCoroutine(SpeedRoutine(multiplier, duration));
    }

    IEnumerator SpeedRoutine(float multiplier, float duration)
    {
        controller.MoveSpeed = baseSpeed * multiplier;

        yield return new WaitForSeconds(duration);

        controller.MoveSpeed = baseSpeed;
    }

    public void UnlockDoubleJump()
    {
        var controller = GetComponentInChildren<ThirdPersonController>();
        controller.maxJumps = 2;
        Debug.Log("Double jump unlocked!");
    }
}