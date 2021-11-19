using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItems : MonoBehaviour
{
    [SerializeField] Transform _objectDestination;

    [SerializeField] Camera _playerCamera;
    float _shootDistance = 5f;

    RaycastHit _objectHit;

    bool _isPickedUp;

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

        if (Physics.Raycast(_playerCamera.transform.position, rayDirection, out _objectHit, _shootDistance))
        {
            Debug.Log("Something was hit");

            if(_objectHit.transform.tag == "CompanionCube")
            {
                Debug.Log("Found Cube");
                PickUpItem();
            }
        }
        else
        {
            Debug.Log("Miss");
        }
    }

    void PickUpItem()
    {
        _isPickedUp = true;

        GetComponent<BoxCollider>().enabled = false;
        GetComponent<Rigidbody>().useGravity = false;
        this.transform.position = _objectDestination.position;
        this.transform.parent = GameObject.Find("ObjectDestination").transform;
    }

    void DropItem()
    {
        _isPickedUp = false;

        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<BoxCollider>().enabled = true;
    }
}
