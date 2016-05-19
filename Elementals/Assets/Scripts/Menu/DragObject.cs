using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;


public class DragObject : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler {


	public float margin = 10;

	Transform targetParent = null;

	Transform selector = null;



	public void OnBeginDrag( PointerEventData data ){
		Debug.Log( "BeginDrag" );

		targetParent = transform.parent;

		transform.SetParent( GameObject.Find("Canvas").transform );

		selector = GameObject.Find("/Canvas/Selector").transform;
	}



	public void OnDrag( PointerEventData data ){

		transform.position = Input.mousePosition;


		List<RaycastResult> results = new List<RaycastResult>();

		EventSystem.current.RaycastAll( data, results );

		for ( int i=0; i < results.Count; i++ ){
			Debug.Log( "Droped Over: " + results[i].gameObject.name );

			if ( results[i].gameObject.tag == "GemSlot" ){

				selector.position = results[i].gameObject.transform.position;
			
				break;
			}
		}
	}



	public void OnEndDrag( PointerEventData data ){

		Debug.Log( "EndDrag" );
		transform.SetParent( targetParent );
	}



	public void OnDrop( PointerEventData data ){

		List<RaycastResult> results = new List<RaycastResult>();

		EventSystem.current.RaycastAll( data, results );

		for ( int i=0; i < results.Count; i++ ){
			Debug.Log( "Droped Over: " + results[i].gameObject.name );

			if ( results[i].gameObject.tag == "GemSlot" ){
				
				if (  results[i].gameObject.transform.childCount > 0 ){
					Transform currentInsertedObject = results[i].gameObject.transform.GetChild(0);
					currentInsertedObject.SetParent( targetParent );
				}
					

				targetParent = results[i].gameObject.transform;

				float height = results[i].gameObject.GetComponent<LayoutElement>().preferredHeight;
				float width= results[i].gameObject.GetComponent<LayoutElement>().preferredWidth;

				GetComponent<LayoutElement>().preferredHeight = height - margin;
				GetComponent<LayoutElement>().preferredWidth = width- margin;

				break;
			}
		}
	}
}
