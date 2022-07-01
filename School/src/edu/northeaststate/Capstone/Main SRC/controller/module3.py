from src.view.module3 import Module3


class Module3Controller:
    def __init__(self, model, view):
        self.model = model
        self.view = view

    def create_view(self):
        self.view.module3_view = Module3(self.view, self)
        self.view.module3_view.withdraw()

    def toggle(self):
        if self.view.module3_view.state() == 'normal':
            self.view.module3_view.withdraw()
        else:
            self.view.module3_view.deiconify()

    def destroy_view(self):
        self.view.module3_view.destroy()

    def close_view(self):
        self.view.module3_view.withdraw()
