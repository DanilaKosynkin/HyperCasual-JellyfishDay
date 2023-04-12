using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    [SerializeField] private float _speedToRotate = 20;

    private float _rotateZ;

    private void Update()
    {
        float pcInput = Input.GetAxis("Horizontal");
        if(pcInput != 0)
        {
            Rotate(pcInput);
            return;
        }
            

        if (_rotateZ != 0)
            Rotate(_rotateZ);
    }

    private void Rotate(float direction)
    {
        transform.Rotate(0, 0, -(direction * _speedToRotate * Time.deltaTime));
    }

    public void OnClickArrowButton(float direction)
    {
        _rotateZ = direction;
    }

    public void Reset()
    {
        _rotateZ = 0;
    }

}
