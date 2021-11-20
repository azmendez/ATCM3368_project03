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

    bool _buttonIsActivated;

    private void Awake()
    {
        _newPosition = _button.position;

        _buttonIsActivated = false;
    }

    private void Update()
    {
        MoveButton();

        _elapsedTime += Time.deltaTime;
    }

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

    void MoveButton()
    {
        Vector3 startPosition = _startPosition.position;
        Vector3 endPosition = _endPosition.position;

        if(_buttonIsActivated)
        {
            _newPosition = endPosition;
        }

        if(!_buttonIsActivated)
        {
            _newPosition = startPosition;
        }

        float percentageComplete = _elapsedTime / _desiredDuration;

        _button.position = Vector3.Lerp(_button.position, _newPosition, percentageComplete);
    }
}
