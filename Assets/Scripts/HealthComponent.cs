using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class HealthComponent : MonoBehaviour
{
    public float Health = 1.0f;

    public delegate void HealthChangedDelegate(float value);
    public event HealthChangedDelegate HealthChangedEvent;
    
    public void AddDamage(float damage)
    {
        var NewHealth = Mathf.Max(Health - damage, 0.0f);
        if (NewHealth == Health)
        {
            return;
        }

        Health = NewHealth;
        
        HealthChangedEvent.Invoke(Health);
        
        if (Health == 0.0f)
        {
            Debug.Log("We are dead!");
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
