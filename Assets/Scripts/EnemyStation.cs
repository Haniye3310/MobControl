using DG.Tweening;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyStation : MonoBehaviour
{
    [SerializeField] private Soldier _enemySoldierPrefab;
    [SerializeField] private int _health;
    [SerializeField] private TextMeshPro _healthText;
    [SerializeField] private SOChannelEvent _onSoldierReachesEnemyStation;
    [Range(0.1f, 50)]
    [SerializeField] private float _generationDelaySecond;
    [SerializeField] private SOChannelEvent _onPlayerWin;
    private void Awake()
    {
        GenerateSoldier();
        SetHealth(_health);
    }
    private void OnEnable()
    {
        _onSoldierReachesEnemyStation.Event.AddListener(OnPlayerSoldierReached);
    }
    private void OnDisable()
    {
        _onSoldierReachesEnemyStation.Event.RemoveListener(OnPlayerSoldierReached);

    }
    private void OnPlayerSoldierReached() 
    {
        SetHealth(_health - 1);
    }
    private async void GenerateSoldier()
    {
        while (true)
        {
            Soldier s = Instantiate(_enemySoldierPrefab, this.transform.position, Quaternion.identity);
            s.transform.DOMove(new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - 3), 0.1f, true).SetEase(Ease.Linear);
            await Task.Delay((int)(_generationDelaySecond * 1000));
        }
    }
    private void SetHealth(int health) 
    {
        _health = health;
        _healthText.text = _health.ToString();
        if(_health == 0) 
        {
            _onPlayerWin.Event?.Invoke();
        }
    }
}
