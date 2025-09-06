using System.Globalization;
using Playbox;
using UnityEngine;
using Firebase.Analytics;

public class AppCrusher : MonoBehaviour
{
   public void Kupit()
   {
        FirebaseAnalytics.LogEvent(
                              FirebaseAnalytics.EventPurchase,
                              new Parameter(FirebaseAnalytics.ParameterTransactionID, "jmz323bz"),
                              new Parameter(FirebaseAnalytics.ParameterValue, 323.ToString(CultureInfo.InvariantCulture)),
                              new Parameter(FirebaseAnalytics.ParameterCurrency, "USD")
                          );
   }
}
