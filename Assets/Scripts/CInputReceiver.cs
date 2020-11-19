using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CInputReceiver : MonoBehaviour
{
    private List<Vector3> m_directionVectors;

    public CSceneRoot m_sceneRoot;
    public CDogController m_dogController;

    public bool[] m_ShootKeyHasDown = new bool[CPlayerSettings.PlayerNumberMax];

    private void Start()
    {
        m_sceneRoot = GameObject.Find(CSceneRoot.CSceneRootName).GetComponent<CSceneRoot>();

        m_dogController = new CDogController(m_sceneRoot);
    }

    private void Update()
    {
        for (int i = 0; i < CPlayerSettings.PlayerNumber; i++)
        {
            SControlPad controlPad = CPlayerSettings.controlPads[i];

            Vector3 vector = GetDirInputs(controlPad);

            m_dogController.FreshDogDirection(vector, Time.deltaTime, i);

            if (GetShootKeyDown(controlPad))
            {
                m_ShootKeyHasDown[i] = true;
            }
            if (GetShootKeyUp(controlPad))
            {
                m_ShootKeyHasDown[i] = false;
                m_dogController.ShootDog(i);
            }
        }
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < CPlayerSettings.PlayerNumber; i++)
        {
            SControlPad controlPad = CPlayerSettings.controlPads[i];

            if (m_ShootKeyHasDown[i] == true)
            {
                m_dogController.PrepareShootDog(Time.fixedDeltaTime,i);
            }
        }
    }

    private Vector3 GetDirInputs(SControlPad controlPad)
    {
        Vector3 vector = Vector3.zero;

        if (Input.GetKey(controlPad.up))
        {
            vector += Vector3.forward;
        }
        else if (Input.GetKey(controlPad.down))
        {
            vector += Vector3.back;
        }

        if (Input.GetKey(controlPad.left))
        {
            vector += Vector3.left;
        }
        else if (Input.GetKey(controlPad.right))
        {
            vector += Vector3.right;
        }

        return vector.normalized;
    }

    private bool GetShootKeyDown(SControlPad controlPad)
    {
        if (Input.GetKeyDown(controlPad.attack))
        {
            return true;
        }
        return false;
    }
    private bool GetShootKeyUp(SControlPad controlPad)
    {
        if (Input.GetKeyUp(controlPad.attack))
        {
            return true;
        }
        return false;
    }
}
