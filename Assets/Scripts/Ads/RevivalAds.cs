using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
public class RevivalAds: MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] private Restart _restart;   

    private AdsCore _adsCore;
    private string _id = "4792732";
    private string _adsMode = "Rewarded_Android";

    public static RevivalAds Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this.gameObject);
        else
            Instance = this;
    }

    private void Start()
    {
        _adsCore = GetComponent<AdsCore>();
        _restart = _restart.GetComponent<Restart>();
        LoadAds();
    }

    public void LoadAds()
    {
        Advertisement.Load(_adsMode, this);
    }

    public void ShowAds()
    {
        Advertisement.Show(_adsMode, this);
    }
  
    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message) {}
    public void OnUnityAdsShowStart(string placementId) { }
    public void OnUnityAdsShowClick(string placementId) { }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        _restart.OnRevival?.Invoke();
        LoadAds();
    }

    public void OnUnityAdsAdLoaded(string placementId) { }
    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message) { }
}
