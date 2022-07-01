from src.view.module2 import Module2


class Module2Controller:
    def __init__(self, model, view):
        self.model = model
        self.view = view

    def create_view(self):
        self.view.module2_view = Module2(self.view, self)
        self.view.module2_view.withdraw()

    def toggle(self):
        if self.view.module2_view.state() == 'normal':
            self.view.module2_view.withdraw()
        else:
            self.view.module2_view.deiconify()

    def destroy_view(self):
        self.view.module2_view.destroy()

    def close_view(self):
        self.view.module2_view.withdraw()
