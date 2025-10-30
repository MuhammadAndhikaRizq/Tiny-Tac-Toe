using System;
using UnityEngine;

public class TileMovement: MonoBehaviour
{
    [SerializeField] private float range = 1f;
    [SerializeField] private float speed = 5f;

    private Vector3 startPosition;
    private Vector3 targetPosition;
    private TileBehaviour tileBuilding;

    public event Action<TileBehaviour> OnBuild;

    private void Start()
    {
        tileBuilding = GetComponent<TileBehaviour>(); 
        startPosition = transform.position;
        targetPosition = startPosition;
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * speed);
    }
    private void OnMouseDown()
    {
        targetPosition = startPosition + Vector3.up * range;

        OnBuild?.Invoke(tileBuilding);
    }

    private void OnMouseExit()
    {
        targetPosition = startPosition;
    }
}
