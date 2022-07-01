import cmath
import math
from cefpython3 import cefpython as cef
import platform
import sys
import plotly.graph_objects as go

from CalculateK import CalculateK
from CalcTheoretical import CalcTheoretical

"""
    Note via Mackenly: This was Spring 2022 module two (theoretical calculation)'s final test driver.
    Because we were unsure of the 100% accuracy of the theoretical calculation, there are two approaches.
    
    In the future it would be valuable to get the results of what each of the calculations would be given a certain 
    set of parameters for testing/output validation. That way we could compare the results of the calculations.
    
    One is based on the C++ code sent by the client and the other is based on research and experimentation from Tyler. 
    They result in different numbers. Notice that both outputs are being shifted to result in lower numbers.
    
    Also since this was just a test driver the tower list is hardcoded below into tower list 1, 2, and 3. 
    Both are based on screenshots that the client has sent of their current program.
    
    Unless it's a dependency of this file we're not currently using it.
"""

def main():
    """The main method is the point of execution for this program
       Data from the CalcTheoretical, and CalculateK classes along with many other variables that are declared in the main
       method are parsed by for loops to set properties of the plotly.graph_objects and display the data in a plotly graph
    """
    towerlist2 = [
        {
            'num': 1,
            'ratio': 1,
            'phase': 0,
            'spacing': 0.00,
            'orientation': 0,
            'ref': 0,
            'height': 80,
            'topload': 0
        },
        {
            'num': 2,
            'ratio': 0.580,
            'phase': 134,
            'spacing': 80.00,
            'orientation': 40,
            'ref': 0,
            'height': 80,
            'topload': 0
        },
        {
            'num': 3,
            'ratio': 0.380,
            'phase': 3,
            'spacing': 159.39,
            'orientation': 55,
            'ref': 0,
            'height': 80,
            'topload': 0
        }
    ]
    towerlist1 = [
        {
            'num': 1,
            'ratio': .52,
            'phase': 64,
            'spacing': 0.00,
            'orientation': 0,
            'ref': 0,
            'height': 70.8,
            'topload': 0
        },
        {
            'num': 2,
            'ratio': 1,
            'phase': 0,
            'spacing': 75,
            'orientation': 60,
            'ref': 0,
            'height': 141.6,
            'topload': 0
        },
        {
            'num': 3,
            'ratio': 1.4,
            'phase': 242,
            'spacing': 150.00,
            'orientation': 60,
            'ref': 0,
            'height': 70.8,
            'topload': 0
        }
    ]
    towerlist3 = [
        {
            'num': 1,
            'ratio': 1,
            'phase': 0,
            'spacing': 0.00,
            'orientation': 0,
            'ref': 0,
            'height': 120,
            'topload': 0
        }
    ]

    datatoplot = []
    datatoplotexpanded = []
    power = 10
    rms = 1022.9

    """Here down is K calculation"""
    k = None
    klossless = 0.0
    part = 0.0
    rms_hem = 0.0
    efficiency = 0.0
    ploss = 0.0
    rloss = 1
    topload = 0
    phasefill = 0.1

    # rloss
    c1 = 152.15158 * 1.609344
    part = rms
    rms_hem = part * part / 2
    for i in range(len(towerlist1)):
        # part = rms_theta(el.value[i])
        if towerlist1[i]['phase'] == 0:
            rms_hem = rms_hem + part * part * math.cos(math.pi / 180. * phasefill)
        else:
            rms_hem = rms_hem + part * part * math.cos(math.pi / 180. * towerlist1[i]['phase'])

    rms_hem = math.sqrt(towerlist1[i]['phase'] * math.pi / 180 * rms_hem)
    if rms_hem < .1:
        rms_hem = .1
    klossless = c1 * math.sqrt(power) / rms_hem

    # LOSSY K
    c2 = 37.256479 * 1.609344
    for j in range(len(towerlist1)):
        a = (math.cos(math.pi / 180. * topload) - math.cos(math.pi / 180. * (towerlist1[i]['height'] + topload)))
        if a == 0:
            a = 0.1
        part = klossless * towerlist1[i]['ratio'] / c2 / a
        if towerlist1[i]['height'] < 90:
            part = part * math.sin(math.pi / 180. * (towerlist1[i]['height'] + topload))

        ploss = ploss + part * part

    ploss = rloss * ploss
    efficiency = power * 1000. / (power * 1000. + ploss)
    k = klossless * math.sqrt(efficiency)
    """Here up is K calculation"""

    """ Here down is theoretical calculation"""
    vc = towerlist1
    theodata = [['y', 'x']]
    theoangle = towerlist1
    if theodata is not None:
        theodata.clear()

    for j in range(360):
        pattern = 0

        for i in range(len(towerlist1)):
            arg = math.atan2(0, 2 * math.pi * towerlist1[i]['spacing'] / 360 * math.cos(
                towerlist1[i]['height'] * math.pi / 180) *
                             math.cos(math.pi / 180 * (j - towerlist1[
                                 i]['orientation'])) + math.pi / 180 * towerlist1[i]['phase'])
            vert = 1
            a1 = vert * towerlist1[i]['ratio']
            pattern = pattern + cmath.exp(arg) * a1

        # theoangle[j]['pat'] = cmath.atan(pattern[1])

        datatoplot.append((k * pattern).real / 120)

    #for c in datatoplot:
    #    datatoplotexpanded.append(c + 0.005)

    """Here up is theoretical calculation"""

    # Test the oo K calculation
    ktest = CalculateK()
    ook = ktest.getk(power, towerlist1)

    # theo test
    calcTheo = CalcTheoretical()
    datatest = calcTheo.calculate_theo(ook, towerlist1)

    # print data
    print("Inline Calc Results:")
    print(k)
    print(datatoplot)
    print("\nTheoretical Objects Calc Results:")
    print(ook)
    print(datatest)

    # This allows you to use the inline (Tyler) version or the oo C++ translation version
    # "y" results in the oo version, else it uses the inline version
    if input("Use object oriented version? (y/n)") == "y":
        datatoplot = datatest

    # A circle for the plot
    datacircle = []
    for i in range(366):
        datacircle.append(i)

    # Create lists for plotting
    rlist = []
    thetalist = []
    labeltextlist = []
    for i in range(len(towerlist1)):
        rlist.append(towerlist1[i]['spacing'] / 1000)
        thetalist.append(towerlist1[i]['orientation'])
        labeltextlist.append(str(towerlist1[i]['num']))

    # Parameterized Constructor for creating a figure
    fig = go.Figure(data=
    go.Scatterpolar(  # Using this to add the points that represent the towers
        r=rlist,  # distance from the center
        theta=thetalist,  # orientation from 0 degrees
        name='Tower',
        mode='markers+text',
        marker=dict(
            symbol='5',  # Doc of symbols: https://rreusser.github.io/plotly-mock-viewer/#marker_symbols
            size=16,
            color='grey',
            line=dict(
                color='darkred',
                width=2
            )
        ),
        text=labeltextlist,
        hoverlabel=dict(
            bgcolor='white',
            bordercolor='red',
            font=dict(
                size=14,
                color='black'
            )
        ),
        hovertemplate='Tower: %{text}<br>Distance: %{r:.2f} km<br>Angle: %{theta:.2f} degrees',
        textposition='top left'
    ))

    # The next four add_trace are what adds the lines
    fig.add_trace(go.Scatterpolar(
        r=datatoplot,
        theta=datacircle,
        mode='lines',
        name='Wave Pattern',
        line_color='deepskyblue',
        #fill='toself'
    ))

    # Format the output
    fig.update_layout(
        title='Theoretical Wave Pattern',
        showlegend=False,
        polar=dict(
            radialaxis=dict(
                range=[0, 1],
                showticklabels=False,
                ticks=''
            ),
            angularaxis=dict(
                direction='clockwise'
            )
        )
    )

    # Here uncomment fig.show() to see the plot in a browser
    # fig.show()

    """Here down is what opens it into TK window"""
    fig.write_html("map.html")

    check_versions()
    sys.excepthook = cef.ExceptHook  # To shutdown all CEF processes on error
    cef.Initialize()
    cef.CreateBrowserSync(url="file:///map.html",
                          window_title="Kintronic Labs")
    cef.MessageLoop()
    cef.Shutdown()
    """Here up is what opens it into TK window"""


def check_versions():
    """
    Required method to display the tk window
    """
    ver = cef.GetVersion()
    print("[hello_world.py] CEF Python {ver}".format(ver=ver["version"]))
    print("[hello_world.py] Chromium {ver}".format(ver=ver["chrome_version"]))
    print("[hello_world.py] CEF {ver}".format(ver=ver["cef_version"]))
    print("[hello_world.py] Python {ver} {arch}".format(
           ver=platform.python_version(),
           arch=platform.architecture()[0]))
    assert cef.__version__ >= "57.0", "CEF Python v57.0+ required to run this"


main()
