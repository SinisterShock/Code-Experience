from cefpython3 import cefpython as cef
import platform
import sys
import pandas as pd
import plotly.express as px
import plotly.graph_objects as go
import threading


def main():
    # us_cities = pd.read_csv("https://raw.githubusercontent.com/plotly/datasets/master/us-cities-top-1k.csv")
    # fig = px.scatter_mapbox(us_cities, lat="lat", lon="lon", hover_name="City", hover_data=["State", "Population"],
    #                         color_discrete_sequence=["fuchsia"], zoom=3, height=1000, mapbox_style="stamen-terrain")
    # fig.update_layout(margin={"r": 0, "t": 0, "l": 0, "b": 0})
    # fig.write_html("map.html")

    fig = go.Figure(go.Scattermapbox(
        mode="markers",
        lon=[-82.4], lat=[36.3],
        marker={'size': 200, 'color': ["blue"], 'opacity': 0.50}))

    #(NEW) Adds second marker
    fig.add_scattermapbox(
        mode="markers",
        lon=[-82.41], lat=[36.3],
        marker={'size': 200, 'color': ["red"], 'opacity': 0.50})

    fig.update_layout(

        mapbox={
            'style': "stamen-terrain",
            'center': {'lon': -82.4, 'lat': 36.3},
            'zoom': 12, 'layers': [
                {
                    'source': {
                        'type': "FeatureCollection",
                        'features': [{
                            'type': "Feature",
                            'geometry': {
                                'type': "MultiPolygon",
                                'coordinates': [[[
                                    [-73.606352888, 45.507489991], [-73.606133883, 45.50687600],
                                    [-73.605905904, 45.506773980], [-73.603533905, 45.505698946],
                                    [-73.602475870, 45.506856969], [-73.600031904, 45.505696003],
                                    [-73.599379992, 45.505389066], [-73.599119902, 45.505632008],
                                    [-73.598896977, 45.505514039], [-73.598783894, 45.505617001],
                                    [-73.591308727, 45.516246185], [-73.591380782, 45.516280145],
                                    [-73.596778656, 45.518690062], [-73.602796770, 45.521348046],
                                    [-73.612239983, 45.525564037], [-73.612422919, 45.525642061],
                                    [-73.617229085, 45.527751983], [-73.617279234, 45.527774160],
                                    [-73.617304713, 45.527741334], [-73.617492052, 45.527498362],
                                    [-73.617533258, 45.527512253], [-73.618074188, 45.526759105],
                                    [-73.618271651, 45.526500673], [-73.618446320, 45.526287943],
                                    [-73.618968507, 45.525698560], [-73.619388002, 45.525216750],
                                    [-73.619532966, 45.525064183], [-73.619686662, 45.524889290],
                                    [-73.619787038, 45.524770086], [-73.619925742, 45.524584939],
                                    [-73.619954486, 45.524557690], [-73.620122362, 45.524377961],
                                    [-73.620201713, 45.524298907], [-73.620775593, 45.523650879]
                                ]]]
                            }
                        }]
                    },
                    'type': "fill", 'below': "traces", 'color': "royalblue", 'opacity': 0.5},
                {
                    'source': {
                        'type': "FeatureCollection",
                        'features': [{
                            'type': "Feature",
                            'geometry': {
                                'type': "MultiPolygon",
                                'coordinates': [[[
                                    [-73.609352888, 45.507489991], [-73.609133883, 45.50687600],
                                    [-73.608905904, 45.506773980], [-73.606533905, 45.505698946],
                                    [-73.605475870, 45.506856969], [-73.603031904, 45.505696003],
                                    [-73.602379992, 45.505389066], [-73.602119902, 45.505632008],
                                    [-73.601896977, 45.505514039], [-73.601783894, 45.505617001],
                                    [-73.594308727, 45.516246185], [-73.594380782, 45.516280145],
                                    [-73.599778656, 45.518690062], [-73.605796770, 45.521348046],
                                    [-73.615239983, 45.525564037], [-73.615422919, 45.525642061],
                                    [-73.620229085, 45.527751983], [-73.620279234, 45.527774160],
                                    [-73.620304713, 45.527741334], [-73.620492052, 45.527498362],
                                    [-73.620533258, 45.527512253], [-73.621074188, 45.526759105],
                                    [-73.621271651, 45.526500673], [-73.621446320, 45.526287943],
                                    [-73.621968507, 45.525698560], [-73.622388002, 45.525216750],
                                    [-73.622532966, 45.525064183], [-73.622686662, 45.524889290],
                                    [-73.622787038, 45.524770086], [-73.622925742, 45.524584939],
                                    [-73.622954486, 45.524557690], [-73.623122362, 45.524377961],
                                    [-73.623201713, 45.524298907], [-73.623775593, 45.523650879]
                                ]]]
                            }
                        }]
                    },
                    'type': "fill", 'below': "traces", 'color': "orange", 'opacity': 0.5}

            ]},
        margin={'l': 0, 'r': 0, 'b': 0, 't': 0})

    fig.write_html("map.html")

    check_versions()
    sys.excepthook = cef.ExceptHook  # To shutdown all CEF processes on error
    cef.Initialize()
    cef.CreateBrowserSync(url="file:///map.html",
                          window_title="Hello World!")
    cef.MessageLoop()
    cef.Shutdown()


def check_versions():
    ver = cef.GetVersion()
    print("[hello_world.py] CEF Python {ver}".format(ver=ver["version"]))
    print("[hello_world.py] Chromium {ver}".format(ver=ver["chrome_version"]))
    print("[hello_world.py] CEF {ver}".format(ver=ver["cef_version"]))
    print("[hello_world.py] Python {ver} {arch}".format(
        ver=platform.python_version(),
        arch=platform.architecture()[0]))
    assert cef.__version__ >= "57.0", "CEF Python v57.0+ required to run this"


if __name__ == '__main__':
    main()
