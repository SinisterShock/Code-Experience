# References: https://www.programiz.com/python-programming/file-operation
# https://youtu.be/Y5EMGBo39Kk
# https://www.youtube.com/watch?v=2Tw39kZIbhs

# Import pickle package
import pickle

# Opens a file to read and prints it to the console
file1 = open("Example.txt", encoding='utf-8')
print(file1.read())
# Close the file after viewing
file1.close()

# If you want to read the file at a specific place, use seek and enter the number of characters you want to jump
# ahead then use readline
file1 = open("Example.txt", encoding='utf-8')
file1.seek(6)
# Readline reads one line at the given byte index entered in "seek"
print(file1.readline())
# Close the file
file1.close()

# Re-open the file to add new lines at certain places in the file.
file1 = open("Example.txt", encoding='utf-8')
# Creates each line as a list. Readlines reads all lines instead of Readline reading a single line
newLines = file1.readlines()
# Stores the answer as a variable (Not yet changing the file its self)
newLines[1] = "Lima\n"
newLines[3] = "Yuri Gagarin\n"
print(newLines)
file1.close()

# Re-open the file in writing mode. This will overwrite the file, but we have the contents stored in the variable
# newLines
file1 = open("Example.txt", mode='w', encoding='utf-8')
# Re-write your lines
file1.writelines(newLines)
# Close the file
file1.close()

# Reopen the file if you would like to view your changes
file1 = open("Example.txt", encoding='utf-8')
print(file1.read())
file1.close()

# Reopen the file in "append" mode to make changes at the end of the file without overwriting the entire file. Use (
# w) to overwrite existing file
file1 = open("Example.txt", mode='a', encoding='utf-8')
file1.write("\nNow we can add to the end of the file")
# Close the file after making changes
file1.close()

# Reopen the file in "view" mode to view all the changes made to the file
file1 = open("Example.txt", encoding='utf-8')
print(file1.read())
file1.close()

# Use Pickle to pickle out the variable into a pickle file (wb write bytes)
pickling_out = open("newLines.pickle", "wb")
pickle.dump(newLines, pickling_out)
pickling_out.close()

# To show that the pickle process worked, we are now pickling in the file we created (rb read bytes), printing the
# variable new lines, and using a key value from the variable to show the information pickle_in = open(
# "newLines.pickle", "rb") exampleNewLines = pickle.load(pickle_in) print(newLines) print(exampleNewLines[1])
