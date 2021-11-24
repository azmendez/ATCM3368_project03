using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeLaser : MonoBehaviour
{
    [Header("Laser Settings")]
    [SerializeField] LineRenderer _laserLine;
    [SerializeField] Transform _shootPosition;

    [Header("Door FX")]
    [SerializeField] Animator _doorAnimator;
    [SerializeField] AudioClip _buttonDownSFX;
    [SerializeField] AudioClip _buttonUpSFX;
    [SerializeField] AudioClip _doorCloseSFX;
    [SerializeField] AudioClip _doorOpenSFX;

    float _shootingDistance = 100;
    RaycastHit _objectHit;
    public static bool _triggerIsActivated;

    private void Update()
    {
        Debug.DrawRay(_shootPosition.position, _shootPosition.forward * _shootingDistance, Color.blue);
    }

    public void CheckForLaser()
    {
        if (_triggerIsActivated == false)
        {
            DeactivatedReceiver();
        }
        else
        {
            ActivatedReceiver();
        }
    }

    void DeactivatedReceiver()
    {
        if (Physics.Raycast(_shootPosition.position, _shootPosition.forward, out _objectHit, _shootingDistance))
        {
            _laserLine.SetPosition(0, _shootPosition.position);
            _laserLine.SetPosition(1, _objectHit.point);
            
            if(_objectHit.transform.tag == "Laser")
            {
                Debug.Log("Laser hit receiver");
                _triggerIsActivated = true;
                ActivateDoor();
                Debug.Log("Trigger activated: " + _triggerIsActivated);
            }
        }
    }

    void ActivatedReceiver()
    {
        if (Physics.Raycast(_shootPosition.position, _shootPosition.forward, out _objectHit, _shootingDistance))
        {
            _laserLine.SetPosition(0, _shootPosition.position);
            _laserLine.SetPosition(1, _objectHit.point);

            if (_objectHit.transform.tag != "Laser")
            {
                Debug.Log("Laser left receiver");
                _triggerIsActivated = false;
                DeactivateDoor();
                Debug.Log("Trigger activated: " + _triggerIsActivated);
            }
        }
    }

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
