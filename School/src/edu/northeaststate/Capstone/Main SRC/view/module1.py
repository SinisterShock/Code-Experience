import tkinter as tk
from tkinter import E, NE, NSEW, NW, W, StringVar, ttk, messagebox
from tkinter.messagebox import NO, showinfo


def about():
    messagebox.showinfo('Radio', 'Send Transmission')


class Module1Frame(ttk.Frame):
    def __init__(self, parent, controller):
        super().__init__(parent)

        # set the controller
        self.controller = controller

        self.tree_columns = None
        self.tree = None

        self.create_tree()
        self.createFieldEntries()
        self.createSideButtons()
        self.createBottomMenu()
        self.createMiddleMenu()

    def create_tree(self):
        # initialize TreeView
        self.tree_columns = ('TwrNum', 'ratio', 'phase', 'spacingDeg',
                             'orientDeg', 'ref', 'heightDeg', 'topLoadDeg')
        self.tree = ttk.Treeview(self, columns=self.tree_columns, show='headings')

        # define headings and column widths
        self.tree.heading('TwrNum', text='Tower #')
        self.tree.column('TwrNum', width=70, stretch=NO)
        self.tree.heading('ratio', text='Ratio')
        self.tree.column('ratio', width=40, stretch=NO)
        self.tree.heading('phase', text='Phase')
        self.tree.column('phase', width=50, stretch=NO)
        self.tree.heading('spacingDeg', text='Spacing Degrees')
        self.tree.column('spacingDeg', width=100, stretch=NO)
        self.tree.heading('orientDeg', text='Orientation Degrees')
        self.tree.column('orientDeg', width=120, stretch=NO)
        self.tree.heading('ref', text='Ref')
        self.tree.column('ref', width=35, stretch=NO)
        self.tree.heading('heightDeg', text='Height Degrees')
        self.tree.column('heightDeg', width=85, stretch=NO)
        self.tree.heading('topLoadDeg', text='Top Loading Degrees')
        self.tree.column('topLoadDeg', width=130, stretch=NO)
        self.tree.bind('<Double-1>', self.tree_item_double_clicked)

        # Place Tree in grid view
        self.tree.grid(row=1, column=1, sticky=NW, rowspan=8, columnspan=8)

        # Scrollbar for the towers list
        scrollbar = ttk.Scrollbar(self, orient=tk.VERTICAL, command=self.tree.yview)
        self.tree.configure(yscroll=scrollbar.set)
        scrollbar.grid(row=1, column=9, sticky='NS', rowspan=8)

    def createFieldEntries(self):
        # twrNum = ttk.Entry(self, width=7)
        # twrNum.grid(column=1, row=9, sticky=NSEW, pady=3, padx=3)

        ratio = ttk.Entry(self, width=5)
        ratio.grid(column=2, row=9, sticky=NSEW, pady=3, padx=3)

        phase = ttk.Entry(self, width=5)
        phase.grid(column=3, row=9, sticky=NSEW, pady=3, padx=3)

        spaDeg = ttk.Entry(self, width=12)
        spaDeg.grid(column=4, row=9, sticky=NSEW, pady=3, padx=3)

        oriDeg = ttk.Entry(self, width=15)
        oriDeg.grid(column=5, row=9, sticky=NSEW, pady=3, padx=3)

        ref = ttk.Checkbutton(self)
        ref.grid(column=6, row=9, sticky=E, pady=3)

        heiDeg = ttk.Entry(self, width=10)
        heiDeg.grid(column=7, row=9, sticky=NSEW, pady=3, padx=3)

        topLoadDeg = ttk.Entry(self, width=17)
        topLoadDeg.grid(column=8, row=9, sticky=NSEW, pady=3, padx=3)

        botLoadDeg = ttk.Entry(self, width=17)
        botLoadDeg.grid(column=8, row=10, sticky=NSEW, pady=3, padx=3)


    def createSideButtons(self):
        add = ttk.Button(self, text="Add", command=self.add_button_clicked)
        add.grid(column=8, row=12, padx=5)

        rem = ttk.Button(self, text="Remove")
        rem.grid(column=8, row=13, padx=5)

        cop = ttk.Button(self, text="Copy")
        cop.grid(column=8, row=14, padx=5)

        ent = ttk.Button(self, text="Close", command=self.close_button_clicked)
        ent.grid(column=8, row=17, padx=5)

    def createBottomMenu(self):
        ttk.Label(self, text="RMS-Theo. mV/m: ").grid(column=1, row=11, columnspan=2, sticky=E)
        ttk.Label(self, text="RSS-Theo. (mV/m): ").grid(column=1, row=12, columnspan=2, sticky=E)
        ttk.Label(self, text="RSS/RMS: ").grid(column=1, row=13, columnspan=2, sticky=E)
        ttk.Label(self, text="RMS-Stf(mV/m): ").grid(column=1, row=14, columnspan=2, sticky=E)
        ttk.Label(self, text="Q: ").grid(column=1, row=15, columnspan=2, sticky=E)
        ttk.Label(self, text="K Constant (mV/m): ").grid(column=1, row=16, columnspan=2, sticky=E)

        # placeholder numbers
        for i in range(11, 17):
            ttk.Label(self, text=0).grid(column=3, row=i, sticky=W)

        ttk.Label(self, text="Max. Field (mV/m): ").grid(column=3, row=15, columnspan=2, sticky=E)
        ttk.Label(self, text=0).grid(column=5, row=15, sticky=W)

        ttk.Label(self, text="Max. Gain (dBi): ").grid(column=3, row=16, columnspan=2, sticky=E)
        ttk.Label(self, text=0).grid(column=5, row=16, sticky=W)

    def createMiddleMenu(self):
        ttk.Label(self, text="Distance (km): ").grid(column=4, row=11, sticky=E)
        ttk.Label(self, text="RLoss (Ohms): ").grid(column=4, row=12, sticky=E)
        ttk.Label(self, text="Freq. (KHz): ").grid(column=4, row=13, sticky=E)
        ttk.Label(self, text="Power (KW): ").grid(column=4, row=14, sticky=E)

        dist = ttk.Entry(self, width=7)
        dist.grid(column=5, row=11, sticky=W)
        rloss = ttk.Entry(self, width=7)
        rloss.grid(column=5, row=12, sticky=W)
        freq = ttk.Entry(self, width=7)
        freq.grid(column=5, row=13, sticky=W)
        power = ttk.Entry(self, width=7)
        power.grid(column=5, row=14, sticky=W)

        ttk.Label(self, text="Physical Length").grid(column=6, row=11, columnspan=2)

        length = ttk.Entry(self, width=8)
        length.grid(column=6, row=12)

        options = ["ft", "m"]
        select = StringVar(self)
        select.set(options[0])
        distType = tk.OptionMenu(self, select, *options)
        distType.grid(column=7, row=12, sticky=NSEW)

        scaleParam = ttk.Checkbutton(self)
        scaleParam.grid(column=6, row=13, rowspan=2)
        ttk.Label(self, text="Scale Parameters on").grid(column=7, row=13)
        ttk.Label(self, text="Frequency Change").grid(column=7, row=14)

    def set_controller(self, controller):
        self.controller = controller

    def close_button_clicked(self):
        self.controller.close_view()

    def add_button_clicked(self):
        self.controller.add_tower()

    def tree_item_double_clicked(self, event):
        self.controller.tree_item_double_clicked(event)


    #
    # def show_error(self, message):
    #     self.message_label['text'] = message
    #     self.message_label['foreground'] = 'red'
    #     self.message_label.after(3000, self.hide_message)
    #     self.email_entry['foreground'] = 'red'
    #
    # def show_success(self, message):
    #     self.message_label['text'] = message
    #     self.message_label['foreground'] = 'green'
    #     self.message_label.after(3000, self.hide_message)
    #
    #     # reset the form
    #     self.email_entry['foreground'] = 'black'
    #     self.email_var.set('')
    #
    # def hide_message(self):
    #     self.message_label['text'] = ''


class Module1(tk.Toplevel):
    def __init__(self, parent, controller):
        super().__init__(parent)

        self.wm_protocol('WM_DELETE_WINDOW', self.withdraw)

        self.title('Tower Input')
        self.geometry("665x475")

        # create a view and place it on the root window
        self.frame = Module1Frame(self, controller)
        self.frame.grid(row=0, column=0, padx=10, pady=10)
