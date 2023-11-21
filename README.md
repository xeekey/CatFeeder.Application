<a name="readme-top"></a>
[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![Linkedin][linkedin-shield]][linkedin-url]

<!-- PROJECT LOGO -->
<br />
<div align="center">
  <!--<a href="https://github.com/xeekey/CatFeeder">
    <img src="images/logo.png" alt="Logo" width="80" height="80">
  </a> -->

<h3 align="center">CatFeeder</h3>

  <p align="center">
    An automated cat feeder application with scheduling and remote feeding capabilities.
    <br />
    <a href="https://github.com/xeekey/CatFeeder"><strong>Explore the docs »</strong></a>
    <br />
    <br />
    <a href="https://github.com/xeekey/CatFeeder">View Demo</a>
    ·
    <a href="https://github.com/xeekey/CatFeeder/issues">Report Bug</a>
    ·
    <a href="https://github.com/xeekey/CatFeeder/issues">Request Feature</a>
  </p>
</div>

<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li><a href="#usage">Usage</a></li>
    <li><a href="#contributing">Contributing</a></li>
    <li><a href="#license">License</a></li>
    <li><a href="#contact">Contact</a></li>
  </ol>
</details>

<!-- ABOUT THE PROJECT -->
## About The Project

CatFeeder is an application designed to automate cat feeding with scheduling and remote operation capabilities. It allows users to set feeding times and control the feeder remotely via an MQTT protocol.

Components:
1. **App Initialization and Configuration**:
   - `App.xaml.cs`: Initializes the main application and sets the main page.
   - `MauiProgram.cs`: Configures the Maui application, including fonts and services.

2. **Database Entities**:
   - `Timer.cs`: Defines the `Timer` entity for the database with properties like `Id`, `Time`, `RepeatDays`, and `IsToggled`.

3. **Models**:
   - `FeedResponse.cs`: Represents the response model for a feed operation.
   - `FeedTimer.cs`: Defines the `FeedTimer` model with properties and methods for handling repeat days.

4. **Android Platform Specifics**:
   - `FeedAlarmReceiver.cs`: Handles the broadcast receiver for feed alarms on Android.
   - `FeedAlarmScheduler.cs`: Schedules feed alarms.
   - `MainActivity.cs` and `MainApplication.cs`: Android main activity and application setup.

5. **Services**:
   - `MQTTService.cs`: Manages MQTT connections and feed operations.
   - `TimerService.cs`: Service for managing timer-related operations in the database.

6. **Views and ViewModels**:
   - Views: Define the UI and bind to ViewModels.
   - ViewModels: Handle the logic and data for the Views.

<p align="right">(<a href="#readme-top">back to top</a>)</p>

### Built With

* [![.NET MAUI][.NET-MAUI-shield]][.NET-MAUI-url]
* [![C#][C#-shield]][C#-url]

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- USAGE EXAMPLES -->
## Usage

To use CatFeeder, set up the application on your device and configure the feeding schedules as needed. The application communicates with the feeder hardware via MQTT to perform feeding operations.

_For more examples, please refer to the [Documentation](https://github.com/xeekey/CatFeeder)_

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- CONTRIBUTING -->
## Contributing

Contributions to CatFeeder are welcome. Please follow the standard GitHub pull request process to submit your changes.

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- LICENSE -->
## License

Distributed under the MIT License. See `LICENSE.txt` for more information.

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- CONTACT -->
## Contact
Project Link: [https://github.com/xeekey/CatFeeder](https://github.com/xeekey/CatFeeder)

<p align="right">(<a href="#readme-top">back to top</a>)</p>


<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
[contributors-shield]: https://img.shields.io/github/contributors/xeekey/CatFeeder.svg?style=for-the-badge
[contributors-url]: https://github.com/xeekey/CatFeeder/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/xeekey/CatFeeder.svg?style=for-the-badge
[forks-url]: https://github.com/xeekey/CatFeeder/network/members
[stars-shield]: https://img.shields.io/github/stars/xeekey/CatFeeder.svg?style=for-the-badge
[stars-url]: https://github.com/xeekey/CatFeeder/stargazers
[issues-shield]: https://img.shields.io/github/issues/xeekey/CatFeeder.svg?style=for-the-badge
[issues-url]: https://github.com/xeekey/CatFeeder/issues
[license-shield]: https://img.shields.io/github/license/xeekey/CatFeeder.svg?style=for-the-badge
[license-url]: https://github.com/xeekey/CatFeeder/main/LICENSE.txt
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=for-the-badge&logo=linkedin&colorB=555
[linkedin-url]: https://linkedin.com/in/kasper-hjort-jæger
[product-screenshot]: images/screenshot.png
[.NET-MAUI-shield]: https://img.shields.io/badge/.NET%20MAUI-512BD4.svg?style=for-the-badge&logo=dotnet&logoColor=white
[.NET-MAUI-url]: https://dotnet.microsoft.com/en-us/apps/maui
[C#-shield]: https://img.shields.io/badge/C%23-239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white
[C#-url]: https://docs.microsoft.com/en-us/dotnet/csharp/
