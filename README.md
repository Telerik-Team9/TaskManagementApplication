<img src="https://webassets.telerikacademy.com/images/default-source/logos/telerik-academy.svg)" alt="logo" width="300px" style="margin-top: 20px;"/>

# OOP Teamwork Assignment <br><br> Team9 TaskManagementApplication

### Members:

- ![#1589F0](https://via.placeholder.com/15/1589F0/000000?text=+) **Ali Marekov**
- ![#00FF00](https://via.placeholder.com/15/00FF00/000000?text=+) **Magdalena Nikolova**

<p align="center">
[**Click Here**](https://trello.com/b/K80zh1cl) for our <img src="https://productivetihube.files.wordpress.com/2019/12/trello-logo-1.png" width="8%"/> board

## 1. Project Description
Design and implement a Work Item Management (WIM) Console Application.
<br><br>

## 2. Project information
- Framework: **.NET Core 3.0**
- Language: **C# 8**
<br><br>

## 3. Goals  
Your goal is to design and implement the main building blocks of the application - the **BoardItem** class and the **Board** class.
<br><br>

## 4. Functional Requirements
Application should support multiple teams. Each team has name, members, and boards.

Member has name, list of work items and activity history.

- [ ] Name should be unique in the application
- [ ] Name is a string between 5 and 15 symbols.

Board has name, list of work items and activity history.

- [ ] Name should be unique in the team
- [ ] Name is a string between 5 and 10 symbols.

There are 3 types of work items: bug, story, and feedback.

### Bug
Bug has ID, title, description, steps to reproduce, priority, severity, status, assignee, comments, and
history.

- [ ] Title is a string between 10 and 50 symbols.
- [ ] Description is a string between 10 and 500 symbols.
- [ ] Steps to reproduce is a list of strings.
- [ ] Priority is one of the following: High, Medium, Low
- [ ] Severity is one of the following: Critical, Major, Minor
- [ ] Status is one of the following: Active, Fixed
- [ ] Assignee is a member from the team.
- [ ] Comments is a list of comments (string messages with author).
- [ ] History is a list of all changes (string messages) that were done to the bug.

### Story
Story has ID, title, description, priority, size, status, assignee, comments, and history.

- [ ] Title is a string between 10 and 50 symbols.
- [ ] Description is a string between 10 and 500 symbols.
- [ ] Priority is one of the following: High, Medium, Low
- [ ] Size is one of the following: Large, Medium, Small
- [ ] Status is one of the following: NotDone, InProgress, Done
- [ ] Assignee is a member from the team.
- [ ] Comments is a list of comments (string messages with author).
- [ ] History is a list of all changes (string messages) that were done to the story.

### Feedback

Feedback has ID, title, description, rating, status, comments, and history.

- [ ] Title is a string between 10 and 50 symbols.
- [ ] Description is a string between 10 and 500 symbols.
- [ ] Rating is an integer.
- [ ] Status is one of the following: New, Unscheduled, Scheduled, Done
- [ ] Comments is a list of comments (string messages with author).
- [ ] History is a list of all changes (string messages) that were done to the feedback.

Note: IDs of work items should be unique in the application i.e. if we have a bug with ID X then
we cannot have Story of Feedback with ID X.
<br><br>

## 5. Operations
Application should support the following operations:

- [ ] Create a new person
- [ ] Show all people
- [ ] Show person's activity
- [ ] Create a new team
- [ ] Show all teams
- [ ] Show team's activity
- [ ] Add person to team
- [ ] Show all team members
- [ ] Create a new board in a team
- [ ] Show all team boards
- [ ] Show board's activity
- [ ] Create a new Bug/Story/Feedback in a board
- [ ] Change Priority/Severity/Status of a bug
- [ ] Change Priority/Size/Status of a story
- [ ] Change Rating/Status of a feedback
- [ ] Assign/Unassign work item to a person
- [ ] Add comment to a work item
- [ ] List work items with options:
    - [ ] List all
    - [ ] Filter bugs/stories/feedback only
    - [ ] Filter by status and/or assignee
    - [ ] Sort by title/priority/severity/size/rating
<br><br>

## 6. General Requirements
- Follow the OOP best practices:
    - Proper use data encapsulation
    - Proper use of inheritance and polymorphism
    - Proper use of interfaces and abstract classes
    - Proper use of static members
    - Proper use enumerations
    - Follow the principles of strong cohesion and loose
coupling
- Use LINQ
- Implement proper user input validation and display meaningful user messages
- Implement proper exception handling
- Cover functionality with unit tests (80% code coverage)
- Use Git to keep your source code and for team collaboration
<br><br>

## 7. Teamwork Requirements
Refer to the teamwork requirements document found along with the project requirements.
<br><br>

## 8. Teamwork defense
Prepare a list of commands to demonstrate how the program works.

