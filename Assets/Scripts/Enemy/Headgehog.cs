using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Headgehog : Enemy
{
    [SerializeField] private float _rotationSpeed = 5;
    [SerializeField] private float _startSpeed = 2;

    private float _speed = 2;
    private GameObject _target;

    private void Start()
    {
        _target = PlayerData.Instance.gameObject;
    }

    private void Update()
    {
        MoveToTarget();
        RotateToTarget();
    }

    private void MoveToTarget()
    {
        transform.position = Vector2.MoveTowards(transform.position, _target.transform.position, _speed * Time.deltaTime);
    }

    private void RotateToTarget()
    {
        Vector3 vectorToTarget = _target.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * _rotationSpeed);
    }

    protected override void OnDifficultyChanged(float difficulty)
    {
        base.OnDifficultyChanged(difficulty);
        _speed = _startSpeed + difficulty * 0.03f;
    }
}
