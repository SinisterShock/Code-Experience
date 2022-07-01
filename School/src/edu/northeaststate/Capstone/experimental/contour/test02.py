import matplotlib.pyplot as plt
import numpy as np

xp = np.arange(-8, 10, 2)
yp = np.arange(-8, 10, 2)
zp = np.ndarray((9,9))
zp

for x in range(0, len(xp)):
    for y in range(0, len(yp)):
        zp[x][y] = xp[x]**2 + yp[y]**2
zp

plt.figure(figsize=(7, 5))
plt.title('Test 2 (Circle)')
contours = plt.contour(xp, yp, zp)
plt.clabel(contours, inline=1, fontsize=12)
plt.show()