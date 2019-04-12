using UnityEngine;
using System.Collections;

public class Neck : MonoBehaviour
{
    public GameObject startPoint;
    public GameObject endPoint;
    public Vector3 startPosition;
    public Vector3 endPosition;
    
    private void Update()
    {
        startPosition = startPoint.transform.position;
        endPosition = endPoint.transform.position;
        Strech(gameObject, startPosition, endPosition);
    }

    public void Strech(GameObject _sprite, Vector3 _initialPosition, Vector3 _finalPosition)
    {
        float width = _sprite.GetComponent<SpriteRenderer>().bounds.size.y;
        Vector3 centerPos = (_initialPosition + _finalPosition) / 2f;
        _sprite.transform.position = centerPos;
        Vector3 direction = _finalPosition - _initialPosition;
        direction = Vector3.Normalize(direction);
        _sprite.transform.up = direction;
        Vector3 scale = new Vector3(1, 1, 1);
        scale.y = Vector3.Distance(_initialPosition, _finalPosition) / width;
        _sprite.transform.localScale = scale;
    }
}
