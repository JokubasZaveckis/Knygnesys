using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Advertisement.Initialize("5066417");
    }

    // Update is called once per frame
    public void PlayAd()
    {
        if(Advertisement.IsReady("Interstitial_Android"))
        {
            // var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show("Interstitial_Android");
        }
    }

    // private void HandleShowResult(ShowResult result)
    // {
    //     switch (result)
    //     {
    //         case ShowResult.Finished:
    //             Debug.Log("The ad was successfully shown.");
    //             break;
    //         case ShowResult.Skipped:
    //             Debug.Log("The ad was skipped before reaching the end.");
    //             break;
    //         case ShowResult.Failed:
    //             Debug.LogError("The ad failed to be shown.");
    //             break;
    //     }
    // }
}
