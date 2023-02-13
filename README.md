# ReadyTech
This tiny project is designed and implemented to control the internet-connected coffee machine. It is integrated with the third party open weather API to handle brew-coffee requests with corresponding responses. This is gonna be a usefully tool to track the brew coffee request/coffee orders...Most importantly, this project is a simple but handy solution to solve real life problem.

# Getting started
Prerequisites
1. Visual Studio 2022 
2. A clone or download of this repo on your local machine

#Implementation details
Assumptions:
1. the requestCount in the project is based on the assumption that the application only have one instance and the counter is not persistent.
   if the application is running multiple instances, we will consider using redis cache to store the counter.
2. when dealing with the date April1st, we made the assumption that the date is the server region time. In reality, to consider client time, we can pass the client          region time to compare with UTC time.
3. when consuming the third party API (open weather API) for the location latitute and longtitude params, we made the assumption it is located in melbourne and use          hard coded values. In reality, we can use the method or third party API to get the location latitute and longtitude then pass to the third party API.


