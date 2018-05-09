using UnityEngine;

// Interface for the model factory
public interface IBlockModelFactory {
    // Get the created model
    IBlockModel CreateBlock();
}

// Implementation of the model factory
public class BlockModelFactory : IBlockModelFactory {
    public BlockModelFactory() {
    }

    // Create the model
    public IBlockModel CreateBlock() {
        return new BlockModel();
    }
}

// Interface for the view factory
public interface IBlockViewFactory {
    // Get the created view
    IBlockView CreateView(GameObject parentBoard);
}

// Implementation of the view factory
public class BlockViewFactory : IBlockViewFactory {
    public BlockViewFactory() {
    }

    // Create the view
    public IBlockView CreateView(GameObject parentBoard) {
        var prefab = Resources.Load<GameObject>("Prefabs/Block");
        var instance = UnityEngine.Object.Instantiate(prefab);
        instance.transform.parent = parentBoard.transform;
        return instance.GetComponent<BlockView>();
    }
}

// Interface of the controller factory
public interface IBlockControllerFactory {
    // Get the created controller
    IBlockController CreateController(IBlockModel model, IBlockView view);
}

// Implementation of the controller factory
public class BlockControllerFactory : IBlockControllerFactory {
    // Create just the controller
    public IBlockController CreateController(IBlockModel model, IBlockView view) {
        return new BlockController(model, view);
    }
}