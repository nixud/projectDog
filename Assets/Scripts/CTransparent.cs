/*using UnityEngine;
using System.Collections;

public class CTransparent : MonoBehaviour
{

	//得到主人公
	private GameObject hero;
	//记录上次的对象
	private GameObject last_obj;

	void Start()
	{
		hero = GameObject.Find("Dog");
	
	}
	void Update()
	{
		RaycastHit hit;

		if (Physics.Linecast(hero.transform.position, Camera.main.transform.position, out hit))
		{
			last_obj = hit.collider.gameObject;
			string name_tag = last_obj.tag;

			//判断
			if (name_tag != "MainCamera" && name_tag != "terrain")
			{
				//让遮挡物变半透明
				Color obj_color = last_obj.GetComponent<Renderer>().material.color;
				//last_obj.GetComponent<Renderer>().material.
				//obj_color.a = 0.1f;
				//last_obj.GetComponent<Renderer>().material.SetColor("_Color",obj_color);
				
			}
		}
		else if (last_obj != null)
		{
			Color obj_color = last_obj.GetComponent<Renderer>().material.color;
				obj_color.a = 1.0f;
				last_obj.GetComponent<Renderer>().material.SetColor("_Color",obj_color);
				last_obj = null;
		}

	}

}*/