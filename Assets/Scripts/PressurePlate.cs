using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] GameObject _button;
    [SerializeField] Animator _doorAnimator;

    [SerializeField] Transform _startPosition;
    [SerializeField] Transform _endPosition;
    float _desiredDuration = 50;
    float _elapsedTime;


    private void Awake()
    {
        _button.transform.position = _startPosition.position;
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "CompanionCube" || collision.transform.tag == "Player")
        {
            Debug.Log("Collision detected");
            _doorAnimator.Play("DoorOpen", 0, 0f);

            // PlateEffects();
        }

        /*
        if (collision.transform.tag == "Player")
        {
            Debug.Log("Player collision detected");
            _doorAnimator.Play("DoorOpen", 0, 0f);
        }
        */
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "CompanionCube" || collision.transform.tag == "Player")
        {
            Debug.Log("Collision ended");
            _doorAnimator.Play("DoorClose", 0, 0f);
        }

        /*
        if (collision.transform.tag == "Player")
        {
            Debug.Log("Player collision ended");
            _doorAnimator.Play("DoorClose", 0, 0f);
        }
        */
    }

    void PlateEffects()
    {
        // _button.transform.position = _endPosition.position;

        float percentageComplete = _elapsedTime / _desiredDuration;

        _button.transform.position = Vector3.Lerp(_startPosition.position, _endPosition.position, percentageComplete);
    }

    void ResetPlate()
    {
        
    }
}
