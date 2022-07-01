import tkinter as tk
from tkinter import E, NE, NSEW, NW, W, StringVar, ttk, messagebox
from tkinter.messagebox import NO, showinfo


class Module3Frame(ttk.Frame):
    def __init__(self, parent, controller):
        super().__init__(parent)

        # set the controller
        self.controller = controller


class Module3(tk.Toplevel):
    def __init__(self, parent, controller):
        super().__init__(parent)

        self.wm_protocol('WM_DELETE_WINDOW', self.withdraw)

        self.title('Module 3')
        self.geometry("665x475")

        # create a view and place it on the root window
        self.frame = Module3Frame(self, controller)
        self.frame.grid(row=0, column=0, padx=10, pady=10)
