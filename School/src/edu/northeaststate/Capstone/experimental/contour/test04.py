import matplotlib.pyplot as plt
import numpy as np

x = np.linspace(0, 5, 60)
y = np.linspace(0, 5, 48)


def fn(x, y):
    return np.sin(x) ** 5 + np.cos(y + 17) ** 8


X, Y = np.meshgrid(x, y)
Z = fn(X, Y)

plt.figure(figsize=(8, 6))
plt.title('Test 4 (Color With Lines)')
contours = plt.contour(X, Y, Z, 15, cmap='RdGy')
plt.clabel(contours, inline=True, fontsize=12)
plt.show()
