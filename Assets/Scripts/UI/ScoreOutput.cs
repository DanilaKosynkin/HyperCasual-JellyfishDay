using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreOutput : MonoBehaviour
{
    [SerializeField] private TMP_Text[] _coinsScoreText;
    [SerializeField] private TMP_Text[] _lifeTimeScoreText;

    private PlayerData _playerData;

    private void Start()
    {
        _playerData = PlayerData.Instance;
        _playerData.OnPlayerCountCoins += UpdateCoins;
        _playerData.OnPlayerLifeTimeScore += UpdateLifeTime;
    }

    private void OnDestroy()
    {
        _playerData.OnPlayerCountCoins += UpdateCoins;
        _playerData.OnPlayerLifeTimeScore += UpdateLifeTime;
    }

    private void UpdateCoins(int currentCoins)
    {
        foreach (var textCoins in _coinsScoreText) 
        {
            textCoins.text = currentCoins.ToString();
        }
    }

    private void UpdateLifeTime(int currentLifeTime)
    {
        foreach(var textLifeTime in _lifeTimeScoreText)
        {
            textLifeTime.text = currentLifeTime.ToString(); 
        }
    }
}
