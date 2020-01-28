using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    [SerializeField] int damage = 10;
    
    void Start()
    {
        Destroy(gameObject, 1);
    }

    void OnCollisionEnter2D(Collision2D other) {
        Destroy(gameObject);
    }

    public int GetDamage() {
        return damage;
    }
}
