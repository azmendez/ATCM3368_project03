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

    public void ActivateDoor()
    {
        _doorAnimator.Play("laser_DoorOpen", 0, 0f);

        AudioManager.PlayClip2D(_doorOpenSFX, 1f);
        AudioManager.PlayClip2D(_buttonDownSFX, 1f);
    }

    public void DeactivateDoor()
    {
        _doorAnimator.Play("laser_DoorClose", 0, 0f);

        AudioManager.PlayClip2D(_doorCloseSFX, 1f);
        AudioManager.PlayClip2D(_buttonUpSFX, 1f);
    }
}
