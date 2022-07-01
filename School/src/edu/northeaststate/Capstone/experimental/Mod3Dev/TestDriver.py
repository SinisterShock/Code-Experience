import cmath
import math
import plotly.graph_objects as go
import pandas as pd

from CalcTheoretical import CalcTheoretical
from CalculateK import CalulateK
from experimental.Mod3Dev.propcalc.Calculations2 import PropCalculation
import json

def main():
    towerlist1 = [
        {
            'num': 1,
            'ratio': 0.520,
            'phase': 64,
            'spacing': 0.00,
            'orientation': 2,
            'ref': 0,
            'height': 70.8
        },
        {
            'num': 2,
            'ratio': 1,
            'phase': 0,
            'spacing': 75.00,
            'orientation': 60,
            'ref': 0,
            'height': 141.6
        },
        {
            'num': 3,
            'ratio': 1.4,
            'phase': 242,
            'spacing': 150.00,
            'orientation': 60,
            'ref': 0,
            'height': 70.8
        }
    ]
    datatoplot = []
    ratio = 1
    phase = 1
    spacing = 0
    orientation = 0
    height = 120
    power = 10
    rms = 1026
    k = CalulateK()
    kdata = k.getk(power, height, 0, ratio, phase, rms, towerlist1, 1)
    newtest = PropCalculation()
    testing = newtest.calcprop(10, power, kdata, height)

    t = CalcTheoretical()
    #print(t.gettheoreticalangle(phase, height, 1, spacing, ratio, towerlist1))

    vc = towerlist1
    theodata = [['y', 'x']]
    theoangle = towerlist1
    if theodata is not None:
        theodata.clear()

    # For loop used to set the length of each item in list vc to the length in the tower list
    # for i in range(len(vc)):
    #   vc[i].set_length(num_tower + 1)

    for j in range(360):
        pattern = 0

        for i in range(len(towerlist1)):
            arg = math.atan2(0, 2 * math.pi * towerlist1[i]['spacing'] / 360 * math.cos(towerlist1[i]['height'] * math.pi / 180) *
                             math.cos(math.pi / 180 * (j - towerlist1[
                                 i]['orientation'])) + math.pi / 180 * towerlist1[i]['phase'])
            vert = 1
            a1 = vert * ratio
            pattern = pattern + cmath.exp(arg) * a1

        #theoangle[j]['pat'] = cmath.atan(pattern[1])

        t = [j, (testing) * pattern]
        datatoplot.append(t)


        #if len(theodata[j]['pat']) > 0:
        #    maxdata = len(theoangle[j]['pat'])

    # print(theoangle)

    # Using Panda's to read in an external CSV as a DataFrame
    # Doc on what it's doing: https://pandas.pydata.org/pandas-docs/stable/reference/api/pandas.read_csv.html
    # Note, we won't need this in a final implmentation
    df = pd.read_csv("https://raw.githubusercontent.com/plotly/datasets/master/polar_dataset.csv")

    # Parameterized Constructor for creating a figure
    fig = go.Figure(data=
    go.Scatterpolar(  # Using this to add the points that represent the towers
        # Doc for Scatterpolar: https://plotly.com/python/reference/scatterpolar/#scatterpolar
        r=[0.0, 0.1, 0.2, 0.5],  # distance from the center
        theta=[0, 0, 0, 0],  # orientation from 0 degrees
        name='Towers',
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
        text='3',
        textposition='top right'

        # Font based approach
        # mode='text',
        # text='📡',
        # textfont=dict(
        #     family='Segoe UI Emoji',
        #     size=20,
        # ),
    ))

    # The next four add_trace are what adds the lines
    fig.add_trace(go.Scatterpolar(
        r=df['x3'],
        theta=df['y'],
        mode='lines',
        name='Blue',
        line_color='deepskyblue'
    ))

    # Format the output
    fig.update_layout(
        title='Polar Chart Example',
        # showlegend = True
        polar=dict(
            radialaxis_angle=-45,
            angularaxis=dict(
                direction="clockwise",
                period=6)
        )
    )

    fig.show()


main()
