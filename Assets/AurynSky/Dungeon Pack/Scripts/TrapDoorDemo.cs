using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDoorDemo : MonoBehaviour {

    //This script goes on the TrapDoor prefab;

    public Animator TrapDoorAnim; //Animator for the trap door;

    // Use this for initialization

    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip openSound;


    void Awake()
    {
        //get the Animator component from the trap;
        TrapDoorAnim = GetComponent<Animator>();

        //if (audioSource == null)
        //    audioSource = GetComponent<AudioSource>();

        //start opening and closing the trap for demo purposes;
        StartCoroutine(OpenCloseTrap());
    }


    IEnumerator OpenCloseTrap()
    {
        //play sound
        audioSource.PlayOneShot(openSound);

        //play open animation;
        TrapDoorAnim.SetTrigger("open");
        //wait 2 seconds;
        yield return new WaitForSeconds(2);
        //play close animation;
        TrapDoorAnim.SetTrigger("close");
        //wait 2 seconds;
        yield return new WaitForSeconds(2);
        //Do it again;
        StartCoroutine(OpenCloseTrap());

    }
}