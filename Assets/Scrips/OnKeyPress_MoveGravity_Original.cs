using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// キーを押すと、移動する（重力対応版）
public class OnKeyPress_MoveGravity_Original : MonoBehaviour {

	public float speed = 3; // スピード：Inspectorで指定
	public float jumppower = 8;  // ジャンプ力：Inspectorで指定

	float vx = 0;
	bool leftFlag = false; // 左向きかどうか
	bool pushFlag = false; // スペースキーを押しっぱなしかどうか
	bool jumpFlag = false; // ジャンプ状態かどうか
	bool groundFlag = false; // 足が何かに触れているかどうか
	Rigidbody2D rbody;

	void Start () { // 最初に行う
		// 衝突時に回転させない
		rbody = GetComponent<Rigidbody2D>();
		rbody.constraints = RigidbodyConstraints2D.FreezeRotation;
	}

	void Update () { // ずっと行う
		vx = 0;
		if (Input.GetKey("right")) { // もし、右キーが押されたら
			vx = speed; // 右に進む移動量を入れる
			leftFlag = false;
		}
		if (Input.GetKey("left")) { // もし、左キーが押されたら
			vx = -speed; // 左に進む移動量を入れる
			leftFlag = true;
		}
		// もし、スペースキーが押されたとき、足が何かに触れていたら
		if (Input.GetKey("space") && groundFlag) { 
			if (pushFlag == false) { // 押しっぱなしでなければ
				jumpFlag = true; // ジャンプの準備
				pushFlag = true; // 押しっぱなし状態
			}
		} else {
			pushFlag = false; // 押しっぱなし解除
		}
	}
	void FixedUpdate() { // ずっと行う（一定時間ごとに）
		// 移動する（重力をかけたまま）
		rbody.velocity = new Vector2(vx, rbody.velocity.y);
		// 左右に向きを変える
		this.GetComponent<SpriteRenderer>().flipX = leftFlag;
		// もし、ジャンプするとき
		if (jumpFlag) {
			jumpFlag = false;
			rbody.AddForce(new Vector2(0, jumppower), ForceMode2D.Impulse);
		}
	}
	void OnTriggerStay2D(Collider2D collision) { // 足が何かに触れたら
		groundFlag = true;
	}
	void OnTriggerExit2D(Collider2D collision) { // 足に何も触れなかったら
		groundFlag = false;
	}
}