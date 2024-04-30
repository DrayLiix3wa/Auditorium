using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseManager : MonoBehaviour
{
    public Texture2D centerIcon;
    public Texture2D outterIcon;
    private Ray _ray;
    private bool _isClicked;
    private GameObject _objectToMove = null;
    private CircleShape _objectToResize = null;
    private Vector3 _worldPosition;

    public float minRadius;
    public float maxRadius;

    void Update()
    {
        Debug.Log(_isClicked);

        if (_isClicked && _objectToMove != null)
        {
            Debug.Log($"Je dois déplacer {_objectToMove.name}");
            _objectToMove.transform.position = _worldPosition;
        }
        
        if(_isClicked && _objectToResize != null)
        {
            float radius = Vector2.Distance(_objectToResize.transform.position, _worldPosition);
            _objectToResize.Radius = Mathf.Clamp( radius, minRadius, maxRadius);
        }

        if (!_isClicked)
        {
            _objectToMove = null;
            _objectToResize = null;
        }
    }

    public void PointerMove(InputAction.CallbackContext context)
    {
        Vector2 pointerPosition = context.ReadValue<Vector2>();

        _ray = Camera.main.ScreenPointToRay(pointerPosition);

        RaycastHit2D hit = Physics2D.GetRayIntersection(_ray);

        _worldPosition = Camera.main.ScreenToWorldPoint(pointerPosition);
        _worldPosition.z = 0;

        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("CenterZone"))
            {
                Cursor.SetCursor(centerIcon, new Vector2(256, 256), CursorMode.Auto);

                _objectToMove = hit.collider.transform.parent.gameObject;
            }
            else if (hit.collider.CompareTag("OutterZone"))
            {
                Cursor.SetCursor(outterIcon, new Vector2(256, 256), CursorMode.Auto);
                _objectToResize = hit.collider.GetComponent<CircleShape>();
            }
        }
        else
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }
    }

    public void PointerPress(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Started:
                break;
            case InputActionPhase.Performed:
                _isClicked = true;
                break;
            case InputActionPhase.Canceled:
                _isClicked = false;
                break;
            default:
                break;
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawRay(_ray.origin, _ray.direction * 1000f);
    }
}
