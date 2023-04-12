using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeath : MonoBehaviour
{
    [SerializeField] private GameObject[] _healthImages;
    [SerializeField] private PlayerData _playerData;

    private void Start()
    {
        _playerData = _playerData.GetComponent<PlayerData>();
        _playerData.OnPlayerHealth += ChangeHealth;
    }

    private void OnDestroy()
    {
        _playerData.OnPlayerHealth -= ChangeHealth;
    }

    private void ChangeHealth(int currentHealth)
    {
       if(currentHealth == 3)
       {
            for (int i = 0; i < currentHealth; i++)
                _healthImages[i].SetActive(true);
            return;
       }

        for (int i = 0; i <= currentHealth; i++)
        {
            if(i == currentHealth)
                _healthImages[i].SetActive(false);
            else
                _healthImages[i].SetActive(true);
        }
    }
}
