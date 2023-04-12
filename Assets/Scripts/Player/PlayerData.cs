using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using System.Threading.Tasks;

public class PlayerData : MonoBehaviour
{
    [SerializeField] private int _health = 3;
    [SerializeField] private float _immortality = 1f;
    [SerializeField] private Restart _restart;

    private SpriteRenderer _spriteRenderer;
    private int _currentLifeTimeScore;
    private int _currentCoins;
    private bool _isImmortality = false;

    public static PlayerData Instance;

    public Action OnPlayerDead;
    public Action<int> OnPlayerHealth;
    public Action<int> OnPlayerLifeTimeScore;
    public Action<int> OnPlayerCountCoins;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this.gameObject);
        else
            Instance = this;
    }

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _restart = _restart.GetComponent<Restart>();
        RestartPlayerData();
        _restart.OnRestart += RestartPlayerData;
        _restart.OnRevival += RevivalPlayerData;
    }

    private void OnDestroy()
    {
        _restart.OnRestart -= RestartPlayerData;
        _restart.OnRevival -= RevivalPlayerData;
    }

    private void RevivalPlayerData()
    {
        gameObject.SetActive(true);
        _health = 3;
        ImmortalityTimer(4f);
        _currentLifeTimeScore = 0;
        _currentCoins = 0;

        OnPlayerHealth?.Invoke(_health);
    }

    private void RestartPlayerData()
    {
        gameObject.SetActive(true);
        transform.position = -Vector3.forward;
        _health = 3;
        StopAllCoroutines();
        StartCoroutine(LifeTimerScore());
        _isImmortality = false;
        _currentLifeTimeScore = 0;
        _currentCoins = 0;

        OnPlayerLifeTimeScore?.Invoke(_currentLifeTimeScore);
        OnPlayerCountCoins?.Invoke(_currentCoins);
        OnPlayerHealth?.Invoke(_health);
    }

    private IEnumerator ImmortalityTimer(float immortality)
    {
        _isImmortality = true;
        yield return new WaitForSeconds(immortality);
        _isImmortality = false;
    }

    private IEnumerator LifeTimerScore()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            _currentLifeTimeScore++;
            OnPlayerLifeTimeScore?.Invoke(_currentLifeTimeScore);
        }
    }

    public void SaveData(TMP_Text recordText)
    {
        if (PlayerPrefs.GetInt("CurrentLifeTimeScore") < _currentLifeTimeScore)
        {
            recordText.text = "New Record:" + _currentLifeTimeScore;
            PlayerPrefs.SetInt("CurrentLifeTimeScore", _currentLifeTimeScore);
        }  
        else recordText.text = "Record:" + PlayerPrefs.GetInt("CurrentLifeTimeScore");

        int saveCoins = PlayerPrefs.GetInt("CurrentCoins");
        PlayerPrefs.SetInt("CurrentCoins", _currentCoins + saveCoins);
    }

    public void PickCoin()
    {
        _currentCoins += 1;
        OnPlayerCountCoins?.Invoke(_currentCoins);
    }

    public void EnemyDamage()
    {
        if (_isImmortality)
            return;

        StartCoroutine(ImmortalityTimer(_immortality));
        _health -= 1;
        OnPlayerHealth?.Invoke(_health);
        if (_health == 0)
        {
            gameObject.SetActive(false);
            OnPlayerDead?.Invoke();
        }
    }
}
