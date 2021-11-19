using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTest : MonoBehaviour
{
    [SerializeField] Animator _doorAnimator;

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "CompanionCube" || other.transform.tag == "Player")
        {
            _doorAnimator.Play("DoorOpen", 0, 0f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.transform.tag == "CompanionCube" || other.transform.tag == "Player")
        {
            _doorAnimator.Play("DoorClose", 0, 0f);
        }
    }
}
