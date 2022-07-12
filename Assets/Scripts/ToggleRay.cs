using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
/// Toggle the ray interactor
/// Should be placed on a ray interactor
/// </summary>
[RequireComponent(typeof(XRRayInteractor))]
public class ToggleRay : MonoBehaviour
{
    [Tooltip("The direct interactor that's switched to")]
    [SerializeField] private XRDirectInteractor directInteractor = null;

    private XRRayInteractor rayInteractor = null;

    private void Awake()
    {
        rayInteractor = GetComponent<XRRayInteractor>();
    }

    public void ActivateRay()
    {
        if (!TouchingObject())
        {
            SetRayInteractorEnabled(true);
        }
    }

    public void DeactivateRay()
    {
        SetRayInteractorEnabled(false);
    }

    private bool TouchingObject()
    {
        List<IXRInteractable> targets = new List<IXRInteractable>();
        directInteractor.GetValidTargets(targets);
        return (targets.Count > 0);
    }

    private void SetRayInteractorEnabled(bool value)
    {
        rayInteractor.enabled = value;
    }
}
