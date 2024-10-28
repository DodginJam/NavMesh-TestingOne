using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    public Rigidbody WeaponRigidBody
    { get; private set; }

    public bool EnablePlayerDamage
    { get; private set; } = false;

    private void Awake()
    {
        WeaponRigidBody = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (EnablePlayerDamage && other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Deal damage to player");
        }
    }

    public void SetWeaponTrigger(bool setState)
    {
        EnablePlayerDamage = setState;
    }
}
