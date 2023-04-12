using UnityEngine;

public class Star : Enemy
{
    [SerializeField] private float _jumpHeightMax = 750;
    [SerializeField] private float _jumpHeightMin = 500;

    private Rigidbody2D _rigidbody2D;

    private void OnEnable()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        Jump();
    }

    private void Jump()
    {
        _rigidbody2D.AddForce(transform.up * Random.Range(_jumpHeightMin, _jumpHeightMax)); 
    }

}
