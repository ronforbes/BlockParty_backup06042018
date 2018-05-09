using UnityEngine;

public class GameplayScene : MonoBehaviour {
    void Awake() {
        // Create the board model
        var boardModelFactory = new BoardModelFactory();
        var boardModel = boardModelFactory.Model;

        // Create the board view
        var boardViewFactory = new BoardViewFactory();
        var boardView = boardViewFactory.View;

        // Create the board controller
        var boardControllerFactory = new BoardControllerFactory(boardModel, boardView);
        var boardController = boardControllerFactory.Controller;

        // Create the block models, views and controllers
        var blockModelFactory = new BlockModelFactory();
        var blockViewFactory = new BlockViewFactory();
        var blockControllerFactory = new BlockControllerFactory();

        for(int x = 0; x < BoardModel.Columns; x++) {
            for(int y = 0; y < BoardModel.Rows; y++) {
                var blockModel = blockModelFactory.CreateBlock();
                blockModel.Position = new Vector2(x, y);
                boardModel.Blocks[x, y] = blockModel;
                var blockView = blockViewFactory.CreateView((boardView as BoardView).gameObject);
                var blockController = blockControllerFactory.CreateController(blockModel, blockView);
            }
        }
    }

    void Update() {
        // Update camera size to adjust to resolution changes
        if(Screen.width < Screen.height) {
            int delta = Screen.height - Screen.width;
            Camera.main.orthographicSize = 3.6f + 3.6f * delta / 220;
        }
        else {
            Camera.main.orthographicSize = 3.6f;
        }
    }
}