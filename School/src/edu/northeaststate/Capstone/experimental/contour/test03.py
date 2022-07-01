import matplotlib.pyplot as plt
import numpy as np

xp = np.arange(-3, 4)
yp = np.arange(-3, 4)
zp  =np.ndarray((7,7))
for x in range(0, len(xp)):
    for y in range(0, len(yp)):
        zp[x][y] = xp[x]*xp[x] - yp[y]*yp[y]

plt.figure(figsize=(8, 6))
plt.title('Test 3 (Hyperbolic paraboloid)')
contours = plt.contour(xp, yp, zp)
plt.clabel(contours, inline=1, fontsize=12)
plt.show()