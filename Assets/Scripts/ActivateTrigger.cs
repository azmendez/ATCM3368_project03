using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTrigger : MonoBehaviour
{
    [SerializeField] Animator _doorAnimator;

    [Header("Player Feedback")]
    [SerializeField] AudioClip _buttonDownSFX;
    [SerializeField] AudioClip _buttonUpSFX;
    [SerializeField] AudioClip _doorCloseSFX;
    [SerializeField] AudioClip _doorOpenSFX;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "PressurePlate")
        {
            Debug.Log("Button door trigger entered");

            ActivateDoor();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "PressurePlate")
        {
            Debug.Log("Button door trigger exited");

            DeactivateDoor();
        }
    }

    public void ActivateDoor()
    {
        _doorAnimator.Play("DoorOpen", 0, 0f);

        AudioManager.PlayClip2D(_doorOpenSFX, 1f);
        AudioManager.PlayClip2D(_buttonDownSFX, 1f);
    }

    public void DeactivateDoor()
    {
        _doorAnimator.Play("DoorClose", 0, 0f);

        AudioManager.PlayClip2D(_doorCloseSFX, 1f);
        AudioManager.PlayClip2D(_buttonUpSFX, 1f);
    }
}
