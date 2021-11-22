using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeLaser : MonoBehaviour
{
    [SerializeField] LineRenderer _laserLine;
    [SerializeField] Transform _shootPosition;

    float _shootingDistance = 100;
    RaycastHit _objectHit;
    // LayerMask _laserMask;

    private void Update()
    {
        Debug.DrawRay(_shootPosition.position, _shootPosition.forward * _shootingDistance, Color.blue);
        ShootCubeLaser();
    }

    public void ShootCubeLaser()
    {
        if (Physics.Raycast(_shootPosition.position, _shootPosition.forward, out _objectHit, _shootingDistance))
        {
            _laserLine.SetPosition(0, _shootPosition.position);
            _laserLine.SetPosition(1, _objectHit.point);
        }
    }

    /*

    LASER CUBE IDEA

    Physics.Raycast(locationOfWhereFirstRayHitTheCube, objectHit.normal, out _secondObjectHitFromCubeReflectionRay, distanceYouWantRayToShoot)

    Physics.Raycast(_objectHit.transform, _objectHit.normal, out _newLaserHit, _distance)
        // first line start location = where ray shoots out
        // first line end location = _objectHit.point
        // second line start location = _objectHit.point
    */

}
