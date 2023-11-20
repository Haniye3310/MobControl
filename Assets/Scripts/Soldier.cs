using UnityEngine;
using UnityEngine.AI;

public class Soldier : MonoBehaviour
{
    private Transform _targetTransform;
    [SerializeField] private Transform _enemyTransform;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private SOChannelEvent _onSoldierReachesEnemyStation;
    private void Awake()
    {
        if (this.gameObject.tag == "Player")
            _targetTransform = _enemyTransform;
        if(this.gameObject.tag == "Enemy")
            _targetTransform = _playerTransform;
    }
    private void Start() 
    {
        NavMeshAgent navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.SetDestination(_targetTransform.position);
    }
    private void Update()
    {

        float distanceToDestination = Vector3.Distance(transform.position, _targetTransform.position);

        if (distanceToDestination < 1.5f) 
        {
            Destroy(this.gameObject);
            if (this.gameObject.tag == "Player")
                _onSoldierReachesEnemyStation.Event?.Invoke();
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Soldier>()) 
        {
            if (
                (this.gameObject.tag == "Player" && other.gameObject.tag == "Enemy") ||
                (this.gameObject.tag == "Enemy"&& other.gameObject.tag == "Player")
                ) 
            {
                Destroy(this.gameObject);
            }

        }
    }
}
