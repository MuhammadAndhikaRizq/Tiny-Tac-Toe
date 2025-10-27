using UnityEngine;

public class TileMovement: MonoBehaviour
{
    [SerializeField] private float range = 1f;
    [SerializeField] private float speed = 5f;

    private Vector3 startPosition;
    private Vector3 targetPosition;

    private void Start()
    {
        startPosition = transform.position;
        targetPosition = startPosition;
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * speed);
    }
    private void OnMouseEnter()
    {
        targetPosition = startPosition + Vector3.up * range;
    }

    private void OnMouseExit()
    {
        targetPosition = startPosition;
    }
}
