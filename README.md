# Layered Architecture Workshop

This repository contains example code for Sander Kooijmans' Layered Architecture workshop. In this workshop the participants build
a small program for a library. The program will maintain a collection of books, users and borrowed books.

The examples are written in C#. To see the solution to exercise n (where n is the number of the exercise), checkout 
the branch `exercise<n>`. So for exercise 1 you have to checkout branch `exercise1` like this:

```
git checkout exercise1
````

After a short introduction on architecture and layered architecture (Presentation Layer, Business Layer and Data Access Layer),
the participants work on the following exercises.

## Exercise 1: Build a simple library application

Requirements:
- Create an application with 3 layers
- As a user I can add a book to the library
- As a user I can get an overview of all books in the library

KISS:
- Represent a book by a single string containing the title of the book
- In the data access layer store the books in a List instead of a real database
- If you have little experience with a GUI, build a CUI (character based UI)

## Exercise 2: Domain objects

Requirements:
- A book has an id, a title and an author
- Ids are generated by the (in-memory) database

## Exercise 3: Add user and borrowed book

Requirements:
- A user has an id and a name
- Ids are generated by the (in-memory) database
- A borrowed book consists of a book, a user, the date the book was borrowed and the due date

## Exercise 4: Interfaces

Create interfaces for all classes in:
- Presentation layer
- Business layer
- Data access layer

Classes from one layer must only depend on interfaces of other layers.

