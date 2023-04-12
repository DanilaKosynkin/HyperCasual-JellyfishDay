using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    private DifficultyChanger _difficultyChanger;

    private void Start()
    {
        _difficultyChanger = DifficultyChanger.Instance;

        _difficultyChanger.OnDifficultyChanged += OnDifficultyChanged;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerData>())
        {
            other.gameObject.GetComponent<PlayerData>().EnemyDamage();
        }
    }

    protected virtual void OnDifficultyChanged(float difficulty) {}
}
