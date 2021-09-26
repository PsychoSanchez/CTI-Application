# CTI-Application

![Application preview](https://raw.githubusercontent.com/PsychoSanchez/CTI-Application/master/BAsterisk.png)

Computer Telephony Integration software written in C# for [Asterisk](https://www.asterisk.org/). It uses Asterisk Manager Interface to communicate with the server and track provided phone number events/initiate calls and conferences/add contacts and many more.

Application updated to work with .Net Framework 5

This repository contains 3 applications:

- AsteriskManager library
- Virtual Server
- CTI application

### AsteriskManager

Highly modified version of Asterisk manager interface .Net library. It was fully rebuilt that it could be compatible for all AMI versions, upgraded with custom made multithread parser and reduced data models size by optimizing asterisk responses in application.

### Virtual Server

Debugging mock tool created for B-CTI application.

It takes Asterisk Manager Interface log file and simulates recorder server's Asterisk Manager Interface behaviour allowing to debug CTI Application locally using VirtualServer as an interactive mock.

### CTI-Application

Asterisk CTI Application allows user to follow and initiate actions for 1 specified number. It uses Asterisk's AMI output to search for user events and create interactive and responsive assistant interface, that allows user to be more productive during work.

All rights reserved with Basterisk.
