using System;
using UnityEngine;

// Dispatched when the block is clicked
public class BlockClickedEventArgs : EventArgs {

}

// Interface for the block view
public interface IBlockView {
    // Dispatched when the block is clicked
    event EventHandler<BlockClickedEventArgs> OnClicked;

    // Set the block's position
    Vector2 Position { set; }
}

// Implementation of the block view
public class BlockView : MonoBehaviour, IBlockView {
    // Dispatched when the block is clicked
    public event EventHandler<BlockClickedEventArgs> OnClicked;

    public const float Width = 1.0f;
    public const float Height = 1.0f;

    // Set the block's position
    public Vector2 Position { 
        set { 
            transform.position = new Vector3(value.x - BoardModel.Columns / 2 + 0.5f * Width, 
                value.y - BoardModel.Rows / 2 + 0.5f * Height,
                -1f); 
        } 
    }

    public void DispatchClick() {
        var eventArgs = new BlockClickedEventArgs();
        OnClicked(this, eventArgs);
    }
}