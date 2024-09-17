using UnityEngine;
using UnityEngine.EventSystems;
using ContradictiveGames.Managers;


namespace ContradictiveGames.UI
{
    public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {

        public void OnBeginDrag(PointerEventData eventData){
            UIManager.Instance.OnDragMenu(true);
        }
        public void OnDrag(PointerEventData eventData){
            transform.position = Input.mousePosition;
        }
        public void OnEndDrag(PointerEventData eventData){
            UIManager.Instance.OnDragMenu(false);
        }
    }
}