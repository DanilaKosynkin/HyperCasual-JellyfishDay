using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _pushForce = 3f;
    [SerializeField] private float _slowdown = 0.1f;
    [SerializeField] private float _timeToPush = 1;
    [SerializeField] private GameObject _ink;

    private float _currentTime;
    private Vector3 _currentVector;
    private float _currentSpeed;
    private bool _isReadyPush = true;
    private bool _isPressedPushButton;
    private Animator _playerAnimator;
    

    private void Start()
    {
        _playerAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        PlayerSlowdown();

        if (!_isReadyPush)
        {
            TimerPus();
            return;
        }

        if(_isPressedPushButton || Input.GetKey(KeyCode.Space))
            PushPlayer();
    }

    private void PlayerSlowdown()
    {
        transform.Translate(_currentVector * _currentSpeed * Time.deltaTime, Space.World);
        _currentSpeed -= _slowdown;
        if (_currentSpeed <= 0)
            _currentSpeed = 0;
    }

    private void PushPlayer()
    {
        _currentVector = transform.up;
        _currentSpeed = _pushForce;

        Instantiate(_ink, transform.position, transform.localRotation);

        _playerAnimator.SetTrigger("Forse");
        _isReadyPush = false;
    }

    private void TimerPus()
    {
        _currentTime += Time.deltaTime;

        if (_currentTime >= _timeToPush)
        {
            _isReadyPush = true;
            _currentTime = 0;
        }  
    }

    public void DownPushButton()
    {
        _isPressedPushButton = true;
    }

    public void UpPushButton()
    {
        _isPressedPushButton = false;
    }
}
