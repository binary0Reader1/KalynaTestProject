using Player;
using UnityEngine;
using UnityEngine.EventSystems;

public class DefaultJoystick : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public Vector2 Direction { get; private set; }

    [SerializeField] private RectTransform _background;
    [SerializeField] private RectTransform _handle;

    private PlayerManagement _player;
    private Vector2 _startPosition = Vector2.zero;
    private Vector2 _position = Vector2.zero;

    private float _maxAllowedSize = 50.0f;

    private void Start()
    {
        _player = FindObjectOfType<PlayerManagement>();
        _maxAllowedSize = _background.sizeDelta.x / 2;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _startPosition = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        _position = eventData.position - _startPosition;
        _handle.localPosition = _position;

        float size = _position.magnitude;

        if (size > _maxAllowedSize)
        {
            _position = _position / size * _maxAllowedSize;
        }

        Direction = _position / _maxAllowedSize;


        _handle.localPosition = _position;

        _player.Direction = Direction;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        Direction = Vector2.zero;
        _handle.localPosition = Vector2.zero;

        _player.Direction = Direction;
    }
}