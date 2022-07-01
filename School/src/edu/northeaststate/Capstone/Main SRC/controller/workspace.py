from tkinter import messagebox
from tkinter import filedialog as fd

from src.controller.module1 import Module1Controller
from src.controller.module2 import Module2Controller
from src.controller.module3 import Module3Controller
from src.controller.module4 import Module4Controller
from src.controller.module5 import Module5Controller
from src.view.workspace import Workspace


class WorkspaceController:
    def __init__(self, model):
        self.model = model
        self.view = Workspace(self)

        self.module1_controller = None
        self.module2_controller = None
        self.module3_controller = None
        self.module4_controller = None
        self.module5_controller = None

    def create_child_views(self):
        # create controllers
        self.module1_controller = Module1Controller(self.model, self.view)
        self.module1_controller.create_view()

        self.module2_controller = Module2Controller(self.model, self.view)
        self.module2_controller.create_view()

        self.module3_controller = Module3Controller(self.model, self.view)
        self.module3_controller.create_view()

        self.module4_controller = Module4Controller(self.model, self.view)
        self.module4_controller.create_view()

        self.module5_controller = Module5Controller(self.model, self.view)
        self.module5_controller.create_view()

    def destroy_child_views(self):
        self.module1_controller.destroy_view()
        self.module2_controller.destroy_view()
        self.module3_controller.destroy_view()
        self.module4_controller.destroy_view()
        self.module5_controller.destroy_view()

    def start_workspace_view(self):
        self.view.mainloop()

    def toggle_module1(self):
        self.module1_controller.toggle()

    def toggle_module2(self):
        self.module2_controller.toggle()

    def toggle_module3(self):
        self.module3_controller.toggle()

    def toggle_module4(self):
        self.module4_controller.toggle()

    def toggle_module5(self):
        self.module5_controller.toggle()

    def new_file(self):
        # TODO check to see if existing model
        if not self.model.is_empty:
            # TODO ask to save then save or not
            self.destroy_child_views()
            self.model.empty()



        self.view.menubar.entryconfig("View", state="normal")
        self.view.file_menu.entryconfig("Save", state='normal')
        self.view.file_menu.entryconfig("Save as", state='normal')
        self.view.title(self.view.kintronic + ' - new.ktl')

        self.create_child_views()
        self.model.filename = None
        self.update_frame()

    def save_file(self):
        if self.model.filename:
            self.model.save()
        else:
            files = [('Kintronic Labs File', '*.ktl')]
            filename = fd.asksaveasfile(filetypes=files, defaultextension=files)
            if filename:
                self.model.filename = filename.name
                self.model.save()

    def save_as_file(self):
        files = [('Kintronic Labs File', '*.ktl')]
        filename = fd.asksaveasfile(filetypes=files, defaultextension=files)
        if filename:
            self.model.filename = filename.name
            self.model.save()

    def open_file(self):
        # TODO check to see if existing model
        if not self.model.is_empty:
            # TODO ask to save existing file then save or not
            self.destroy_child_views()
            self.model.empty()

        filename = fd.askopenfilename()

        if filename:
            self.model.filename = filename
            self.model.open()

            self.view.menubar.entryconfig("View", state="normal")
            self.view.file_menu.entryconfig("Save", state='normal')
            self.view.file_menu.entryconfig("Save as", state='normal')
            self.view.title(self.view.kintronic + ' - ' + filename)
            self.create_child_views()
            self.update_frame()

    def update_frame(self):
        # self.view.frame.my_string_var.set(self.model.toJSON())
        pass

    def show_about(self):
        messagebox.showinfo('Radio', 'Send Transmission')
