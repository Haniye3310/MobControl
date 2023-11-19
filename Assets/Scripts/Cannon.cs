using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] private float _speed = 0.2f;
    [SerializeField] private Soldier _soldierPrefab;
    private bool _isTouch;

    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            var touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            transform.Translate(0, 0, touchDeltaPosition.x * _speed);
        }
#if UNITY_EDITOR
        if (Input.GetMouseButton(0))
        {
            var mouseDeltaPosition = new Vector3(0, 0, Input.GetAxis("Mouse X"));
            transform.Translate(mouseDeltaPosition * _speed);
        }
#endif
        if (Input.GetMouseButton(0) || Input.touchCount > 0)_isTouch = true;
        else {_isTouch = false;}
    }
    private void Awake()
    {
        GenerateSoldier();
    }
    private async void GenerateSoldier() 
    {
        while (true) 
        {
            if (_isTouch) 
            {
                Instantiate(_soldierPrefab, this.transform.position, Quaternion.identity);
                await Task.Delay(1000);
            }
            await Task.Yield();
        }
    }
}



