using UnityEngine;
using UnityEngine.EventSystems;
using ContradictiveGames.Managers;


namespace ContradictiveGames.UI
{
    public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        private RectTransform element;

        private void Start(){
            element = GetComponent<RectTransform>();
        }

        public void OnBeginDrag(PointerEventData eventData){
            UIManager.Instance.OnDragMenu(true);
        }
        public void OnDrag(PointerEventData eventData){
            element.position = Input.mousePosition;
        }
        public void OnEndDrag(PointerEventData eventData){
            UIManager.Instance.OnDragMenu(false);
        }

    }
}