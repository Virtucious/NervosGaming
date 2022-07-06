using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    public LayerMask whatCanBeClickedOn;
    private NavMeshAgent myAgent;
    public Animator playerAnimator;

    private void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
        myAgent.speed = 0f;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            myAgent.speed = 5f;
            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(myRay, out hit, 100, whatCanBeClickedOn))
            {
                myAgent.SetDestination(hit.point);
            }

            if (myAgent.transform.position == hit.point)
            {
                myAgent.speed = 0f;
            }

            if (myAgent.speed > 0f)
            {
                playerAnimator.SetBool("isWalking", true);
            }
            else
            {
                playerAnimator.SetBool("isWalking", false);
            }
        }



    }
}
