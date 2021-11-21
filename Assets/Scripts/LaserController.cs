using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    [SerializeField] LineRenderer _laserLine;
    [SerializeField] Transform _startPosition;
    [SerializeField] CubeLaser _laserCube;

    float _shootingDistance = 100;
    RaycastHit _objectHit;

    private void Update()
    {
        Debug.DrawRay(_startPosition.position, _startPosition.forward * _shootingDistance, Color.blue);

        if(Physics.Raycast(_startPosition.position, _startPosition.forward, out _objectHit, _shootingDistance))
        {
            _laserLine.SetPosition(0, _startPosition.position);
            _laserLine.SetPosition(1, _objectHit.point);

            if(_objectHit.transform.tag == "LaserCube")
            {
                // TODO add what happens when laser hits cube
                Debug.Log("Activate laser cube");
                _laserCube.ShootCubeLaser();
            }
        }
    }
}
