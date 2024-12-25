using Firebase;
using Firebase.Analytics;
using UnityEngine;

public class FirebaseWindowsAnalyticsTest : MonoBehaviour
{
    void Start()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
            FirebaseApp app = FirebaseApp.DefaultInstance;

            FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);
            FirebaseAnalytics.LogEvent("game_start_new");

            if (Application.isEditor || Application.platform == RuntimePlatform.WindowsPlayer)
            {
                //FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);
                //FirebaseAnalytics.LogEvent("game_start");
            }
        });
    }
}
