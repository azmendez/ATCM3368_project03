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
        if (other.transform.tag == "CompanionCube" || other.transform.tag == "Player")
        {
            Debug.Log("Trigger entered");

            ActivateButton();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "CompanionCube" || other.transform.tag == "Player")
        {
            Debug.Log("Trigger exited");

            DeactivateButton();
        }
    }

    void ActivateButton()
    {
        _doorAnimator.Play("DoorOpen", 0, 0f);

        AudioManager.PlayClip2D(_doorOpenSFX, 1f);
        AudioManager.PlayClip2D(_buttonDownSFX, 1f);
    }

    void DeactivateButton()
    {
        _doorAnimator.Play("DoorClose", 0, 0f);

        AudioManager.PlayClip2D(_doorCloseSFX, 1f);
        AudioManager.PlayClip2D(_buttonUpSFX, 1f);
    }
}
