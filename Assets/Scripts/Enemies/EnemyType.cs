using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Type")]
    public class EnemyType : ScriptableObject
    {
        public new string name;
        public int attack;
        public float health;
        public float speed;
      
        public MeshRenderer meshRenderer;
        public MeshFilter meshFilter;


    }
}