using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    Rigidbody2D body;
    [SerializeField] GameObject panel;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D other) {

        if (other.gameObject.CompareTag("balls"))
        {
            Time.timeScale = 0;
            panel.SetActive(true);
        }
    }
}
