from src.view.module4 import Module4


class Module4Controller:
    def __init__(self, model, view):
        self.model = model
        self.view = view

    def create_view(self):
        self.view.module4_view = Module4(self.view, self)
        self.view.module4_view.withdraw()

    def toggle(self):
        if self.view.module4_view.state() == 'normal':
            self.view.module4_view.withdraw()
        else:
            self.view.module4_view.deiconify()

    def destroy_view(self):
        self.view.module4_view.destroy()

    def close_view(self):
        self.view.module4_view.withdraw()
