using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private bool _isFocused;
    private bool _hasInteracted;
    private PlayerCreature _player;
    public virtual float StopingDistance { get { return _interactionDistance * 0.7f; } }

    [SerializeField] private float _interactionDistance;

    public void OnFocus(PlayerCreature player)
    {
        _isFocused = true;
        _player = player;
    }

    public void OnUnFocus()
    {
        _isFocused = false;
        _hasInteracted = false;
    }
    private void Update()
    {
        if (_isFocused && _player != null)
        {
            Vector3 centrePoint = new Vector3(transform.position.x, _player.transform.position.y, transform.position.z);
            if (Vector3.Distance(centrePoint, _player.transform.position) < _interactionDistance && !_hasInteracted)
            {
                Interact();
            }
        }
    }
    private void Interact()
    {
        _hasInteracted = true;
        Debug.Log("Interacted " + gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _interactionDistance / 2);
    }
}
