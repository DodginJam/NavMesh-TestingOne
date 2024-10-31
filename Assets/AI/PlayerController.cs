using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public Camera CurrentCamera
    { get; private set; }

    [field: SerializeField] public NavMeshAgent Agent
    { get; private set; }

    private void Awake()
    {
        CurrentCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
    }
    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray screenToWorldRay = CurrentCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit rayHit;

            if (Physics.Raycast(screenToWorldRay, out rayHit))
            {
                Agent.SetDestination(rayHit.point);
            }
        }
    }
}
