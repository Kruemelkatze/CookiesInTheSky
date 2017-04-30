﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzeriaTrigger : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Grid.SoundManager.SetCurrentTheme(Grid.SoundManager.PizzeriaTheme);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Grid.SoundManager.SetDefaultThemeAsCurrentTheme();
        }
    }
}
