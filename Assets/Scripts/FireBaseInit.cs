using Firebase;
using Firebase.Analytics;
using Firebase.Extensions;
using Firebase.Installations;
using UnityEngine;
using UnityEngine.Purchasing;


public class FireBaseInit : MonoBehaviour {
    FireBaseAuthentication auth;

    void Awake() {
        auth = GetComponent<FireBaseAuthentication>();


        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task => {

            FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);
            StartCoroutine(auth.SigninAnonymously());
            StartCoroutine(auth.CreateInstallationID());
        });
    }

    //WE CAN NOW LOG FIREBASE EVENTS AFTER THIS START METHOD(or inside after set-analytics-collect(true))^^
 
}