# **Underwatch**

---

## Description
Underwatch is an N-Tier architectured MVC Web Application created by me, Jonathan Carey. This app was created as a showcase my Software Development Skills that I learned at Eleven Fifty Academy.
The purpose of Underwatch is to create an easy way to catalogue and follow Games and News/Updates for Games that a user is interested in.

---

## List of Contents:
- Installation
- Usage
- App Current Status
- Contributing
- Credits
- Special Thanks
- License


## Installation

To install this app, follow these steps:

1. Clone the repository onto your computer
2. Download and install Microsoft Visual Studio Community for your Operating System from this link: https://visualstudio.microsoft.com/
3. Open Underwatch with Visual Studio and search for "manage nuget packages in solution" and click on that option in the drop down list
4. Look at the "packages" folder in the this projects directory and make sure you download everything in the folder.
(Note: Theres a chance I missed a package. If thats the case, click on any red underlined squiggles you may find, right click on  them, select "Quick Actions and Refactoring" and install the recommended packages that appear in the drop down menus.)
5. Set up the project assemblies' references:
- Right click on WebMVC Assembly 
- Select "Add"
- Select "Reference.."
- Select Data, Models and Services
- Right click on Services Assembly
- Select "Add"
- Select "Reference.."
- Select Data and Models
- Right click on Models Assembly
- Select "Add"
- Select "Reference.."
- Select Data
6. You will need to remake your Data Tables, do so by the following:
- Delete the Migrations Folder entirely located in the Data Assembly
- Open Package Manager Console, located at the search bar on the top of Visual Studio
- Click on the drop down menu "Default project" and change it to Data
- Enter the command: Enable Migrations
- Enter the command: Add-Migration "your migration title here"
- Enter the command: Update-Database
7. You're all set up and ready to start coding!

---

## Usage
Feel free to use this app for whatever you like! All I ask is that you first Delete or change the information in the About section and Contact section.

When using this Web App, to Create a News Item, you must first have at least one Game created. When creating an Underwatch item, you must have at least one News Item created.

---

## App Current Status
Currently the app has a fully functioning CRUD but several features have yet to be implemented, mostly due to time constraits as this was a final project for my time at Eleven Fifty Academy.
A few of the features I plan to implement include:

-search through your lists for a single item with a searchbar

-filter your lists alphabetically

-countdown timer for new games coming out

-let users pick from a premade database of games from an outside API

-use web scrapping to find updates and news on games

-allows users to get notifications about their game updates

-display active users for a particular game

---

## Contributing
- JonathanCarey13

---

## Credits
This app was made by Jonathan Carey

--- 

## Special Thanks
A special thanks to [dmmarsh114](https://github.com/dmmarsh114) for his help creating/troubleshooting the current styling for the project. Seriously, that massive brain of his is so wrinkly and too powerful.
Oh, and all the wonderful people at Eleven Fifty Academy who supported and helped me along the way.

---

## License
Creative Commons Attribution Share Alike 4.0 cc-by-sa-4.0
