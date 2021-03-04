using Saving;
using UnityEngine;
using UnityEngine.UI;

public class KillCounter : MonoBehaviour {
    private SaveManager saveManager;
    [SerializeField]  private KillCountData _data;
    public KillCountData Data => _data;
    [SerializeField] private int _killCount => _data.KillCount;
    

        Text killCounterText;

    void Start() {
        saveManager = FindObjectOfType<SaveManager>();
        killCounterText = GetComponent<Text>();
        killCounterText.text = $"Kills: {PlayerPrefs.GetInt("Kills")}";
        _data.KillCount = PlayerPrefs.GetInt("Kills");
        Publisher.i.onKill += UpdateKillCounter;
    }

    private void UpdateKillCounter() {
        _data.KillCount += 1;
        saveManager.SaveKillCount(_data);
        killCounterText.text = $"Kills: {_killCount}";
        PlayerPrefs.SetInt("Kills", _killCount);
    }
}
