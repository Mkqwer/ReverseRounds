using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatManager : MonoBehaviour
{
    public static PlayerStatManager Instance { get; private set; }

    public float health = 100.0f;
    public float attack = 10.0f;
    public float attackSpeed = 1.0f;
    public float bulletSpeed = 1.0f;
    public float speed = 1.0f;

    void Awake()
    {
        
        if (Instance == null)
        {
            Instance = this;
            
        }
        else
        {
            Destroy(gameObject); 
        }
    }

    void Start()
    {
        
    }

    void Update()
    {

    }
}
