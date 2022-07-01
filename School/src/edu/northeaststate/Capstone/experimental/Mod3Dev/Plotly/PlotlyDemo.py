# import pandas as pd
# import plotly.express as px
#
# us_cities = pd.read_csv("https://raw.githubusercontent.com/plotly/datasets/master/us-cities-top-1k.csv")
# us_cities = us_cities.query("State in ['New York', 'Ohio']")
#
#
# # Grab some lag and lon data. Make api for this maybe
# fig = px.line_mapbox(us_cities, lat="lat", lon="lon", color="State", zoom=3, height=300)
#
# fig.update_layout(mapbox_style="stamen-terrain", mapbox_zoom=4, mapbox_center_lat=41,
#                   margin={"r": 0, "t": 0, "l": 0, "b": 0})
#
# fig.show()

import plotly.graph_objects as go

fig = go.Figure(go.Scattermapbox(
    mode = "markers+lines",
    lon = [10, 20, 30],
    lat = [10, 20,30],
    marker = {'size': 10}))

fig.add_trace(go.Scattermapbox(
    mode = "markers+lines",
    lon = [-50, -60,40],
    lat = [30, 10, -20],
    marker = {'size': 10}))

fig.update_layout(
    margin ={'l':0,'t':0,'b':0,'r':0},
    mapbox = {
        'center': {'lon': 10, 'lat': 10},
        'style': "stamen-terrain",
        'center': {'lon': -20, 'lat': -20},
        'zoom': 1})

fig.show()