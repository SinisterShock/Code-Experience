import matplotlib.pyplot as plt
import numpy as np

x = np.linspace(0, 5, 60)
y = np.linspace(0, 5, 48)


def fn(x, y):
    return np.sin(x) ** 5 + np.cos(y + 17) ** 8


X, Y = np.meshgrid(x, y)
Z = fn(X, Y)

plt.figure(figsize=(14, 10))
plt.title('Test 1 (Color)')
plt.contourf(X, Y, Z, 20, cmap='RdGy')
plt.colorbar()
plt.show()
