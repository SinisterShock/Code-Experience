import plotly.graph_objects as go

import pandas as pd

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
