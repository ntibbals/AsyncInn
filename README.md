# AsyncInn

### Introduction

- This is a Hotel management system designed for "Async Inn". The application is intended to assist with management of the hotel chains assets. It allows an administrator the ability to search for a particular asset within each asset category. The administrator has the ability to add new hotel locations, find existing hotel locations, add new rooms, add new amenities, associate amenities with specific rooms, as well as manipulate the assets by editing, deleting, creating a room rate and assigning rooms specific numbers. The application will also display the total number of hotels, rooms, and amenities on each asset landing page. 

### Specifications

- The data persists within a SQL database. The database is comprised of five tables listed with each relationship listed below:
- 
- The Hotel table has a one to many relaitonship with the Hotel Room table with one primary key.
- The Hotel Room table has a many to many relationship with the Hotel AND Room table along with two concrete keys of Hotel ID and Room Number.
- The Room table has a one to many relationship with the Hotel Room AND Room Amenities table. It also includes a enum for each potential room layout along with one primary key.
- The Room Amenities table has a manay to many relationship with the Room AND Amenities table along with two concrete keys of Ameniteis ID and Room ID.
- The Amenities table has a one to many relationship wit hthe Room Amenities table along with one primary key.
- Unit testing for CRUD operations on all tables

### System Design 
![SCHEMA](https://github.com/ntibbals/AsyncInn/blob/master/Assets/SchemaAsyncInn.png)

### Navigation

- From the home page, you can navigate to "Create Hotel" page, "Create Room" page, "Create Amenity" page, as well as pages for the "Hotel Room" association and "Room Amenity" association.

### Visual

#### Home page

![SCHEMA](https://github.com/ntibbals/AsyncInn/blob/master/Assets/index.PNG)

#### Hotels navigation page
![SCHEMA](https://github.com/ntibbals/AsyncInn/blob/master/Assets/hotel-in.PNG)

#### Create new hotel
![SCHEMA](https://github.com/ntibbals/AsyncInn/blob/master/Assets/create-hotel.PNG)

#### Edit a hotel
![SCHEMA](https://github.com/ntibbals/AsyncInn/blob/master/Assets/edit-hotel.PNG)

#### Details of a hotel
![SCHEMA](https://github.com/ntibbals/AsyncInn/blob/master/Assets/hotel-details.PNG)

#### Details of a hotel
![SCHEMA](https://github.com/ntibbals/AsyncInn/blob/master/Assets/hotel-delete.PNG)

#### Rooms navigation page
![SCHEMA](https://github.com/ntibbals/AsyncInn/blob/master/Assets/room-in.PNG)

#### Create a new room
![SCHEMA](https://github.com/ntibbals/AsyncInn/blob/master/Assets/create-room.PNG)

#### Amenities navigation page
![SCHEMA](https://github.com/ntibbals/AsyncInn/blob/master/Assets/Amen-in.PNG)

#### Create a new amenity
![SCHEMA](https://github.com/ntibbals/AsyncInn/blob/master/Assets/create-am.PNG)

#### Individual Hotel Room navigation page
![SCHEMA](https://github.com/ntibbals/AsyncInn/blob/master/Assets/hotelroom-ind.PNG)




