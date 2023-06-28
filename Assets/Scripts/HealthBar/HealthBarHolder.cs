using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarHolder : SetupBehaviour
{
    [SerializeField] protected HealthBarController healthBarController;
    public HealthBarController HealthBarController { get => healthBarController; set { healthBarController = value; } }
    
}