using System;
using UnityEngine;

// Dispatched when the board's blocks change
public class BoardBlocksChangedEventArgs : EventArgs {

}

// Interface for the model
public interface IBoardModel {
    // Dispatched when the blocks change
    event EventHandler<BoardBlocksChangedEventArgs> OnBlocksChanged;

    // List of the board's blocks
    IBlockModel[,] Blocks { get; set; }
}

// Implementation of the board model interface
public class BoardModel : IBoardModel {
    // Backing list of the board's blocks
    private IBlockModel[,] blocks;

    public event EventHandler<BoardBlocksChangedEventArgs> OnBlocksChanged = (sender, e) => {};

    public IBlockModel[,] Blocks {
        get { return blocks; }
        set { 
            // Only if the blocks change
            if(blocks != value) {
                // Set the new blocks
                blocks = value;

                // Dispatch the "blocks changed" event
                var eventArgs = new BoardBlocksChangedEventArgs();
                OnBlocksChanged(this, eventArgs);
            }
        }
    }

    public const int Columns = 6, Rows = 6;

    public BoardModel() {
        blocks = new BlockModel[Columns, Rows];
    }
}