using TMPro;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameUI : MonoBehaviour
{
    [SerializeField][Tooltip("0 player, 1 pause, 2 exit, 3 revival, 4 dead")] private GameObject[] _gameCanvases;

    [SerializeField] private Image _rerivalTimer;
    [SerializeField] private Restart _restart;
    [SerializeField] private TMP_Text _recordText;

    private PlayerData _playerData;
    private float _timeToRevival = 1f;
    private bool _isRevival;

    private void Start()
    {
        TimeScale(1);
        _playerData = PlayerData.Instance;
        _restart = _restart.GetComponent<Restart>();
        _playerData.OnPlayerDead += ActivateRevivalCanvas;
        _restart.OnRevival += PlayerRevival;
    }

    private void OnDestroy()
    {
        _playerData.OnPlayerDead -= ActivateRevivalCanvas;
        _restart.OnRevival -= PlayerRevival;
    }

    private void Update()
    {
        if (_isRevival)
        {
            _timeToRevival -= Time.deltaTime * 0.2f;
            _rerivalTimer.fillAmount = _timeToRevival;
            if (_timeToRevival <= 0)
            {
                _timeToRevival = 1f;
                _isRevival = false;
                ActivateDeadCanvas();
            }
        }
    }

    private void PlayerRevival()
    {
        TimeScale(1);
        ActivateNeedCanvas(_gameCanvases[0]);
    }

    private void ActivateRevivalCanvas()
    {
        _timeToRevival = 1f;
        _isRevival = true;
        TimeScale(1);
        ActivateNeedCanvas(_gameCanvases[3]);
    }
    public void ActivateDeadCanvas()
    {
        _isRevival = false;
        TimeScale(0);
        _playerData.SaveData(_recordText);
        ActivateNeedCanvas(_gameCanvases[4]);
    }

    public void ShowRevivalAdsButton()
    {
        RevivalAds.Instance.ShowAds();
    }

    public void RestartButton()
    {
        TimeScale(1);
        _restart.OnRestart?.Invoke();
        ActivateNeedCanvas(_gameCanvases[0]);
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void TimeScale(float timeScale)
    {
        Time.timeScale = timeScale;
    }

    public void ActivateNeedCanvas(GameObject needCanvas)
    {
        foreach (var canvas in _gameCanvases)
            canvas.SetActive(false);
        needCanvas.SetActive(true);
    }
}
