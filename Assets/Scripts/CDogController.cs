using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CDogController
{
    private CSceneRoot m_SceneRoot;

    private GameObject[] m_Dog = new GameObject[CPlayerSettings.PlayerNumberMax];
    private Vector3[] m_ShootDirection = new Vector3[CPlayerSettings.PlayerNumberMax];

    private DogStatus[] m_dogStatus = new DogStatus[CPlayerSettings.PlayerNumberMax];

    private bool m_isShooting;
    private float m_ShootingDistance;

    private static float LineWidth = 0.3f;

    private int m_PowerLevel = 1;
    private float m_PreparingTimeMark = 0;//用于记录按了多长时间的

    public CDogController(CSceneRoot root)
    {
        m_SceneRoot = root;

        m_Dog[0] = m_SceneRoot.GetSceneMember((int)SceneBattleMembers.Player1);
        m_Dog[1] = m_SceneRoot.GetSceneMember((int)SceneBattleMembers.Player2);
        m_Dog[2] = m_SceneRoot.GetSceneMember((int)SceneBattleMembers.Player3);
        m_Dog[3] = m_SceneRoot.GetSceneMember((int)SceneBattleMembers.Player4);

        m_Dog[0].GetComponent<CDogObjectScript>().m_dogController = this;
        m_Dog[1].GetComponent<CDogObjectScript>().m_dogController = this;
        m_Dog[2].GetComponent<CDogObjectScript>().m_dogController = this;
        m_Dog[3].GetComponent<CDogObjectScript>().m_dogController = this;

        m_Dog[0].GetComponent<CDogObjectScript>().DogNum = 0;
        m_Dog[1].GetComponent<CDogObjectScript>().DogNum = 1;
        m_Dog[2].GetComponent<CDogObjectScript>().DogNum = 2;
        m_Dog[3].GetComponent<CDogObjectScript>().DogNum = 3;

        for (int i = CPlayerSettings.PlayerNumber; i < CPlayerSettings.PlayerNumberMax; i++)
        {
            m_Dog[i].SetActive(false);
        }
    }

    public void FreshDogDirection(Vector3 dir, float deltaTime, int dogNum)
    {
        if (m_dogStatus[dogNum] == DogStatus.Standing)
        {
            m_ShootDirection[dogNum] = (m_ShootDirection[dogNum] + dir * CSystemConfig.TurnDirectionSpeed * deltaTime).normalized;
            CalculatePredictLine(dogNum);
        }
    }
    
    private void CalculatePredictLine(int dogNum)
    {
        RaycastHit hit;
        Ray ray = new Ray(m_Dog[dogNum].transform.position + m_ShootDirection[dogNum] * m_Dog[dogNum].transform.localScale.x / 2, m_ShootDirection[dogNum]);

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 incomingVec = m_ShootDirection[dogNum];

            Vector3 reflectVec = Vector3.Reflect(incomingVec, hit.normal);

            Vector3[] points = { m_Dog[dogNum].transform.position,
                hit.point, hit.point + reflectVec * 2};

            RenderPredictLine(points,dogNum);
        }
        else
        {
            Vector3[] points = { m_Dog[dogNum].transform.position,
                m_Dog[dogNum].transform.position + m_ShootDirection[dogNum] * CSystemConfig.PredictLineLength};
            RenderPredictLine(points,dogNum);
        }
    }

    private void RenderPredictLine(Vector3[] points, int dogNum)
    {
        LineRenderer lineRenderer = m_Dog[dogNum].GetComponent<LineRenderer>();
        lineRenderer.positionCount = points.Length;
        lineRenderer.SetPositions(points);
        lineRenderer.startWidth = LineWidth;
        lineRenderer.endWidth = LineWidth;
    }

    public void PrepareShootDog(float pressTime, int dogNum)
    {
        if (m_dogStatus[dogNum] == DogStatus.Standing)
        {
            m_dogStatus[dogNum] = DogStatus.PreparingShoot;
        }

        if (m_dogStatus[dogNum] == DogStatus.PreparingShoot)
        {
            m_PreparingTimeMark += pressTime;

            if (m_PreparingTimeMark >= CSystemConfig.PrepareShootingTime)//按压射击键时间超过一定值
            {
                m_PreparingTimeMark = 0;//归零
                m_PowerLevel++;
                if (m_PowerLevel >= 6)//暂时
                {
                    m_PowerLevel = 1;
                }
                DisplayPowerLevel();
            }
        }
    }

    public void DisplayPowerLevel()
    {
        //暂时获取这个
        GameObject targetText = m_SceneRoot.GetSceneMember((int)SceneBattleMembers.Player1ForceNum);
        targetText.GetComponent<Text>().text = m_PowerLevel.ToString();
    }

    public void ShootDog(int dogNum)
    {
        m_dogStatus[dogNum] = DogStatus.Flying;

        m_Dog[dogNum].GetComponent<CDogObjectScript>().StartMove(m_ShootDirection[dogNum], 5f,3);

        RenderPredictLine(new Vector3[] { },dogNum);
    }

    public void ShootingEnded(int dogNum)
    {
        m_dogStatus[dogNum] = DogStatus.Standing;
    }
}

public enum DogStatus
{
    Standing,
    PreparingShoot,
    Flying,
    Dizzing,
}
