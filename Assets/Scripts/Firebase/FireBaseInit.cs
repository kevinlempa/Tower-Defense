using Firebase.Analytics;
using UnityEngine;

namespace Firebase {
    public class FireBaseInit : MonoBehaviour
    {
        void Start() {
            FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
                FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);
            });
        }

        //WE CAN NOW LOG FIREBASE EVENTS AFTER THIS START METHOD(or inside after set-analytics-collect(true))^^
    }
}