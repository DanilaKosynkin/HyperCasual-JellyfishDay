using UnityEngine;

public class Bleackhead : Enemy
{
    [SerializeField] private float _startSpeed = 2;

    private Vector3 _currentVector;
    private float _speed;

    private void OnEnable()
    {
        _currentVector = new Vector3(-1, 0, 0);
    }

    private void Update()
    {
        EnemyMove();
    }

    private void EnemyMove()
    {
        transform.Translate(_currentVector * _speed * Time.deltaTime);
    }

    protected override void OnDifficultyChanged(float difficulty)
    {
        base.OnDifficultyChanged(difficulty);
        _speed = _startSpeed + difficulty * 0.03f;
    }
}
