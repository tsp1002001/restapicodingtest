-------------------------------------------------
LEAPDevInterview - Take Home Coding Test
-------------------------------------------------

LEAP Dev is building an activity tracking solution for law firms such
that they can record the time spent performing different types of
activities during the process of providing a legal service.

Some skeleton code has been provided with some code filled out, however, there 
are still a few features which are required to make the solution work.

We have created a sample endpoint 'api/v1/activities/{id}' to provide a benchmark of what we expect,
however, feel free to include anything you think would improve the solution or make your response stand out. 

You can use postman or an equivalent program to create and test cURLs.

The following curl will retrieve one of the activities which are seeded into the database in ActivityDbInitialiser.cs

curl --location 'https://localhost:7132/api/v1/activities/B529F581-8674-4865-9FDB-C87DAD209AA9'

-------------------------------------------------
i) Create Activity
-------------------------------------------------
Create an endpoint which allows a client to save an Activity object to the database. An
Activity class has been created in the 'Models' folder for you to use in this exercise. 

The client should be able set all values except for the activity's Id, 
which should be returned by your program.

Add validation where you believe is appropriate. For example: 'Activity Type should not be Unknown'.

-------------------------------------------------
ii) Update Activity
-------------------------------------------------
Create an endpoint which allows the client to edit any of the following properties for an
Activity based on its Id:

- Name
- DateTimeStarted
- DateTimeFinished

It should be possible for them to edit these properties in any combination.

Add validation where you believe is appropriate. 

-------------------------------------------------
iii) Retrieve Activities by Matter
-------------------------------------------------
a) The front end team for the application is looking to build a screen where users can
view all of the activities for a specific matter. Provide an endpoint which addresses this
requirement.

b) Given there could potentially be a very large number of activities within a Matter,
the front end may not be able to handle the entire dataset at once. 

Amend the endpoint in part (a) to address this requirement.

c) The front end is now looking to filter the activities within the Matter by the following
criteria (these filters should be able to be applied independently and in combination):

- Type
- Date range
- A phrase contained within the name (you can decide how complex this will be)

Amend the endpoint in part (b) to address this requirement.

-------------------------------------------------
iv) Fixing a Bug
-------------------------------------------------
Recently, a new feature was implemented which moves a collection of activities from one staff to another. 

In order to address this requirement, a backend developer has created an endpoint 
(api/v1/activities/bulk-update-staff) which takes a StaffId and a list of Activity Ids and updates the 
staffId for each of the corresponding activities. 

Unfortunately, Clients have reported that the feature is not functional. 
When they attempt to move activities to another staff, they have reported that they see an error on their screen. 
It appears the error message has been thrown from the backend. 

Identify and repair this issue. Take care to ensure the endpoint functions as expected and activities 
are successfully updated with the selected staffId after you fix all bugs.

The following curl will call the endpoint which has been set up with the default data seeded into the database:

curl --location 'https://localhost:7132/api/v1/activities/bulk-update-staff' \
--header 'Content-Type: application/json' \
--data '{
    "activityIds" : ["B529F581-8674-4865-9FDB-C87DAD209AA9","454F94AC-7113-4C35-A9C8-705021663745"],
    "staffId" : "C52A3A53-19E0-4922-8878-AB9820864046"
}'
