using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeLaser : MonoBehaviour
{
    [Header("Laser Settings")]
    [SerializeField] LineRenderer _laserLine;
    [SerializeField] Transform _shootPosition;
    [SerializeField] GameObject _sphereVisual;
    [SerializeField] GameObject _sparks;

    [Header("Door FX")]
    [SerializeField] Animator _doorAnimator;
    [SerializeField] AudioClip _doorCloseSFX;
    [SerializeField] AudioClip _doorOpenSFX;

    [Header("Door Lights")]
    [SerializeField] GameObject _blueStrip;
    [SerializeField] GameObject _orangeStrip;

    float _shootingDistance = 100;
    RaycastHit _objectHit;
    public static bool _triggerIsActivated;

    private void Awake()
    {
        _sphereVisual.SetActive(false);
        _sparks.SetActive(false);

        _orangeStrip.SetActive(false);
    }

    private void Update()
    {
        Debug.DrawRay(_shootPosition.position, _shootPosition.forward * _shootingDistance, Color.blue);
    }

    public void CheckForLaser()
    {
        if (_triggerIsActivated == false)
        {
            DeactivatedReceiver();
            // Debug.Log("'Deactivate' laser started");
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
            Debug.Log("Cube laser is shooting");

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
        _sphereVisual.SetActive(true);
        _sparks.SetActive(true);

        _blueStrip.SetActive(false);
        _orangeStrip.SetActive(true);
    }

    public void DeactivateDoor()
    {
        _doorAnimator.Play("laser_DoorClose", 0, 0f);

        AudioManager.PlayClip2D(_doorCloseSFX, 1f);
        _sphereVisual.SetActive(false);
        _sparks.SetActive(false);

        _orangeStrip.SetActive(false);
        _blueStrip.SetActive(true);
    }
}
