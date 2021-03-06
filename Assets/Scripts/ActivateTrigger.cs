using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTrigger : MonoBehaviour
{
    [SerializeField] Animator _doorAnimator;

    [Header("Sound Effects")]
    [SerializeField] AudioClip _buttonDownSFX;
    [SerializeField] AudioClip _buttonUpSFX;
    [SerializeField] AudioClip _doorCloseSFX;
    [SerializeField] AudioClip _doorOpenSFX;

    [Header("Door Lights")]
    [SerializeField] GameObject _blueStrip;
    [SerializeField] GameObject _orangeStrip;

    private void Awake()
    {
        _orangeStrip.SetActive(false);
    }

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

        _blueStrip.SetActive(false);
        _orangeStrip.SetActive(true);
    }

    public void DeactivateDoor()
    {
        _doorAnimator.Play("DoorClose", 0, 0f);

        AudioManager.PlayClip2D(_doorCloseSFX, 1f);
        AudioManager.PlayClip2D(_buttonUpSFX, 1f);

        _orangeStrip.SetActive(false);
        _blueStrip.SetActive(true);
    }
}
