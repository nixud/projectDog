using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CFurniture : MonoBehaviour
{
    [HideInInspector]
    public CFurnituresRoot furnituresRoot;

    public int HP = 1;
    public int score = 1;

    private void OnCollisionEnter(Collision collision)
    {
        HP--;
        if (HP <= 0)
        {
            
        }
    }
}
