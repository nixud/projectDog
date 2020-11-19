using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSceneRoot : MonoBehaviour
{
    public static string CSceneRootName = "SceneRoot";

    public CSystem m_system;

    public GameObject[] m_SceneMembers;

    private void Start()
    {
        if (m_system == null)
        {
            Debug.LogError("缺失CSystem！");
        }
    }

    public GameObject GetSceneMember(int member)
    {
        //检查数组是否越界
        if (member >= m_SceneMembers.Length || member < 0)
        {
            return null;
        }

        return m_SceneMembers[member];
    }
}

public enum SceneBattleMembers
{
    Player1,
    Player1ForceNum,
    Player2,
    Player2ForceNum,
    Player3,
    Player3ForceNum,
    Player4,
    Player4ForceNum,
}