using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    InteractionController InteractionController { get; }

    float InteractionDistance { get; }
    float StoppingDistance { get; }
    Transform Body { get; }

}

public class InteractionController 
{
    private bool _isFocused;
    private bool _hasInteracted;
    private PlayerCreature _player;

    private IInteractable _thisInterectable;

    public InteractionController(IInteractable interactable)
    {
        _thisInterectable = interactable;
        ServiceManager.Instance.UpdateHandler += OnUpdate;
    }
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
    private void OnUpdate()
    {
        if (_isFocused && _player != null)
        {
            if (Vector3.Distance(_thisInterectable.Body.position, _player.transform.position) < _thisInterectable.InteractionDistance && !_hasInteracted)
            {
                Interact();
            }
        }
    }
    private void Interact()
    {
        _hasInteracted = true;
        Debug.Log("Interacted " + _thisInterectable.Body);
    }

    public void Destroy()
    {
        ServiceManager.Instance.UpdateHandler -= OnUpdate;
    }
}

public class NPCInteractionController : InteractionController
{ 
    public NPCInteractionController(IInteractable interactable) : base(interactable)
    {

    }
}
