using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    [SerializeField] Transform _player;

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(this.transform.position, transform.forward, Color.red);
        this.gameObject.transform.LookAt(_player);
    }
}
