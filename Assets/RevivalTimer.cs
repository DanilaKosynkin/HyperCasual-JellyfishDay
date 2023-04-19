using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RevivalTimer : MonoBehaviour
{
    [SerializeField] private Image _rerivalTimer;
    [SerializeField] private GameUI _gameUI;

    private float _timeToRevival = 1f;
    private bool _isRevival;

    private void OnEnable()
    {
        _isRevival = true;
        _timeToRevival = 1f;
    }

    private void Update()
    {
        if (_isRevival)
        {
            _timeToRevival -= Time.deltaTime * 0.2f;
            _rerivalTimer.fillAmount = _timeToRevival;
            if (_timeToRevival <= 0)
            {
                _isRevival = false;
                _gameUI.ActivateDeadCanvas();
            }
        }
    }
}
