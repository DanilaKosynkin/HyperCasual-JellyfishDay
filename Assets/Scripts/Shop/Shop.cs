using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private Button _leftButton;
    [SerializeField] private Button _rightButton;
    [SerializeField] private Button _buyButton;
    [SerializeField] private TMP_Text _costText;
    [SerializeField] private TMP_Text _currentCoinsText;
    [SerializeField][Tooltip("0 left cell, 1 midle cell, 2 right cell")]  private GameObject[] _cellObjects;
    [SerializeField] private Item[] _skinsData;

    private List<Image> _cellImage;
    private List<Sprite> _skinsSprite;
    private int _currentIndexSkin;
    private int _currentPlayerSkin;
    private int _currentCoins;

    private void Start()
    {
        _currentPlayerSkin = PlayerPrefs.GetInt("CurrentPlayerSkin");
        _currentIndexSkin = _currentPlayerSkin;
        PlayerPrefs.SetInt("CurrentCoins", 35 + PlayerPrefs.GetInt("CurrentCoins"));
        _currentCoins = PlayerPrefs.GetInt("CurrentCoins");
        _currentCoinsText.text = _currentCoins.ToString();
        InitLists();
        SkinsInit();
    }

    private void InitLists()
    {
        _skinsSprite = new List<Sprite>();
        for (int i = 0; i < _skinsData.Length; i++)
            _skinsSprite.Add(_skinsData[i].GetSprite());

        _cellImage = new List<Image>();
        for (int i = 0; i < _cellObjects.Length; i++)
            _cellImage.Add(_cellObjects[i].GetComponent<Image>());
    }

    private void SkinsInit()
    {
        if(_currentIndexSkin > 0 && _currentIndexSkin < _skinsSprite.Count - 1)
            CellsSprite(_currentIndexSkin - 1, _currentIndexSkin, _currentIndexSkin + 1);
        else if(_currentIndexSkin == _skinsSprite.Count - 1)
            CellsSprite(_currentIndexSkin - 1, _currentIndexSkin, 0);
        else
            CellsSprite(_skinsSprite.Count - 1, 0, 1);

        _costText.text = _skinsData[_currentIndexSkin].GetCost().ToString();
        CheckingAvailabilityCoins();

        for (int i = 0; i < _cellObjects.Length; i++)
        {
            if (_cellImage[i].sprite == null)
                _cellImage[i].gameObject.SetActive(false);
            else _cellImage[i].gameObject.SetActive(true);
        }
    }

    private void CellsSprite(int leftCell, int midleCeell, int rightCell)
    {
        _cellImage[0].sprite = _skinsSprite[leftCell];
        _cellImage[1].sprite = _skinsSprite[midleCeell];
        _cellImage[2].sprite = _skinsSprite[rightCell];
    }

    private void RecalculationIndex()
    {
        if (_currentIndexSkin > _skinsSprite.Count - 1)
            _currentIndexSkin = 0;
        if (_currentIndexSkin < 0)
            _currentIndexSkin = _skinsSprite.Count - 1;
    }

    private void CheckingAvailabilityCoins()
    {
        if (PlayerPrefs.GetInt("CurrentPlayerSkin") == _currentIndexSkin)
            _buyButton.gameObject.SetActive(false);
        else if (_currentCoins >= _skinsData[_currentIndexSkin].GetCost())
            _buyButton.gameObject.SetActive(true);
        else _buyButton.gameObject.SetActive(false);
    }

    public void BuySkinButton()
    {
        _currentCoins -= _skinsData[_currentIndexSkin].GetCost();
        _currentCoinsText.text = _currentCoins.ToString();
        PlayerPrefs.SetInt("CurrentCoins", _currentCoins);
        PlayerPrefs.SetInt("CurrentPlayerSkin", _currentIndexSkin);
        CheckingAvailabilityCoins();
    }

    public void LeftSkinButton()
    {
        _currentIndexSkin--;
        RecalculationIndex();
        SkinsInit();
    }

    public void RightSkinButton()
    {
        _currentIndexSkin++;
        RecalculationIndex();
        SkinsInit();
    }
}
