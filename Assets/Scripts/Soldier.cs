using UnityEngine;
using UnityEngine.AI;

public class Soldier : MonoBehaviour
{
    [SerializeField] private Transform _targetTransform;

    void Start() 
    {
        NavMeshAgent navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.SetDestination(_targetTransform.position);
    }
    private void Update()
    {

        float distanceToDestination = Vector3.Distance(transform.position, _targetTransform.position);
        Debug.Log($"{distanceToDestination}");

        if (distanceToDestination < 1.5f) 
        {
            Debug.Log("Reach destination");
            Destroy(this.gameObject);
        }

    }

}
