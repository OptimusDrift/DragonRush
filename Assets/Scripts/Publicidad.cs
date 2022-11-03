using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Mediation;
using System.Threading.Tasks;

public class Publicidad : MonoBehaviour
{
    public string androidAdUnitId;
    public string iosAdUnitId;
    IRewardedAd rewardedAd;

    async void Start()
    {

        // Initialize the package to access API
        await UnityServices.InitializeAsync();

        // Instantiate a rewarded ad object with platform-specific Ad Unit ID
        if (Application.platform == RuntimePlatform.Android)
        {
            rewardedAd = new RewardedAd(androidAdUnitId);
        }
        else if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            rewardedAd = new RewardedAd(iosAdUnitId);
        }
#if UNITY_EDITOR
        else
        {
            rewardedAd = new RewardedAd("myExampleAdUnitId");
        }
#endif

        // Subscribe callback methods to load events:
        rewardedAd.OnLoaded += AdLoaded;
        rewardedAd.OnFailedLoad += AdFailedToLoad;

        // Subscribe callback methods to show events:
        rewardedAd.OnShowed += AdShown;
        rewardedAd.OnFailedShow += AdFailedToShow;
        rewardedAd.OnUserRewarded += UserRewarded;
        rewardedAd.OnClosed += AdClosed;

        try
        {
            // Load an ad:
            await rewardedAd.LoadAsync();
            // Here our load succeeded.

            // This is for demonstration purposes, we recommend you load the
            // ad in advance, and show when needed as load may take some time
            await ShowAd();
        }
        catch (Exception e)
        {
            // Here our load failed.
        }

    }

    // Implement load event callback methods:
    void AdLoaded(object sender, EventArgs args)
    {
        Debug.Log("Ad loaded.");
        // Execute logic for when the ad has loaded

    }

    void AdFailedToLoad(object sender, LoadErrorEventArgs args)
    {
        Debug.Log("Ad failed to load.");
        // Execute logic for the ad failing to load.
    }

    // Implement show event callback methods:
    void AdShown(object sender, EventArgs args)
    {
        Debug.Log("Ad shown successfully.");
        // Execute logic for the ad showing successfully.
    }

    void UserRewarded(object sender, RewardEventArgs args)
    {
        Debug.Log("Ad has rewarded user.");
        // Execute logic for rewarding the user.
    }

    void AdFailedToShow(object sender, ShowErrorEventArgs args)
    {
        Debug.Log("Ad failed to show.");
        // Execute logic for the ad failing to show.
    }

    void AdClosed(object sender, EventArgs e)
    {
        Debug.Log("Ad is closed.");
        // Execute logic for the user closing the ad.
    }

    public async Task ShowAd()
    {
        // Ensure the ad has loaded, then show it.
        if (rewardedAd.AdState == AdState.Loaded)
        {
            try
            {
                await rewardedAd.ShowAsync();
                // Here show succeeded.
            }
            catch (Exception e)
            {
                // Here show failed.
            }
        }
    }
}
