using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
public class AdsCore : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField] private bool _testMode = true;

    private string _id = "4792732";

    private void Awake()
    {
        Advertisement.Initialize(_id, _testMode, this);
        Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
    }

    public void OnInitializationComplete() { }
    public void OnInitializationFailed(UnityAdsInitializationError error, string message) { }
}
