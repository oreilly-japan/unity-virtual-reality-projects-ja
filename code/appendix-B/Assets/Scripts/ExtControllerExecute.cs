using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class ExtControllerExecute : MonoBehaviour {
	public GameObject cursorObject;
	public float cursorDistance = 0.5f;
	public GameObject controlObject;
	private GameObject currentButton;
	private Clicker clicker = new Clicker ();

	enum Tools {
		Pointer = 0, // ポインターを示す値
		Hose,        // 散水ホースを示す値
		Num          // ツールの種類数を示す値
	};
	private Tools currentTool = Tools.Pointer; // ツール選択の初期状態はポインターを設定
	private Vector2 prevTouchPos; // 前回タッチした位置を保持する

	// Use this for initialization
	void Start () {
		cursorObject.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		if (GvrController.AppButtonDown) {
			ChangeTool (); // コントローラーのAPPボタンが押されたらツールを切り替える
		}

		switch (currentTool) { // 現在のツールの選択状態で必要な処理を呼び分ける
		case Tools.Pointer: 
			ControlPointer (); // ポインターの処理
			break;
		case Tools.Hose:
			ControlHose ();    // 散水ホースの処理
			break;
		}
	}

	Tools ChangeTool() {
		// 呼び出される度に選択中のツールを切り替える
		currentTool++; // ツールの選択状態の値を加算して次のツールの値にする
		if (currentTool >= Tools.Num) {
			// ツールの種類数以上になったらポインターを示す値に戻す
			currentTool = Tools.Pointer;
		}
		return currentTool;
	}

	void ControlPointer() {
		if (GvrController.TouchUp) {
			// Daydream コントローラーのタッチパッドから指が離れた時カーソルを非表示にする
			cursorObject.SetActive (false);
		} else if (GvrController.TouchDown) {
			// Daydream コントローラーのタッチパッドにタッチした時カーソルを表示する
			cursorObject.SetActive (true);
		}
		if (cursorObject.activeSelf) { // カーソルが表示状態の時
			Transform camera = Camera.main.transform;
			// Daydream コントローラーの向き
			Vector3 rayDir = GvrController.Orientation * Vector3.forward; // Daydream
			// カメラ位置を起点としたコントローラーの向きのRay
			Ray ray = new Ray (camera.position, rayDir); // Daydream

			// カーソルをRayの一定距離の位置に設定
			cursorObject.transform.position = ray.GetPoint (cursorDistance);
			cursorObject.transform.LookAt (camera.position);

			RaycastHit hit;
			GameObject hitButton = null;
			PointerEventData data = new PointerEventData (EventSystem.current);
			if (Physics.Raycast (ray, out hit)) {
				if (hit.transform.gameObject.tag == "Button") {
					hitButton = hit.transform.parent.gameObject;
				}
			}
			if (currentButton != hitButton) {
				if (currentButton != null) { // ハイライトを外す
					ExecuteEvents.Execute<IPointerExitHandler> (currentButton, data, ExecuteEvents.pointerExitHandler);
				}
				currentButton = hitButton;
				if (currentButton != null) { // ハイライトする
					ExecuteEvents.Execute<IPointerEnterHandler> (currentButton, data, ExecuteEvents.pointerEnterHandler);
				}
			}
			if (currentButton != null) {
				if (clicker.clicked ()) {
					ExecuteEvents.Execute<IPointerClickHandler> (currentButton, data, ExecuteEvents.pointerClickHandler);
				}
			}
		}
	}

	void ControlHose() {
		// 散水ホースの回転にコントローラーの方向をセット
		controlObject.transform.rotation = GvrController.Orientation;
		if (GvrController.TouchDown) { // タッチされた瞬間のみtrueになる
			// コントローラーのタッチパネルにタッチした時の位置を保存する
			prevTouchPos = GvrController.TouchPos;
		}
		if (GvrController.IsTouching) { // タッチされている時は常にtrueになる
			// タッチされたままの状態なら散水ホースの位置を動かす
			// 前回のタッチ位置との差分
			Vector2 touchPosDelta = GvrController.TouchPos - prevTouchPos;
			// 現在の散水ホースの位置を取得
			Vector3 position = controlObject.transform.position;
			// 散水ホースの位置を設定
			position.x += touchPosDelta.x; // X座標をタッチ位置のX座標の値で設定
			position.z -= touchPosDelta.y; // Z座標をタッチ位置のY座標の値で設定
			controlObject.transform.position = position;
			prevTouchPos = GvrController.TouchPos; // 現在のタッチ位置を前回の位置として設定
		}
	}
}
