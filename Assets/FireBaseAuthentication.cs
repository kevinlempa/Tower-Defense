using System.Collections;
using Firebase.Auth;
using Firebase.Installations;
using UnityEngine;
using UnityEngine.Events;

public class FireBaseAuthentication : MonoBehaviour {

    public UnityEvent fetchedUser;
    public UnityEvent fetchedInstallation;
    
    FirebaseAuth _auth;
    FirebaseUser _currentUser;
    FirebaseInstallations _install;
    private string id;

    public string GetUserId() {
        return _currentUser.UserId;
    }

    public string GetInstallationID() {
        return id;
    }

    public IEnumerator CreateInstallationID() {
        _install = FirebaseInstallations.DefaultInstance;
        var registerTask = _install.GetIdAsync();
        yield return new WaitUntil(()=>registerTask.IsCompleted);
        id = registerTask.Result;
        Debug.Log(id);
        fetchedInstallation?.Invoke();
        
    }
    public IEnumerator SigninAnonymously() {
        _auth = FirebaseAuth.DefaultInstance;
        var registerTask = _auth.SignInAnonymouslyAsync();
        
        yield return new WaitUntil(()=>registerTask.IsCompleted);
        
        _currentUser = registerTask.Result;
        fetchedUser?.Invoke();
    }
}
