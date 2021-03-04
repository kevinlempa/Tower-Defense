using UnityEngine;
using UnityEngine.UI;

public class KillCounter : MonoBehaviour {
    
    [SerializeField] int _killCount;
    
    Text killCounterText;

    void Start() {
        killCounterText = GetComponent<Text>();
        killCounterText.text = $"Kills: {PlayerPrefs.GetInt("Kills")}";
    }

    public void Killed() {
        _killCount += 1;
        killCounterText.text = $"Kills: {_killCount}";
        PlayerPrefs.SetInt("Kills", _killCount);
    }
}
