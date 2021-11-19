using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoorTest : MonoBehaviour
{
    [SerializeField] Animator _doorAnimator = null;
    // [SerializeField] bool openTrigger = false;
    // [SerializeField] bool closeTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Player has entered");
            _doorAnimator.Play("DoorOpen", 0, 0f);
        }

        if (other.tag == "CompanionCube")
        {
            Debug.Log("Cube has entered");
            _doorAnimator.Play("DoorOpen", 0, 0f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player has exited");
            _doorAnimator.Play("DoorClose", 0, 0f);
        }

        if(other.tag == "CompanionCube")
        {
            Debug.Log("Cube has exited");
            _doorAnimator.Play("DoorClose", 0, 0f);
        }
    }



    /*
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            if (openTrigger)
            {
                _doorAnimator.Play("DoorOpen", 0, 0f);
            }
            else if (closeTrigger)
            {
                _doorAnimator.Play("DoorClose", 0, 0f);
            }
        }
    }
    */
}
