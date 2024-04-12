# Hornetsecurity Project

For Developing of the application, we have used consol project where we can scan a folder and subfolders inside the folder. 

- We are storing data in sqlite database. 
- Communication with database we are using Entity framework 

## Project status 

To run the application, we need to follow the steps.  

We just need to run the application. In first load the application will create sqlite database in root folder of the project with a name "hashfiles.db". 

## Get Start

The first application will ask for "Folder Path:" to scan it. 
- After finishing scanning files inside the folder and getting all the information we need we will store them in the database. 

For each file, we will scan only once if we have information about it in our database. 

After finishing the scan, we will print in console some information about the folders which are scanned, and we will ask for the next path. 

If we write "exit" the application will be shut down. 
