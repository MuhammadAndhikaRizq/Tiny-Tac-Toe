using UnityEngine;

public class TileMovement: MonoBehaviour
{
    [SerializeField] private float range = 1f;
    [SerializeField] private float speed = 5f;

    public GameManager gameManager;

    private Vector3 startPosition;
    private Vector3 targetPosition;
    private TileBehaviour player;
    private bool isHovered;

    private void Start()
    {
        player = GetComponent<TileBehaviour>();
        startPosition = transform.position;
        targetPosition = startPosition;
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * speed);
    }
    private void OnMouseEnter()
    {
        isHovered = true;
        targetPosition = startPosition + Vector3.up * range;
        gameManager.OnTileSelected(player);
    }

    private void OnMouseExit()
    {
        isHovered = false;
        targetPosition = startPosition;
    }
}
