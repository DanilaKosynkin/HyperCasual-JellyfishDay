using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMover : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;

    private Vector3 _vectorDirection;

    private void Start()
    {
        _vectorDirection = new Vector3(0, -1, 0);
    }

    private void Update()
    {
        transform.Translate(_speed * Time.deltaTime * _vectorDirection);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerData>())
        {
            other.GetComponent<PlayerData>().PickCoin();
            this.gameObject.SetActive(false);
        }
    }

}
