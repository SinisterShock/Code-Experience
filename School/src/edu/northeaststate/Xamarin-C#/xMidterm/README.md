# Midterm

Summary:

I used the Geo Weather API and the SunsetSunrise API to create this application.
By using the new page function I navigate between Three pages. The main page uses a data base to display the current cities stored and they can be clicked or the button "Add City" can be clicked. When you click the "Add City" button you're navigated to a page that takes user input for a City name, state, and country. Once the submit button is hit it adds the city to the main page and extracts the name and the longitude and latitude. Once back on the main page the user can click an entry and be pulled to a new page that displays that location's Sunrise and sunset data. Finally the user can hit the "Delete City" button and remove the location from the database.

## Solution

Main Page:
1. Use onAppearing() to display the list of cities
2. onClick events to navigate to Add City or navigate to the Sunrise API page 

Add City:

1. Geo Weather API to gather the latitude and longitude 
2. Store those points in the database using SqlLite from the Location class

SunsetSunrise Page:

1. Display the sunrise, sunset, day length, and twilight using the Sunrise class
2. "Delete Button" using SqlLite removes the current city from the database and sends the user back to the main page 

