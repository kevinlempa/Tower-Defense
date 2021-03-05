using System;
using System.Collections;
using Saving;
using UnityEngine;
using UnityEngine.UI;

public class KillCounter : MonoBehaviour {
    private SaveManager saveManager;
    [SerializeField]  private KillCountData _data;
    public KillCountData Data => _data;
    [SerializeField] private int _killCount => _data.KillCount;
    

        Text killCounterText;
        

        IEnumerator  Start() {
            saveManager = FindObjectOfType<SaveManager>();
        killCounterText = GetComponent<Text>();
        killCounterText.text = $"Kills: ";
     
        yield return new WaitForSeconds(1f);
        Publisher.i.onKill += UpdateKillCounter;
        var dataTask = saveManager.LoadKillCount();
        yield return new WaitUntil(()=> dataTask.IsCompleted);
        var data = dataTask.Result;
        if (data.HasValue) {
            _data.KillCount = data.Value.KillCount;
            killCounterText.text = $"Kills: {_killCount}";
        }

    }

    private void UpdateKillCounter() {
        _data.KillCount += 1;
        saveManager.SaveKillCount(_data);
        killCounterText.text = $"Kills: {_killCount}";
        PlayerPrefs.SetInt("Kills", _killCount);
    }
}
