using System.Threading.Tasks;
using UnityEngine;
using DG.Tweening;

public class Cannon : MonoBehaviour
{
    [SerializeField] private float _speed = 0.2f;
    [SerializeField] private Soldier _playerSoldierPrefab;
    [Range(0.1f, 50)]
    [SerializeField] private float _generationDelaySecond;
    private bool _isTouch;

    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            var touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            transform.Translate(0, 0, touchDeltaPosition.x * _speed*Time.deltaTime);
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
                Soldier s =Instantiate(_playerSoldierPrefab, this.transform.position, Quaternion.identity);
                s.transform.DOMove(new Vector3(this.transform.position.x,this.transform.position.y, this.transform.position.z +3), 0.1f,true).SetEase(Ease.Linear);
                await Task.Delay((int)(_generationDelaySecond*1000));
            }
            await Task.Yield();
        }
    }
}



