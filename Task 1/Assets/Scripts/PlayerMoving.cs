using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMoving : MonoBehaviour
{
    private Camera cam;
    private NavMeshAgent agent;

    public int defaultArea;

    private float currentCost;
    private float basicSpeedModifier;

    private void Start()
    {
        cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();

        currentCost = agent.GetAreaCost(defaultArea);

        basicSpeedModifier = currentCost * agent.speed;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<NavMeshModifier>() != null)
        {
            var currentArea = other.GetComponent<NavMeshModifier>().area;
            currentCost = agent.GetAreaCost(currentArea);

            SetSpeed(currentCost);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<NavMeshModifier>() != null)
        {
            currentCost = agent.GetAreaCost(defaultArea);
            SetSpeed(currentCost);
        }
    }

    void SetSpeed(float cost)
    {
        agent.speed = basicSpeedModifier / cost;
    }

}
