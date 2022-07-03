using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    public LayerMask whatCanBeClickedOn;
    private NavMeshAgent myAgent;

    private void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(myRay, out hit, 100, whatCanBeClickedOn))
            {
                myAgent.SetDestination(hit.point);
            }


        }
    }
}
