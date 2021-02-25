using UnityEngine;

namespace Enemies
{
    [CreateAssetMenu]
    public class EnemyType : ScriptableObject
    {
        public new string name;
        public int attack;
        public float health;
        public float speed;
      
       
        public MeshFilter meshFilter;
    }
}
