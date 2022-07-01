from operator import ne
import tkinter as tk
from turtle import onclick

from pyparsing import col

twrNum = str(0)
print (twrNum)

root = tk.Tk()
tk.Label(root, text="Edit Tower").grid(columnspan=2, column=0, row=0)

tk.Label(root, text="TwrNum").grid(row=1, column=1)
tk.Label(root, text="0").grid(row=1, column=2)

tk.Label(root, text="ratio").grid(row=1, column=2)
ratEnt = tk.Entry(root, width=5)
ratEnt.grid(row=2,column=2)

tk.Label(root, text="phase").grid(row=1, column=3)
phaEnt = tk.Entry(root, width=5)
phaEnt.grid(row=2,column=3)

tk.Label(root, text="spacingDeg").grid(row=1, column=4)
spaEnt = tk.Entry(root, width=5)
spaEnt.grid(row=2,column=4)

tk.Label(root, text="orientDeg").grid(row=1, column=5)
oriEnt = tk.Entry(root, width=5)
oriEnt.grid(row=2,column=5)

tk.Label(root, text="ref").grid(row=1, column=6)
refEnt = tk.Entry(root, width=5)
refEnt.grid(row=2,column=6)

tk.Label(root, text="heightDeg").grid(row=1, column=7)
heiEnt = tk.Entry(root, width=5)
heiEnt.grid(row=2,column=7)

tk.Label(root, text="topLoadDeg").grid(row=1, column=5)
topEnt = tk.Entry(root, width=5)
topEnt.grid(row=2,column=5)

enter = tk.Button(root, text="Enter")
enter.grid(row=3, column=6)

exit = tk.Button(root, text="Cancel", command=root.destroy)
exit.grid(row=3, column=7)

root.mainloop()