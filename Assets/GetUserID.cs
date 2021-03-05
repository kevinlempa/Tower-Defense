using UnityEngine;
using UnityEngine.UI;

public class GetUserID : MonoBehaviour {
    public GameObject firebaseHolder;
    public Text InstallationID;

    public void FetchUser() {
        GetComponent<Text>().text = "UserID: " + firebaseHolder.GetComponent<FireBaseAuthentication>().GetUserId();
    }

    public void FetchInstallation() {
        InstallationID.text = "InstallationID: " + firebaseHolder.GetComponent<FireBaseAuthentication>().GetInstallationID();
    }
}
