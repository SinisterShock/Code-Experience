# TODO: documentation
from src.controller.workspace import WorkspaceController
from src.model.model import Model

if __name__ == '__main__':
    print("environment created")
    # create a model to be shared by all controllers
    model = Model(None)

    # create a workspace controller and give it the model
    workspace_controller = WorkspaceController(model)
    workspace_controller.start_workspace_view()
    exit()
