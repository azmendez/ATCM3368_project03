using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItems : MonoBehaviour
{
    [SerializeField] Transform _objectDestination;
    [SerializeField] Camera _playerCamera;
    float _shootDistance = 5f;
    bool _isPickedUp;

    RaycastHit _objectHit;

    private void Awake()
    {
        _isPickedUp = false;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(_isPickedUp == false)
            {
                ShootRaycast();
            }
            else
            {
                DropItem();
            }
        }
    }

    void ShootRaycast()
    {
        Vector3 rayDirection = _playerCamera.transform.forward;
        Debug.DrawRay(_playerCamera.transform.position, rayDirection * _shootDistance, Color.magenta, 1f);

        if(Physics.Raycast(_playerCamera.transform.position, rayDirection, out _objectHit, _shootDistance))
        {
            if(_objectHit.transform.tag == "CompanionCube" || _objectHit.transform.tag == "LaserCube")
            {
                PickUpItem();
            }
        }
    }

    void PickUpItem()
    {
        _isPickedUp = true;

        GetComponent<BoxCollider>().enabled = false;
        GetComponent<Rigidbody>().useGravity = false;
        _objectHit.transform.position = _objectDestination.position;
        _objectHit.transform.parent = GameObject.Find("ObjectDestination").transform;
    }

    void DropItem()
    {
        _isPickedUp = false;

        _objectHit.transform.parent = null;
        GetComponent<BoxCollider>().enabled = true;
        GetComponent<Rigidbody>().useGravity = true;
    }
}
