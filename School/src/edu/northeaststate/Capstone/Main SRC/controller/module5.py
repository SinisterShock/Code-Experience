from src.view.module5 import Module5


class Module5Controller:
    def __init__(self, model, view):
        self.model = model
        self.view = view

    def create_view(self):
        self.view.module5_view = Module5(self.view, self)
        self.view.module5_view.withdraw()

    def toggle(self):
        if self.view.module5_view.state() == 'normal':
            self.view.module5_view.withdraw()
        else:
            self.view.module5_view.deiconify()

    def destroy_view(self):
        self.view.module5_view.destroy()

    def close_view(self):
        self.view.module5_view.withdraw()
