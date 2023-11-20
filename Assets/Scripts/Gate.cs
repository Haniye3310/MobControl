using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] private int _ratio;
    private List<int> _passedSoldiers = new List<int>();
    private void OnTriggerExit(Collider other)
    {
        if (_passedSoldiers.Contains(other.gameObject.GetInstanceID())) return;
        if(other.gameObject.GetComponent<Soldier>())
        {
            _passedSoldiers.Add(other.gameObject.GetInstanceID());
            for (int i = 0; i < _ratio - 1; i++) 
            {
                GameObject s = Instantiate(other.gameObject, other.gameObject.transform.position + other.transform.forward, Quaternion.identity);
                _passedSoldiers.Add(s.gameObject.GetInstanceID());
            }
        }
    }
}
