using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
/// Save the ball position when it is thrown
/// </summary>
public class Ball : XRGrabInteractable
{
    private Vector3 m_ThrowPosition;
    private bool m_DroppedBall = false;

    public Vector3 ThrowPosition
    {
        get { return m_ThrowPosition; }
    }

    protected override void OnHoverEntered(HoverEnterEventArgs args)
    {
        base.OnHoverEntered(args);
        m_ThrowPosition = args.interactorObject.transform.position;
    }

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        base.ProcessInteractable(updatePhase);
        if (isSelected && !m_DroppedBall)
        {
            // Set the throw position to the controller position as long as the selected ball is not dropped
            m_ThrowPosition = firstInteractorSelecting.transform.position;
        }
    }

    protected override void OnSelectExiting(SelectExitEventArgs args)
    {
        base.OnSelectExiting(args);
        m_DroppedBall = true;
        m_ThrowPosition = transform.position;
    }
}
