using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] Transform _button;
    [SerializeField] Transform _startPosition;
    [SerializeField] Transform _endPosition;

    Vector3 _newPosition;

    [SerializeField] float _desiredDuration = 200;
    float _elapsedTime;

    bool _buttonIsDown;
    int _numOfActivations;

    private void Awake()
    {
        _newPosition = _button.position;

        _buttonIsDown = false;

        _numOfActivations = 0;
    }

    private void Update()
    {
        MoveButton();
        _elapsedTime += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_buttonIsDown == false)
        {
            if(other.transform.tag == "CompanionCube")
            {
                Debug.Log("Cube has entered");

                _buttonIsDown = true;
                _numOfActivations += 1;
            }

            if (other.transform.tag == "Player")
            {
                Debug.Log("Player has entered");

                _numOfActivations += 1;
                _buttonIsDown = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Check #1 " + _numOfActivations);

        if (other.transform.tag == "CompanionCube")
        {
            Debug.Log("Cube has exited");
            _numOfActivations -= 1;

            if (_numOfActivations == 0 && _buttonIsDown == true)
            {
                _buttonIsDown = false;
            }
        }

        if(other.transform.tag == "Player")
        {
            Debug.Log("Player has exited");

            _numOfActivations -= 1;

            if (_numOfActivations == 0 && _buttonIsDown == true)
            {
                _buttonIsDown = false;
            }
        }
    }

    void MoveButton()
    {
        Vector3 startPosition = _startPosition.position;
        Vector3 endPosition = _endPosition.position;

        if(_buttonIsDown)
        {
            _newPosition = endPosition;
        }

        if(!_buttonIsDown)
        {
            _newPosition = startPosition;
        }

        float percentageComplete = _elapsedTime / _desiredDuration;

        _button.position = Vector3.Lerp(_button.position, _newPosition, percentageComplete);
    }
    
    /*
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "CompanionCube" || collision.transform.tag == "Player")
        {
            Debug.Log("Collision detected");
            _buttonIsActivated = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "CompanionCube" || collision.transform.tag == "Player")
        {
            Debug.Log("Collision ended");
            _buttonIsActivated = false;
        }
    }
    */
}
