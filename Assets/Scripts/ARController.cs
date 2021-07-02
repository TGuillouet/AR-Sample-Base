using System.Collections;
using System.Collections.Generic;
using EventSystem;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARController : MonoBehaviour
{
    [SerializeField] ARSession m_Session;

    IEnumerator Start() {
        if ((ARSession.state == ARSessionState.None) ||
            (ARSession.state == ARSessionState.CheckingAvailability))
        {
            yield return ARSession.CheckAvailability();
        }

        if (ARSession.state == ARSessionState.Unsupported)
        {
            // Start some fallback experience for unsupported devices
            GameManager.current.DispatchEvent(new UIUpdateTextEvent("status_text", "AR not initialized"));
        }
        else
        {
            // Start the AR session
            m_Session.enabled = true;
            GameManager.current.DispatchEvent(new UIUpdateTextEvent("status_text", "AR initialized"));
        }
    }
}
