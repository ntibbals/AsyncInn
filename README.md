# AsyncInn

### Introduction

- This is a Hotel management system for "Async Inn". It utilizes the Schema above to manage the data within a SQL database. The database is comprised of five tables listed with each relationship listed below:

- The Hotel table has a one to many relaitonship with the Hotel Room table with one primary key.
- The Hotel Room table has a many to many relationship with the Hotel AND Room table along with two concrete keys of Hotel ID and Room Number.
- The Room table has a one to many relationship with the Hotel Room AND Room Amenities table. It also includes a enum for each potential room layout along with one primary key.
- The Room Amenities table has a manay to many relationship with the Room AND Amenities table along with two concrete keys of Ameniteis ID and Room ID.
- The Amenities table has a one to many relationship wit hthe Room Amenities table along with one primary key.
