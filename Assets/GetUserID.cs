using UnityEngine;
using UnityEngine.UI;

public class GetUserID : MonoBehaviour {
    public GameObject firebaseHolder;

    public void FetchUser() {
        GetComponent<Text>().text = "UserID: " + firebaseHolder.GetComponent<FireBaseAuthentication>().GetUserId();
    }
}
