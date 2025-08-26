using System.Collections;
using System.Collections.Generic;
using AppsFlyerSDK;
using UnityEngine;

public class CrossPromoTest : MonoBehaviour
{
   [SerializeField] private string appId = "world.dreamsim.businessempire";
   
   [InspectorButton.Button]
   public void CrossPromo()
   {
      AppsFlyer.attributeAndOpenStore(appId,"dreamsim",new(){},this);
   }
}
