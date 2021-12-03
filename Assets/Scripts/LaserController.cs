using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    [SerializeField] LineRenderer _laserLine;
    [SerializeField] Transform _startPosition;
    [SerializeField] CubeLaser _cubeLaser;
    [SerializeField] GameObject _laserVisual;
    [SerializeField] ParticleSystem _sparksPS;

    float _shootingDistance = 100;
    RaycastHit _objectHit;

    private void Awake()
    {
        _laserVisual.SetActive(false);
    }

    private void Update()
    {
        Debug.DrawRay(_startPosition.position, _startPosition.forward * _shootingDistance, Color.blue);

        if(Physics.Raycast(_startPosition.position, _startPosition.forward, out _objectHit, _shootingDistance))
        {
            _laserLine.SetPosition(0, _startPosition.position);
            _laserLine.SetPosition(1, _objectHit.point);

            if(_objectHit.transform.tag == "LaserCube")
            {
                Debug.Log("Laser hit cube");
                _laserVisual.SetActive(true);
                _cubeLaser.CheckForLaser();
            }
            else
            {
                _laserVisual.SetActive(false);
                
                if(CubeLaser._triggerIsActivated == true)
                {
                    _cubeLaser.DeactivateDoor();
                }

                CubeLaser._triggerIsActivated = false;

            }
        }
    }
}
