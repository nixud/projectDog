using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSceneBattleRoot : CSceneRoot
{
    private CInputReceiver m_inputReceiver;

    private void Start()
    {
        m_system = new CBattleSystem(this);
        m_inputReceiver = gameObject.AddComponent<CInputReceiver>();
    }
}
