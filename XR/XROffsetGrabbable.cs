using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
/// Copyright (c) 2022 by Richard Muthwill. Update and repost this script as you wish but leave this line as is.
/// 
/// This script will keep the object in place when grabbing. This gives the illusion of actually
/// grabbing an object instead of it flying into the middle of the rigidbody or attach point.
/// 
/// If you are using something other than XRGrabInteractable or a script that derives from
/// it, please change all the XRGrabInteractable to YourXRGrabInteractableDerivedClass
/// 
/// Original idea / answer from Unity Forums: https://forum.unity.com/threads/xr-rig-grab-from-touchpoint-not-rigidbody-center.879037/
/// 
/// Copy of original file: https://github.com/richardmuthwill/Unity-Snippets/blob/main/XR/XROffsetGrabbableObsolete.cs
/// </summary>

[DisallowMultipleComponent]
[RequireComponent(typeof(XRGrabInteractable))]
public class XROffsetGrabbable : MonoBehaviour
{
	XRGrabInteractable grabInteractable;
	Transform attachPoint;

	void Awake()
	{
		grabInteractable = GetComponent<XRGrabInteractable>();

		if (grabInteractable.attachTransform == null)
		{
			GameObject newGO = new GameObject("Attach Transform of " + name);
			Transform newTransform = newGO.transform;
			newTransform.parent = transform;

			grabInteractable.attachTransform = newTransform;
			attachPoint = newTransform;
		}
    else
		{
			attachPoint = grabInteractable.attachTransform;
		}
	}

	void OnEnable()
	{
		grabInteractable.selectEntered.AddListener(XRSelectEnter);
	}

	void OnDisable()
	{
		grabInteractable.selectEntered.RemoveListener(XRSelectEnter);
	}

	public void XRSelectEnter(SelectEnterEventArgs selectEnterEventArgs)
	{
		attachPoint.position = selectEnterEventArgs.interactorObject.transform.position;
		attachPoint.rotation = selectEnterEventArgs.interactorObject.transform.rotation;
	}
}
