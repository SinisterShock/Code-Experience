# Import the required libraries
from tkinter import *
from PIL import Image, ImageTk

# Create an instance of tkinter frame or window
win=Tk()

# Set the size of the window
win.geometry("1000x1000")

# Create a canvas widget
canvas=Canvas(win, width=1000, height=1000)
canvas.pack()

# Load the image
img=ImageTk.PhotoImage(file="new.png")

# Add the image in the canvas
canvas.create_image(350, 400, image=img, anchor="center")

win.mainloop()