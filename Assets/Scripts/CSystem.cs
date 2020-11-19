using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CSystem
{
    public CSceneRoot sceneRoot;

    public CSystem(CSceneRoot cSceneRoot)
    {
        sceneRoot = cSceneRoot;
        Debug.Log("A System have been inited");
    }
}
