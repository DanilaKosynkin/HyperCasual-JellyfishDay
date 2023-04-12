using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    [SerializeField] private GameObject _startPanel;
    [SerializeField] private GameObject _shopPanel;

    private void Start()
    {
        Time.timeScale = 1.0f;
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }

    public void OpenShopPanel()
    {
        _startPanel.SetActive(false);
        _shopPanel.SetActive(true);
    }
    public void CloseShopPanel()
    {
        _shopPanel.SetActive(false);
        _startPanel.SetActive(true);
    }
}
