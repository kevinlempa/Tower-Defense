using System.Collections;
using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public EnemyType type;
    private int attack;
    private float health;
    private float speed;

    public Image healthBar;
    void Start()
    {
        this.attack = type.attack;
        this.health = type.health;
        this.speed = type.speed;
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            TakeDamage();
        }
    }
    
    public void TakeDamage()
    {
        this.health -= 5f;
        healthBar.fillAmount = this.health / type.health;
        if (this.health <= 0) {Destroy(this.gameObject);}
    }

}
