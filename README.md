# CTI-Application

![Application preview](https://raw.githubusercontent.com/PsychoSanchez/CTI-Application/master/BAsterisk.png)

This computer telephony integration application is build to work with open software comnunication software Astersik using Asterisk Manager Interface.

This repository contains 3 stadalone applications:

 - AsteriskManager library
 - Virtual Server
 - CTI application
 
 ### AsteriskManager
 Highly modified version of Asterisk manager interface .Net library. It was fully rebuilt that it could be compatible for all AMI versions, upgraded with custom made multitread parser and reduced data models size by optimizing asterisk responses in application.
 
 ### Virtual Server
 Debugging tool created especially for AsteriskManager library and CTI application.
 
 It takes Asterisk Manager Interface log file and simulates Astersk server behaviour allowing to debug CTI Application remotely without direct testing on target server. 

 ### CTI-Application
 Asterisk CTI Application allows user to follow and inititate actions of 1 specified number.
 
Application created with .NET 3.5 Win Forms and use cutom controls with unique design. Code was simplyfied for future possibility to create .NET 2.0 port. Decision to create application using Win Forms and .NET 2.0 - 3.5 was initiated by stakeholders.
It uses Asterisk AMI Interface output to filter specified user events and create interacive and responsive interface, that allows user to be more productive during work.

All rights reserved with Basterisk.
