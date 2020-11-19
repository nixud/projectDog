using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSystemConfig
{
    public static float DogSpeed = 0.2f;//狗的速度
    public static float TurnDirectionSpeed = 3f;//转向速度
    public static float PredictLineLength = 6f;//预测线的长度
    public static float PrepareShootingTime = 0.4f;//蓄力增加一格需要的时间

    public static SDogInfos[] dogInfos =
        new SDogInfos[]{
            new SDogInfos("Dog1",0.5f,1,3),
        };
}

public struct SDogInfos
{
    public string DogName;
    public float DogSpeed;
    public int DogDamage;
    public int DogDamageTimes;

    public SDogInfos(string name,float speed,int damage,int times)
    {
        DogName = name;
        DogSpeed = speed;
        DogDamage = damage;
        DogDamageTimes = times;
    }
}
