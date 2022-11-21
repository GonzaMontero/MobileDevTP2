using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(Cinemachine.CinemachineVirtualCamera))]
public class AssignPlayerToCamera : MonoBehaviour
{
    public CinemachineVirtualCamera cam;

    void Start()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Main Player");
        cam.Follow = go.transform;
    }
}
