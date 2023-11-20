using DG.Tweening;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class EnemyStation : MonoBehaviour
{
    [SerializeField] private Soldier _enemySoldierPrefab;
    [SerializeField] private int _health;
    [SerializeField] private TextMeshPro _healthText;
    [SerializeField] private SOChannelEvent _onSoldierReachesEnemyStation;
    private void Awake()
    {
        GenerateSoldier();
        SetHealth(_health);
    }
    private void OnEnable()
    {
        _onSoldierReachesEnemyStation.Event.AddListener(OnSoldierReached);
    }
    private void OnDisable()
    {
        _onSoldierReachesEnemyStation.Event.RemoveListener(OnSoldierReached);

    }
    private void OnSoldierReached() 
    {
        Debug.Log("OnS");
        SetHealth(_health - 1);
    }
    private async void GenerateSoldier()
    {
        while (true)
        {
            Soldier s = Instantiate(_enemySoldierPrefab, this.transform.position, Quaternion.identity);
            s.transform.DOMove(new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 3), 0.1f, true).SetEase(Ease.Linear);
            await Task.Delay(6000);
        }
    }
    private void SetHealth(int health) 
    {
        _health = health;
        _healthText.text = _health.ToString();
    }
}
