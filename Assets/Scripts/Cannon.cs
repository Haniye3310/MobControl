using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] private float speed = 0.2f;

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            var touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            transform.Translate(0, 0, touchDeltaPosition.x * speed);
        }
#if UNITY_EDITOR
        if (Input.GetMouseButton(0))
        {
            var mouseDeltaPosition = new Vector3(0, 0, Input.GetAxis("Mouse X"));
            transform.Translate(mouseDeltaPosition * speed);
        }
#endif
    }

}



