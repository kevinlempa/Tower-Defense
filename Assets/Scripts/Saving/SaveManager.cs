using System;
using System.Threading.Tasks;
using Firebase.Database;
using JetBrains.Annotations;
using UnityEngine;

namespace Saving {
    public class SaveManager : MonoBehaviour {
        private const string PLAYER_KEY = "PLAYER_KEY";
        private FirebaseDatabase _database;

        private void Start() {
            _database = FirebaseDatabase.DefaultInstance;
        }

        public void SaveKillCount(KillCountData data) {
            PlayerPrefs.SetString(PLAYER_KEY, JsonUtility.ToJson(data));
            _database.GetReference(PLAYER_KEY).SetRawJsonValueAsync(JsonUtility.ToJson(data));
        }


        
        public async Task<KillCountData?> LoadKillCount() {
            var dataSnapshot = await _database.GetReference(PLAYER_KEY).GetValueAsync();
            if (!dataSnapshot.Exists) {
                return null;
            }

            return JsonUtility.FromJson<KillCountData>(dataSnapshot.GetRawJsonValue());
        }

        public async Task<bool> SaveExists() {
            var dataSnapshot = await _database.GetReference(PLAYER_KEY).GetValueAsync();
            return dataSnapshot.Exists;
        }
    }
}