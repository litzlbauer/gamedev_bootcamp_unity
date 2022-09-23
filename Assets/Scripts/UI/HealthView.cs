using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TextMeshProUGUI))]
public class HealthView : MonoBehaviour
{
    public GameObject Player;

    private TextMeshProUGUI Text;
    
    // Start is called before the first frame update
    void Awake()
    {
        Text = GetComponent<TextMeshProUGUI>();
        
    }

    private void OnEnable()
    {
        if (Player)
        {
            Player.GetComponent<HealthComponent>().HealthChangedEvent += OnHealthChanged;
            Text.text = "Health: " + Player.GetComponent<HealthComponent>().Health;
        }
    }
    
    private void OnDisable()
    {
        if (Player)
        {
            Player.GetComponent<HealthComponent>().HealthChangedEvent -= OnHealthChanged;
        }
    }

    void OnHealthChanged(float value)
    {
        Text.text = "Health: " + value;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
