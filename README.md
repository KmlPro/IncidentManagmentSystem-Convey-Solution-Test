# Purpose
This repository is created for testing Convey utlis set and practice skills from https://devmentors.io/courses/mikroserwisy-net course.
 
Link to Convey: https://convey-stack.github.io/documentation/getting-started/

Link to Pacco project (my solution mostly base on this solution). https://github.com/devmentors/Pacco

# Documentation 

## How to run this solution ? 

1) Execute script <b> docker-compose -f infrastructure.yml up -d </b> from compose folder, for run MongoDb and RabbitMq Docker images. 
2) Run *.API projects and Api Gateway from Visual Studio or Raider IDE (or console if you want).

## Use cases

### Draft application

You can create a draft and mark it as ready to send.

Created applications can be downloaded using the unique identifier or can be found in the created list


### Posted applications 

To send an application for initial verification, you must create the posted application in the Incident Report module. Incident Report will publish the "PostedApplicationAdded" event and module Initial Incident Verification will create an application for initial verification based on recevied event.


## How to test Use Cases?

In the folder <b> tests/postman </b> there are test collections for Postman. Each collection includes tests for those posted by ApiGateway.
