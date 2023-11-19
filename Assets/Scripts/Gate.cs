using UnityEngine;

public class Gate : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("T");
        if(other.gameObject.GetComponent<Soldier>())
        {
            Instantiate(other.gameObject,other.gameObject.transform.position + transform.forward,Quaternion.identity);
        }
    }
}
