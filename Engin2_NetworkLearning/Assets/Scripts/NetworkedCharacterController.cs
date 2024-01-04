using UnityEngine;
using UnityEngine.AI;
using Mirror;

public class NetworkedCharacterController : NetworkBehaviour
{
    private const float MINIMUM_MOVEMENT_SPEED = 0.1F;
    [SerializeField]
    private NavMeshAgent m_navMeshAgent;
    private Animator m_animator;
    [SerializeField]
    private Camera m_camera;

    private void Start()
    {
        m_animator = GetComponent<Animator>();
        
        if(isLocalPlayer)
        {
            m_camera.gameObject.SetActive(true);
        }
    }

    private void Update()
    {
        if (!isLocalPlayer) 
        {
            return;
        }

        UpdateMovementInput();
        UpdateAnimator();

        if(Input.GetKeyDown(KeyCode.Space))
        {
            NetworkedWall._instance.gameObject.SetActive(!NetworkedWall._instance.gameObject.activeInHierarchy);
        }

    }

    private void UpdateMovementInput()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            int layerMask = LayerMask.NameToLayer("NavMesh");

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, ~layerMask)) //~ means that raycast will hit everything except the layers specified in layerMask
            {
                m_navMeshAgent.SetDestination(hit.point);
            }
        }
    }

    private void UpdateAnimator()
    {
        // Je pourrais faire un blend d'animation si mon personnage marche de coter et tout
        bool isMoving = m_navMeshAgent.velocity.magnitude > MINIMUM_MOVEMENT_SPEED;
        //bool isMoving = m_navMeshAgent.remainingDistance > m_navMeshAgent.stoppingDistance;

        m_animator.SetBool("Walking", isMoving);
    }
}
