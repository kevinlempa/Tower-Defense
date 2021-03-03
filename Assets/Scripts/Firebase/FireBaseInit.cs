using Firebase.Analytics;
using UnityEngine;

namespace Firebase {
    public class FireBaseInit : MonoBehaviour
    {
        void Start() {
            FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
                FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);
                TestingFirebaseAnalyticsEvents();
            });
        }

        
        
        void TestingFirebaseAnalyticsEvents() {
            FirebaseAnalytics.LogEvent("Did", "Purchase", "Yes");
            
            FirebaseAnalytics.LogEvent("Did", "Eat", "No");
            
            FirebaseAnalytics.LogEvent("Did", "Play Warzone", "Yes");
            
            FirebaseAnalytics.LogEvent("Health", "float", 0.5f);
            
            FirebaseAnalytics.LogEvent("Status", "int", 5);
            
            FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventEarnVirtualCurrency);
        }
    }
}
