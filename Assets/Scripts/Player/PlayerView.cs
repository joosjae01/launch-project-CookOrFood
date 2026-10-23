using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private Transform _player;

    private Vector3 _cameraPosition;

    private void Awake() => InitPosition();

    private void FixedUpdate()
    {
        if (_player == null)
        {
            return;
        }
        
        transform.position = new Vector3(
            _cameraPosition.x,
            _cameraPosition.y,
            _player.position.z);
    }

    private void InitPosition()
    {
        // 이 프리팹을 어디다 꺼내놓아도 위치를 옳게 초기화 시켜줍니다
        transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        _cameraPosition = transform.position;
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }
}
