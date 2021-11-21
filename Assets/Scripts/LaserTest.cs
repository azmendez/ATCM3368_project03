using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTest : MonoBehaviour
{
    [SerializeField] LineRenderer _laserLine;

    [SerializeField] Transform _startPosition;

    float _shootingDistance = 100;

    RaycastHit _objectHit;

    private void Awake()
    {
        _laserLine.positionCount = 2;
    }
    private void Update()
    {
        Debug.DrawRay(_startPosition.position, _startPosition.forward * _shootingDistance, Color.red);

        _laserLine.SetPosition(0, _startPosition.position);
        _laserLine.SetPosition(1, _objectHit.point);

        if (Physics.Raycast(_startPosition.position, _startPosition.forward, out _objectHit, _shootingDistance))
        {
            // Debug.Log(_objectHit.transform.name);

            // _laserLine.SetPosition(0, _startPosition.position);
            // _laserLine.SetPosition(1, _objectHit.point);
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
