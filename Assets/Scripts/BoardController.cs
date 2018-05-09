// Interface for the board controller
public interface IBoardController {

}

// Implementation of the board controller
public class BoardController : IBoardController {
    // Keep references to the model and view
    private readonly IBoardModel model;
    private readonly IBoardView view;

    // Controller depends on interfaces for the model and view
    public BoardController(IBoardModel model, IBoardView view) {
        this.model = model;
        this.view = view;

        // Listen to input from the view
        view.OnClicked += HandleClicked;

        // Listen to changes in the model
        model.OnBlocksChanged += HandleBlocksChanged;

        // Set the view's initial state by syncing with the model
        SyncBlocks();
    }

    // Called when the view is clicked
    private void HandleClicked(object sender, BoardClickedEventArgs e) {
        
    }

    // Called when the model's blocks change
    private void HandleBlocksChanged(object sender, BoardBlocksChangedEventArgs e) {
        // Update the view with the updated blocks
        SyncBlocks();
    }

    private void SyncBlocks() {
        
    }
}