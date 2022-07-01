from tkinter import messagebox
from tkinter import filedialog as fd
from Mod3Dev.model.file import File
from Mod3Dev.view.module3 import Module3



class WorkspaceController:
    def __init__(self, model, view):
        self.model = model
        self.view = view

    def toggle_module1(self):
        if self.view.module3view.state() == 'normal':
            self.view.module3view.withdraw()
        else:
            self.view.module3view.deiconify()

    def new_file(self):
        # TODO check to see if existing model
        if self.model:
            # TODO ask to save then save or not
            self.view.module3view.destroy()
            self.model = None
        # creates menu bar for view tab
        self.view.menubar.entryconfig("View", state="normal")
        # adds option to save
        self.view.file_menu.entryconfig("Save", state='normal')
        # adds option to save as
        self.view.file_menu.entryconfig("Save as", state='normal')
        # when saving as, adds default name and file extension
        self.view.title(self.view.kintronic + ' - new.ktl')
        # shows Mod3 view
        self.view.module3view = Module3(self.view, self.model)
        self.view.module3view.state(newstate='normal')

        self.model = File(None)

        self.update_frame()

    def save_file(self):
        if self.model.filename:
            self.model.save()
        else:
            # File types and extension
            files = [('Kintronic Labs File', '*.ktl')]
            filename = fd.asksaveasfile(filetypes=files, defaultextension=files)
            if filename:
                self.model.filename = filename.name
                self.model.save()

    def save_as_file(self):
        # File types and extension
        files = [('Kintronic Labs File', '*.ktl')]
        filename = fd.asksaveasfile(filetypes=files, defaultextension=files)
        if filename:
            self.model.filename = filename.name
            self.model.save()

    def open_file(self):
        # TODO check to see if existing model
        if self.model:
            # TODO ask to save existing file then save or not
            self.view.Module3.destroy()
            self.model = None

        filename = fd.askopenfilename()

        if filename:
            self.model = File(filename)
            self.model.open()
            # creates menu bar for view tab
            self.view.menubar.entryconfig("View", state="normal")
            # adds option to save
            self.view.file_menu.entryconfig("Save", state='normal')
            # adds option to save as
            self.view.file_menu.entryconfig("Save as", state='normal')
            # when saving as, adds default name and file extension
            self.view.title(self.view.kintronic + ' - new.ktl')
            # shows Mod3 view
            self.view.module3view = Module3(self.view, self.model)
            self.view.module3view.state(newstate='normal')
            self.update_frame()

    def update_frame(self):
        # Converts output to json
        self.view.frame.my_string_var.set(self.model.toJSON())

    def show_about(self):
        # displays message when selecting about
        messagebox.showinfo('Radio', 'Send Transmission')
