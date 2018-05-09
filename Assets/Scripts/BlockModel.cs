using System;
using UnityEngine;

// Dispatched when the block's position changes
public class BlockPositionChangedEventArgs : EventArgs {

}

// Interface for the model
public interface IBlockModel {
    // Dispatched when the position changes
    event EventHandler<BlockPositionChangedEventArgs> OnPositionChanged;

    // Position of the block
    Vector2 Position { get; set; }
}

// Implementation of the block model interface
public class BlockModel : IBlockModel {
    // Backing position of the block
    private Vector2 position;

    public event EventHandler<BlockPositionChangedEventArgs> OnPositionChanged = (sender, e) => {};

    public Vector2 Position {
        get { return position; }
        set { 
            // Only if the position changes
            if(position != value) {
                // Set the new position
                position = value;

                // Dispatch the "position changed" event
                var eventArgs = new BlockPositionChangedEventArgs();
                OnPositionChanged(this, eventArgs);
            }
        }
    }
}