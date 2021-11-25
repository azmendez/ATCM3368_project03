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

    private void Awake()
    {
        _newPosition = _button.position;
        _buttonIsDown = false;
    }

    private void Update()
    {
        MoveButton();
        _elapsedTime += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "CompanionCube" || other.transform.tag == "Player")
        {
            Debug.Log("Button animation trigger entered");
            Debug.Log("Enter: " + other.transform.name);
            _buttonIsDown = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "CompanionCube" || other.transform.tag == "Player")
        {
            Debug.Log("Button animation trigger exited");
            _buttonIsDown = false;
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
}
