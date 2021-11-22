using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserActivate : MonoBehaviour
{
    [SerializeField] Animator _doorAnimator;

    [Header("Player Feedback")]
    [SerializeField] AudioClip _buttonDownSFX;
    [SerializeField] AudioClip _buttonUpSFX;
    [SerializeField] AudioClip _doorCloseSFX;
    [SerializeField] AudioClip _doorOpenSFX;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Laser door trigger entered");

        if (other.transform.tag == "Laser")
        {
            ActivateDoor();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Laser door trigger exited");

        if (other.transform.tag == "Laser")
        {
            DeactivateDoor();
        }
    }

    /*
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Laser collision detected");

        if (collision.transform.tag == "Laser")
        {
            // Debug.Log("Laser collision detected");
            ActivateDoor();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("Laser collision ended");

        if (collision.transform.tag == "Laser")
        {
            // Debug.Log("Laser collision ended");
            DeactivateDoor();
        }
    }
    */

    void ActivateDoor()
    {
        _doorAnimator.Play("DoorOpen", 0, 0f);

        AudioManager.PlayClip2D(_doorOpenSFX, 1f);
        AudioManager.PlayClip2D(_buttonDownSFX, 1f);
    }

    void DeactivateDoor()
    {
        _doorAnimator.Play("DoorClose", 0, 0f);

        AudioManager.PlayClip2D(_doorCloseSFX, 1f);
        AudioManager.PlayClip2D(_buttonUpSFX, 1f);
    }
}
