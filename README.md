# BetterHealthCare Web Application (Frontend)
## Overview

BetterHealthCare_WebApp is an ASP.NET Core MVC application that serves as the frontend for the BetterHealthCare system.

It consumes the BetterHealthCare REST API and provides a user interface for managing healthcare data such as Patients, Procedures, Medical Files, and Patient Actions.

The application is built using ASP.NET Core MVC with Razor Views (.cshtml).

## Architecture

The frontend follows a structured MVC pattern:

- Controllers
Handle user requests and interact with the API through HttpClient-based services.

- Services (API Consumers)
Use HttpClient to call the backend API endpoints asynchronously.

- Views (.cshtml)
Built using Razor syntax with HTML and Bootstrap for UI rendering.
Forms use Razor helpers like:

- asp-for

- asp-action

- asp-controller

## Features

Full CRUD interface for:

- Server-side form handling

- Model validation

- Clean separation between UI and API logic

Asynchronous communication with backend API:

- Patients

- Procedures

- Medical Files

- Patient Actions

## How It Works

- The user interacts with Razor Views (Create, Edit, Delete, Details, Index).

- MVC Controllers receive the request.

- Controllers call frontend services.

- Services send HTTP requests to the BetterHealthCare API.

- The API response is mapped to DTOs and rendered in the View.

## Technologies Used

- ASP.NET Core MVC

- Razor Views (.cshtml)

- HttpClient

- Bootstrap

- Dependency Injection
