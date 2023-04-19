using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private bool _is1HP;

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
            if(_is1HP)
                gameObject.SetActive(false);
        }
    }

    protected virtual void OnDifficultyChanged(float difficulty) {}
}
