using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTargets : MonoBehaviour
{

    public GameObject playerOne;
    public GameObject playerTwo;
    public CinemachineTargetGroup group;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if (playerOne == null)
        {
            playerOne = GameObject.FindGameObjectWithTag("Player 1");
        }
        if (playerTwo == null)
        {
            playerTwo = GameObject.FindGameObjectWithTag("Player 2");
        }

        if (playerOne != null && playerTwo != null)
        {
            group = ;
            CinemachineTargetGroup.Target[] targets = group.m_Targets;
        }
    }
}
