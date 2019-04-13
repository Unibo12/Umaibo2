using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 上キーを押すと、プレハブを作って投げる
public class OnUpKeyPress_Throw : MonoBehaviour {

	public GameObject newPrefab; // 作るプレハブ：Inspectorで指定
	public int maxCount = 20; // 頻度：Inspectorで指定

	public float throwX = 4;  // 投げる力：Inspectorで指定
	public float throwY = 8;  // 投げる力：Inspectorで指定
	public float offsetY = 1;

	bool pushFlag = false;
	bool leftFlag = false;

	void Update() {
		if (Input.GetKey("right") || Input.GetAxis("Horizontal") > 0) { // もし、右キーが押されたら
			leftFlag = false;
		}
		if (Input.GetKey("left") || Input.GetAxis("Horizontal") < 0) { // もし、左キーが押されたら
			leftFlag = true;
		}
        if (Input.GetKey("a") || Input.GetKey("joystick button 3")) { // もし、キーボードのa or xbox360のXボタンが押されたら
			if (pushFlag == false) { // 押しっぱなしでなければ
				pushFlag = true;
				Vector3 area = this.GetComponent<SpriteRenderer>().bounds.size;
				Vector3 newPos = this.transform.position;
				newPos.y += offsetY;
				// プレハブを作る
				GameObject newGameObject = Instantiate(newPrefab) as GameObject;
				newPos.z = -5; // 手前に表示する
				newGameObject.transform.position = newPos;

				Rigidbody2D rbody = newGameObject.GetComponent<Rigidbody2D>();
				if (leftFlag) { // 左向きなら逆方向に投げる
					rbody.AddForce(new Vector2(-throwX, throwY), ForceMode2D.Impulse);
				}
				else { // 右向きなら右向きに投げる
					rbody.AddForce(new Vector2(throwX, throwY), ForceMode2D.Impulse);
				}				
			}
		} else {
			pushFlag = false;
		}
	}
}
