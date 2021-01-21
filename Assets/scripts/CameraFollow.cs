using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{


	private Vector3 offset;   //偏移量
	private float py;  //相机高度
	public Transform hero;  //需要跟随的玩家
	public float damping = 1;

	void Awake()
	{
		offset = transform.position - hero.position;  //保持偏移量
	}

	void Update()
	{
		py = hero.eulerAngles.y;
		Quaternion rotation = Quaternion.Euler(0, py, 0);
		transform.position = Vector3.Lerp(transform.position, hero.position + (rotation * offset), Time.deltaTime * damping);
		transform.LookAt(hero.position);    //看向玩家的方向
	}

}
