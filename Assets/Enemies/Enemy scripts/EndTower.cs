using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndTower : MonoBehaviour
{
    public float health = 100;
    public Text healthUI;
    void Start()
    {
        
    }

    void Update()
    {
        healthUI.text = health.ToString();
    }
}
