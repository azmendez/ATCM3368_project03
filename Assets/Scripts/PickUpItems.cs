using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItems : MonoBehaviour
{
    [SerializeField] Transform _objectDestination;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            PickUpItem();
        }
        else
        {
            DropItem();
        }
    }

    void PickUpItem()
    {
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<Rigidbody>().useGravity = false;
        this.transform.position = _objectDestination.position;
        this.transform.parent = GameObject.Find("ObjectDestination").transform;
    }

    void DropItem()
    {
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<BoxCollider>().enabled = true;

    }

}
