from enum import auto
import numbers
from ssl import Options
import tkinter as tk
from tkinter import E, NE, NSEW, NW, W, StringVar, ttk
from tkinter.messagebox import NO, showinfo
from turtle import back, bgcolor, width


class App(tk.Tk):
    def __init__(self):
        super().__init__()
        self.title('Kintronic Labs Tower App')
        ttk.Frame(self).grid(column=0, row=0, padx=5, pady=14)
        # self.createMenu()
        self.createTree()
        self.createFieldEntries()
        self.createSideButtons()
        self.createBottomMenu()
        self.createMiddleMenu()
        width = 665
        height = 475
        self.minsize(width, height)
        self.maxsize(width, height)

    def createMenu(self):
        # File Name Label
         ttk.Label(self, text='File Name:').grid(column=1, row=0, padx=5, pady=10, columnspan=2, sticky=E)
         name_entry = ttk.Entry(self).grid(column=3, row=0, columnspan=2, stick=W)

         ttk.Label(self, text='Number of Towers: ').grid(column=6, row=0, padx=5, pady=10, columnspan=2, sticky=E)
         numTowers = ttk.Label(self, text=0).grid(column=8, row=0, sticky=W)


    def createTree(self):
        # initialize TreeView
        columns = ('TwrNum', 'ratio', 'phase', 'spacingDeg',
                   'orientDeg', 'ref', 'heightDeg', 'topLoadDeg')
        tree = ttk.Treeview(self, columns=columns, show='headings')

        # define headings and column widths
        tree.heading('TwrNum', text='Tower #')
        tree.column('TwrNum', width=70, stretch=NO)
        tree.heading('ratio', text='Ratio')
        tree.column('ratio', width=40, stretch=NO)
        tree.heading('phase', text='Phase')
        tree.column('phase', width=50, stretch=NO)
        tree.heading('spacingDeg', text='Spacing Degrees')
        tree.column('spacingDeg', width=100, stretch=NO)
        tree.heading('orientDeg', text='Orientation Degrees')
        tree.column('orientDeg', width=120, stretch=NO)
        tree.heading('ref', text='Ref')
        tree.column('ref', width=35, stretch=NO)
        tree.heading('heightDeg', text='Height Degrees')
        tree.column('heightDeg', width=85, stretch=NO)
        tree.heading('topLoadDeg', text='Top Loading Degrees')
        tree.column('topLoadDeg', width=130, stretch=NO)

        # Place Tree in grid view
        tree.grid(row=1, column=1, sticky=NW, rowspan=8, columnspan=8)

        #scrollbar = ttk.Scrollbar(self, orient=tk.VERTICAL, command=tree.yview)
        #tree.configure(yscroll=scrollbar.set)
        #scrollbar.grid(row=1, column=9, sticky='NS', rowspan=8)

        # add dummy values
        for i in range(0, 4):
            tree.insert('', i, values=(i + 1, "0.520", "64.00", "0.00", "0.00", "0", "70.8", "0"))

    def createFieldEntries(self):
        twrNum = ttk.Entry(self, width=7).grid(column=1, row=9, sticky=NSEW, pady=3, padx=3)
        ratio = ttk.Entry(self, width=5).grid(column=2, row=9, sticky=NSEW, pady=3, padx=3)
        phase = ttk.Entry(self, width=5).grid(column=3, row=9, sticky=NSEW, pady=3, padx=3)
        spaDeg = ttk.Entry(self, width=12).grid(column=4, row=9, sticky=NSEW, pady=3, padx=3)
        oriDeg = ttk.Entry(self, width=15).grid(column=5, row=9, sticky=NSEW, pady=3, padx=3)
        ref = ttk.Checkbutton(self).grid(column=6, row=9, sticky=E, pady=3)
        heiDeg = ttk.Entry(self, width=10).grid(column=7, row=9, sticky=NSEW, pady=3, padx=3)
        topLoadDeg = ttk.Entry(self, width=17).grid(column=8, row=9, sticky=NSEW, pady=3, padx=3)
        botLoadDeg = ttk.Entry(self, width=17).grid(column=8, row=10, sticky=NSEW, pady=3, padx=3)


    def createSideButtons(self):

        add = ttk.Button(self, text="Add").grid(column=8, row=12, padx=5)
        rem = ttk.Button(self, text="Remove").grid(column=8, row=13, padx=5)
        cop = ttk.Button(self, text="Copy").grid(column=8, row=14, padx=5)
        ent = ttk.Button(self, text="Enter").grid(column=8, row=15, padx=5)

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

        dist = ttk.Entry(self, width=7).grid(column=5, row=11, sticky=W)
        rloss = ttk.Entry(self, width=7).grid(column=5, row=12, sticky=W)
        freq = ttk.Entry(self, width=7).grid(column=5, row=13, sticky=W)
        power = ttk.Entry(self, width=7).grid(column=5, row=14, sticky=W)

        ttk.Label(self, text="Physical Length").grid(column=6, row=11, columnspan=2)
        length = ttk.Entry(self, width=8).grid(column=6, row=12)

        options = ["ft", "m"]
        select = StringVar(self)
        select.set(options[0])
        distType = tk.OptionMenu(self, select, *options).grid(column=7, row=12, sticky=NSEW)

        scaleParam = ttk.Checkbutton(self).grid(column=6, row=13, rowspan=2)
        ttk.Label(self, text="Scale Parameters on").grid(column=7, row=13)
        ttk.Label(self, text="Frequency Change").grid(column=7, row=14)


class tower():
    def __init__(self, towerNum, ratio, phase, spaceDegrees, OrientDegreeds, ref, heightDegrees, topDegrees):
        self.towerNum = towerNum
        towerNum += 1
        self.ratio = 0.570
        self.phase = 199.00
        self.spaceDegrees = 0.00
        self.orientDegrees = 0.00
        self.ref = 0
        self.heightDegrees = 0
        self.topDegrees = 0

    def toString(self):
        print(self.towerNum)


if __name__ == "__main__":
    app = App()
    app.mainloop()