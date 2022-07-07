# Tyler Burleson
## _Final Project_

### Summary
I sorted the project in to 3 main files in a MVVM design pattern. My method of solving this project was to use the same method i did for my Five Day Forcast in the SunsetSunrise MVVM. I created a new class in the Tides Model file called DisplayPredictions. These items would then be set to the same results as the prediction IList and added to the Collection. I then used a List view and bound the Time and the Type to the screen. I also included the possibility for the Tide height value to be displayed as well if you un-comment it in the MainPage.xaml.

### Key Pieces
- Observable Collection [ModelView]
- ListView [View]
- DisplayPrediction Class [Model]