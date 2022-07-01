import tkinter as tk
from tkinter import Menu
from tkinter import ttk


class WorkspaceFrame(ttk.Frame):
    def __init__(self, parent, controller):
        super().__init__(parent)

        self.controller = controller

        # create a StringVar class
        self.my_string_var = tk.StringVar()

        self.test_label = ttk.Label(self, textvariable=self.my_string_var)
        self.test_label.grid(row=1, column=0)


class Workspace(tk.Tk):
    def __init__(self, controller):
        super().__init__()

        # set the controller
        self.controller = controller

        self.kintronic = 'Kintronic Labs'

        self.title(self.kintronic)
        self.geometry("800x400")

        self.menubar = Menu(self, background='#ff8000', foreground='black', activebackground='white',
                            activeforeground='black')
        self.file_menu = Menu(self.menubar, tearoff=0)
        self.file_menu.add_command(label="New", command=self.new_file)
        self.file_menu.add_command(label="Open", command=self.open_file)
        self.file_menu.add_command(label="Save", command=self.save_file, state='disabled')
        self.file_menu.add_command(label="Save as", command=self.save_as_file, state='disabled')
        self.file_menu.add_separator()
        self.file_menu.add_command(label="Exit", command=self.quit)
        self.menubar.add_cascade(label="File", menu=self.file_menu)

        self.view_menu = Menu(self.menubar, tearoff=0)
        self.view_menu.add_command(label="Tower Input", command=self.toggle_module1_clicked)
        self.view_menu.add_command(label="Module2", command=self.toggle_module2_clicked)
        self.view_menu.add_command(label="Module3", command=self.toggle_module3_clicked)
        self.view_menu.add_command(label="Module4", command=self.toggle_module4_clicked)
        self.view_menu.add_command(label="Module5", command=self.toggle_module5_clicked)
        self.menubar.add_cascade(label="View", menu=self.view_menu)
        self.menubar.entryconfig("View", state="disabled")

        self.help_menu = Menu(self.menubar, tearoff=0)
        self.help_menu.add_command(label="About", command=self.show_about)
        self.menubar.add_cascade(label="Help", menu=self.help_menu)

        self.config(menu=self.menubar)

        # create a view and place it on the root window and give it its controller
        self.frame = WorkspaceFrame(self, self.controller)
        self.frame.grid(row=0, column=0, padx=10, pady=10)

    def toggle_module1_clicked(self):
        if self.controller:
            self.controller.toggle_module1()

    def toggle_module2_clicked(self):
        if self.controller:
            self.controller.toggle_module2()

    def toggle_module3_clicked(self):
        if self.controller:
            self.controller.toggle_module3()

    def toggle_module4_clicked(self):
        if self.controller:
            self.controller.toggle_module4()

    def toggle_module5_clicked(self):
        if self.controller:
            self.controller.toggle_module5()

    def show_about(self):
        if self.controller:
            self.controller.show_about()

    def new_file(self):
        if self.controller:
            self.controller.new_file()

    def save_file(self):
        if self.controller:
            self.controller.save_file()

    def save_as_file(self):
        if self.controller:
            self.controller.save_as_file()

    def open_file(self):
        if self.controller:
            self.controller.open_file()
