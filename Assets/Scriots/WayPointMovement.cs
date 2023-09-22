using UnityEngine;

public class WayPointMovement : MonoBehaviour
{
    [SerializeField] Transform _path;
    [SerializeField] private float _speed = 5f;

    private Transform[] _wayPoints;
    private int _currentWayPointIndex = 0;

    private void Start()
    {
        _wayPoints = new Transform[_path.childCount];
        
        for (int i = 0; i < _path.childCount; i++)
        {
            _wayPoints[i] = _path.GetChild(i);
        }
        //_wayPoints = _path.GetComponentsInChildren<Transform>();
    }

    private void Update()
    {
        Transform destination = _wayPoints[_currentWayPointIndex];
        transform.position = Vector3.MoveTowards(transform.position, destination.position, _speed * Time.deltaTime);

        if (transform.position == destination.position)
        {
            _currentWayPointIndex++;

            if (_currentWayPointIndex == _wayPoints.Length)
            {
                _currentWayPointIndex = 0;
            }
        }
    }
}