// Interface for the block controller
public interface IBlockController {

}

// Implementation of the block controller
public class BlockController : IBlockController {
    // Keep references to the model and view
    private readonly IBlockModel model;
    private readonly IBlockView view;

    // Controller depends on interfaces for the model and view
    public BlockController(IBlockModel model, IBlockView view) {
        this.model = model;
        this.view = view;

        // Listen to input from the view
        view.OnClicked += HandleClicked;

        // Listen to changes in the model
        model.OnPositionChanged += HandlePositionChanged;

        // Set the view's initial state by syncing with the model
        SyncPosition();
    }

    // Called when the view is clicked
    private void HandleClicked(object sender, BlockClickedEventArgs e) {
        
    }

    // Called when the model's position changes
    private void HandlePositionChanged(object sender, BlockPositionChangedEventArgs e) {
        // Update the view with the new position
        SyncPosition();
    }

    private void SyncPosition() {
        view.Position = model.Position;
    }
}