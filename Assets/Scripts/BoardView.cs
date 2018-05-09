using System;
using UnityEngine;

// Dispatched when the board is clicked
public class BoardClickedEventArgs : EventArgs {

}

// Interface for the board view
public interface IBoardView {
    // Dispatched when the board is clicked
    event EventHandler<BoardClickedEventArgs> OnClicked;
}

// Implementation of the board view
public class BoardView : MonoBehaviour, IBoardView {
    // Dispatched when the board is clicked
    public event EventHandler<BoardClickedEventArgs> OnClicked;

    void Awake() {
        
    }

    void Update() {
        // If the primary mouse button was pressed this frame
        if(Input.GetMouseButtonDown(0)) {
            // If the mouse hit a block
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if(hit.collider != null && hit.collider.gameObject.GetComponent<BlockView>()) {
                // Dispatch the block's "on clicked" event
                BlockView blockView = hit.collider.gameObject.GetComponent<BlockView>();
                blockView.DispatchClick();
            }
        }
    }
}