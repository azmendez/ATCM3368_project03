using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour
{
    [SerializeField] Animator _doorAnimator;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "CompanionCube")
        {
            Debug.Log("Cube collision detected");
            _doorAnimator.Play("DoorOpen", 0, 0f);
        }

        if(collision.transform.tag == "Player")
        {
            Debug.Log("Player collision detected");
            // _doorAnimator.Play("DoorOpen", 0, 0f);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "CompanionCube")
        {
            Debug.Log("Collision detected");
            _doorAnimator.Play("DoorOpen", 0, 0f);
        }
    }
}
