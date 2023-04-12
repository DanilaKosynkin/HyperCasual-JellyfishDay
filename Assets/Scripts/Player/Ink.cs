using UnityEngine;

public class Ink : MonoBehaviour
{
    [SerializeField] private float _inkSpeed = 2;
    [SerializeField] private float _lifeTime = 1;

    private float _currentTime;

    private void Update()
    {
        InkMover();
        TimerDestroyInk();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Headgehog>())
        {
            collision.gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

    private void InkMover()
    {
        transform.Translate(-transform.up * _inkSpeed * Time.deltaTime, Space.World);
    }

    private void TimerDestroyInk()
    {
        _currentTime += Time.deltaTime;

        if (_currentTime >= _lifeTime)
            Destroy(this.gameObject);
    }
}
