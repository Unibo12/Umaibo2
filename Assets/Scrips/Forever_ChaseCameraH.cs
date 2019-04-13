using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ずっと、カメラが追いかける（水平に）
public class Forever_ChaseCameraH : MonoBehaviour {

	Vector3 base_pos;

	void Start() { // 最初に行う
		// カメラの元の位置を覚えておく
		base_pos = Camera.main.gameObject.transform.position;
	}

	void LateUpdate() { // ずっと行う（いろいろな処理の最後に）
		Vector3 pos = this.transform.position; // 自分の位置
		pos.z = -10; // カメラなので手前に移動させる
		pos.y = base_pos.y; // カメラの元の高さを使う
		Camera.main.gameObject.transform.position = pos;
	}
}