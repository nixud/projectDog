using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CFurnituresRoot : MonoBehaviour
{
    public CBattleSystem battleSystem;

    public CFurniture[] furnitures;
    private int m_furnitureLeftNum;
    // Start is called before the first frame update
    void Start()
    {
        battleSystem = GameObject.Find(CSceneRoot.CSceneRootName).GetComponent<CSceneBattleRoot>().m_system as CBattleSystem;

        if (furnitures != null)
        {
            m_furnitureLeftNum = furnitures.Length;

            for (int i = 0; i < furnitures.Length; i++)
            {
                furnitures[i].furnituresRoot = this;
            }
        }
    }
}
