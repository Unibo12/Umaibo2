using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 時間切れになると、自分自身を削除する
public class OnTimeout_DestroyMe : MonoBehaviour {

	public float limitSec = 3; // 秒数：Inspectorで指定

	void Start() { // 最初に行う
		Destroy(this.gameObject, limitSec); // 指定秒後に消滅する予約
	}
}
