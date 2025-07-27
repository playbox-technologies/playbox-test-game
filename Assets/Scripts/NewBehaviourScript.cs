using System.Collections;
using System.Collections.Generic;
using CI.Utils.Extentions;
using InspectorButton;
using Playbox;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [InspectorButton.Button]
    void sss()
    {
        Dictionary<string,bool> dic = new Dictionary<string, bool>();
        
        dic[nameof(PlayboxSplashUGUILogger)] = true;
        dic[nameof(FirebaseInitialization)] = false;
        dic[nameof(AppsFlyerInitialization)] = true;
        dic[nameof(DevToDevInitialization)] = false;
        dic[nameof(FacebookSdkInitialization)] = true;
        dic[nameof(AppLovinInitialization)] = false;
        dic[nameof(IAP)] = false;

        foreach (var item in dic)
        {
           // item.Value.PlayboxInfo("dic");
        }
        
        //dic[nameof(NewBehaviourScript)].PlayboxInfo("ndic");
        
        dic.TryGetValue(nameof(NewBehaviourScript), out bool value);
        value.PlayboxInfo("ndic");
    }

    [Button]
    void TestFirebaseInitialization()
    {
        Analytics.TrackEvent("FirebaseInitialization");
    }

    [Button]
    void CheckInitsOfSDK()
    {
        MainInitialization.IsValidate<PlayboxSplashUGUILogger>().PlayboxInfo("PlayboxSplashUGUILogger");
        MainInitialization.IsValidate<FirebaseInitialization>().PlayboxInfo("FirebaseInitialization");
        MainInitialization.IsValidate<AppsFlyerInitialization>().PlayboxInfo("AppsFlyerInitialization");
        MainInitialization.IsValidate<DevToDevInitialization>().PlayboxInfo("DevToDevInitialization");
        MainInitialization.IsValidate<FacebookSdkInitialization>().PlayboxInfo("FacebookSdkInitialization");
        MainInitialization.IsValidate<AppLovinInitialization>().PlayboxInfo("AppLovinInitialization");
        MainInitialization.IsValidate<IAP>().PlayboxInfo("IAP");
    }
}
