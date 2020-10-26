using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Photon.Pun;
public class XRGrabNetworkInteractable : XRGrabInteractable
{
    private PhotonView photonView;

    void Start()
    {
        photonView = GetComponent<PhotonView>();
    }

    void Update()
    {
        
    }
    protected override void OnSelectEnter(XRBaseInteractor interactor)
    {
        photonView.RequestOwnership();
        base.OnSelectEnter(interactor);
    }

}
