using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class GemSlot : MonoBehaviour, IPointerUpHandler {

	private Image image;

	void Start(){
		image = GetComponentInChildren<Image>();
	}

	public void OnPointerUp( PointerEventData eventData ){
		Debug.Log( eventData.selectedObject.name );
		image.sprite = eventData.selectedObject.GetComponentInChildren<Image>().sprite;
		//Debug.Log( image.sprite.name );
	}
}
