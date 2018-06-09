using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public Image image1;

	public Image image2;

	public Image image3;

	public GameObject roundMask;

	public GameObject cavase;

	GameObject mask1 ;
	GameObject mask2 ;
	GameObject mask3 ;

	public ParticleSystem p1;
	public ParticleSystem p2;
	public ParticleSystem p3;

	private float speed = 0.8f;

	public GameObject bg;


	private bool isRotate = false;
	private bool isShake = false;

	private int count = 0;

	private float countTimer = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetMouseButtonDown(0)){
			image1.transform.localScale = new Vector3 (0,0,0);
			image2.transform.localScale = new Vector3 (0,0,0);
			image3.transform.localScale = new Vector3 (0,0,0);

//			image1.DOFade (1,0.1f);
//			image2.DOFade (1,0.1f);
//			image3.DOFade (1,0.1f);
//			image1.transform.DOScale (new Vector3(1f, 1f, 1f), 0.1f);

			StartCoroutine (ShowImage1(image1, 0.1f));
			StartCoroutine (ShowImage1(image2, 0.2f));
			StartCoroutine (ShowImage1(image3, 0.3f));
			Invoke ("ScaleImage2", 0.6f);

			Debug.Log ("点击鼠标");
			
		}

		if(isShake){
			countTimer += Time.deltaTime;
			Shake ();

		}
		if(isRotate){
			image1.transform.parent.Rotate (new Vector3(0 , 0, 360 * 2)* Time.deltaTime);
			image2.transform.parent.Rotate (new Vector3(0 , 0, 360 * 2) * Time.deltaTime);
			image3.transform.parent.Rotate (new Vector3(0 , 0, 360 * 2) * Time.deltaTime);

		}


		
	}

	void ScaleImage2(){
		image2.transform.DOScale (new Vector3 (0f, 0f, 0f), 0.1f).OnComplete(()=>{

			mask1 = GameObject.Instantiate(roundMask, image1.transform.position, Quaternion.identity);
			mask2 = GameObject.Instantiate(roundMask, image2.transform.position, Quaternion.identity);
			mask3 = GameObject.Instantiate(roundMask, image3.transform.position, Quaternion.identity);
			mask1.transform.parent = cavase.transform;
			mask2.transform.parent = cavase.transform;
			mask3.transform.parent = cavase.transform;
			mask1.transform.localScale = new Vector3(1,1,1);
			mask2.transform.localScale = new Vector3(1,1,1);
			mask3.transform.localScale = new Vector3(1,1,1);
			isShake = true;
			Invoke("ChangeColor3", 0.02f);


			Debug.Log("出黑色抖动");
		});
	}

	void Shake(){
		count++;
		switch (count % 5) {

			case 0:
//			bg.transform.localPosition += new Vector3 (10, 10, 0) * speed * ((0.2f-countTimer)/0.2f);
			bg.transform.localPosition += new Vector3 (0, 10, 0) * speed * ((0.2f-countTimer)/0.2f);

				break;
		case 1:
//			bg.transform.localPosition += new Vector3 (-20, -20, 0) * speed * ((0.2f-countTimer)/0.2f);
			bg.transform.localPosition += new Vector3 (0, -20, 0) * speed * ((0.2f-countTimer)/0.2f);

			break;
		case 2:
//			bg.transform.localPosition += new Vector3 (20, 0, 0) * speed * ((0.2f-countTimer)/0.2f);
			bg.transform.localPosition += new Vector3 (0, 20, 0) * speed * ((0.2f-countTimer)/0.2f);

			break;
		case 3:
//			bg.transform.localPosition += new Vector3 (-20, 20, 0) * speed * ((0.2f-countTimer)/0.2f);
			bg.transform.localPosition += new Vector3 (0, -20, 0) * speed * ((0.2f-countTimer)/0.2f);

			break;
		case 4:
//			bg.transform.localPosition += new Vector3 (10, -10, 0) * speed * ((0.2f-countTimer)/0.2f);
			bg.transform.localPosition += new Vector3 (0, 10, 0) * speed * ((0.2f-countTimer)/0.2f);

			break;
		default:
			break;

		}

	}

	void ChangeColor3(){
		p1.Play ();
		p2.Play ();
		p3.Play ();
		image1.gameObject.SetActive (false);
		image2.gameObject.SetActive (false);
		image3.gameObject.SetActive (false);

		isRotate = true;
		mask1.GetComponent<Image> ().color = Color.white;
		mask2.GetComponent<Image> ().color = Color.white;
		mask3.GetComponent<Image> ().color = Color.white;


		Invoke ("HideMask", 0.1f);


	}

	void HideMask(){
		isShake = false;
		count = 0;
		bg.transform.localPosition = new Vector3(0, 0, 0);
		countTimer = 0;

		DOTween.To (()=>mask1.GetComponent<_2dxFX_CircleFade>()._Offset, x=>mask1.GetComponent<_2dxFX_CircleFade>()._Offset = x, 0.5f, 0.5f);

		DOTween.To (()=>mask2.GetComponent<_2dxFX_CircleFade>()._Offset, x=>mask2.GetComponent<_2dxFX_CircleFade>()._Offset = x, 0.5f, 0.5f);
		DOTween.To (()=>mask3.GetComponent<_2dxFX_CircleFade>()._Offset, x=>mask3.GetComponent<_2dxFX_CircleFade>()._Offset = x, 0.5f, 0.5f).OnComplete(()=>{
		});
		Invoke ("ScaleSmaller4", 0.5f);

	}

	void ScaleSmaller4(){
		
		image1.transform.parent.GetComponent<Image> ().color = HexToColor ("eec05fff");
		image2.transform.parent.GetComponent<Image> ().color = HexToColor ("11a06fff");

		image1.transform.parent.DOScale (Vector3.zero, 0.3f);
		image2.transform.parent.DOScale (Vector3.zero, 0.3f);
		image3.transform.parent.DOScale (Vector3.zero, 0.3f).OnComplete(()=>{
			isRotate = false;
//			image1.transform.parent.rotation = Quaternion.identity;
//			image2.transform.parent.rotation = Quaternion.identity;
//			image3.transform.parent.rotation = Quaternion.identity;
			image1.transform.parent.DOScale (new Vector3(1f, 1f, 1f), 0.3f);
			image2.transform.parent.DOScale (new Vector3(1f, 1f, 1f), 0.3f);
			image3.transform.parent.DOScale (new Vector3(1f, 1f, 1f), 0.3f);
			image1.transform.parent.DORotate(new Vector3(0, 0, 720), 0.4f).SetEase(Ease.OutBack);
			image2.transform.parent.DORotate(new Vector3(0, 0, 720), 0.3f).SetEase(Ease.OutBack);
			image3.transform.parent.DORotate(new Vector3(0, 0, 720), 0.2f).SetEase(Ease.OutBack);

		});


	}

	IEnumerator ShowImage1(Image image, float delayTime){
		yield return new WaitForSeconds(delayTime);

		image.DOFade (1,0.1f);
//		image.transform.DOScale (new Vector3(1f, 1f, 1f), 0.3f).SetEase(Ease.OutBack);
		image.transform.DOScale (new Vector3 (1.2f, 1.2f, 1.2f), 0.2f).OnComplete (()=>{
			image.transform.DOScale(new Vector3 (1f, 1f, 1f), 0.1f).SetEase(Ease.OutBack);
		});
	
	}

	/// <summary>
	/// hex转换到color
	/// </summary>
	/// <param name="hex"></param>
	/// <returns></returns>
	public Color HexToColor(string hex)
	{
		byte br = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
		byte bg = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
		byte bb = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
		byte cc = byte.Parse(hex.Substring(6, 2), System.Globalization.NumberStyles.HexNumber);
		float r = br / 255f;
		float g = bg / 255f;
		float b = bb / 255f;
		float a = cc / 255f;
		return new Color(r, g, b, a);
	}



}
