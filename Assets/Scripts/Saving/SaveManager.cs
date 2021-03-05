using System;
using System.Threading.Tasks;
using Firebase.Database;
using UnityEngine;

namespace Saving {
    public class SaveManager : MonoBehaviour {
        private string PLAYER_KEY {
            get => FindObjectOfType<FireBaseAuthentication>().GetUserId();
        }
        private FirebaseDatabase _database;

        private void Start() {
            _database = FirebaseDatabase.GetInstance("https://tower-defense-c0bbd-default-rtdb.europe-west1.firebasedatabase.app/");
        }

        public void SaveKillCount(KillCountData data) {
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

        public void EraseSave() {
            _database.GetReference(PLAYER_KEY).RemoveValueAsync();
        }
    }
}