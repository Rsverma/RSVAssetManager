<h1 align="center">
  <br>
  <a href="https://github.com/Rsverma/RSVAssetManager/archive/main.zip"><img src="https://github.com/Rsverma/RSVAssetManager/blob/main/RAMDesktopUI/Resources/AppIication.ico" alt="RSV Asset Manager" width="200"></a>
  <br>
  RSV Asset Manager
  <br>
</h1>

<h4 align="center">A minimal Asset Manager application built by RSV Enterprise Solutions.</h4>

<p align="center">
  <a href="#key-features">Key Features</a> •
  <a href="#upcoming-features">Upcoming Features</a> •
  <a href="#how-to-use">How To Use</a> •
  <a href="#credits">Credits</a> •
  <a href="#related">Related</a> •
  <a href="#license">License</a>
</p>

## Key Features

* Create Order - Send to Broker or save to database
  - Send orders to broker using FIX protocol or save already executed orders to database
* View Orders
  - View all orders executed by traders in your firm.
* Symbol Watchlist
  - Monitor live market prices of Symbols before trading
* User Roles
  - Permissions for differnet modules in application based on roles for users 

## Upcoming Features
* Fund Level Allocation
* Portfolio Manager
* Multi Trade Import

## Wishlist
* Xamarin app with same features
* Blazor Website with same features
* Unit testing

## How To Use

To clone and run this application, you'll need [Git](https://git-scm.com) and [Visual Studio](https://visualstudio.microsoft.com/) . From your command line:

```bash
# Clone this repository
$ git clone https://github.com/Rsverma/RSVAssetManager.git

# Go into the repository

# Open Solution File RSVAssetManager.sln in Visual Studio

# Publish RAMData database in sql server

# Launch RAMApi project as startup

# Click on Register and apply migrations

# Create account using your Email address

# Copy the user from RAMApiAuthDB table to RAMData

# Uncomment role creation code from HomeController with your email address in Privacy method

# Launch Api again and go to Privacy link from Home

# Setup both RAMDesktopUI and RAMApi as startup project

# Launch and login using credentials of registered account
```

## Credits

This software uses the following open source packages:

- [Caliburn Micro](https://caliburnmicro.com/)
- [Material Design In XAML](http://materialdesigninxaml.net/)
- [SwashBuckle](https://github.com/domaindrivendev/Swashbuckle.WebApi)
- [Dapper](https://github.com/StackExchange/Dapper)
- Icons from - [IconFinder](https://www.iconfinder.com/iconsets/business-collection-2027)
- Special shoutout [TimCo Retail Manager Course](https://www.youtube.com/playlist?list=PLLWMQd6PeGY0bEMxObA6dtYXuJOGfxSPx)

## Related

- [RSV Retail Manager](https://github.com/Rsverma/RSVRetailManager) - An under development Retail Manager app

## License

AGPL-3.0 

---

> Email [@rsverma333](rsverma333@gmail.com) &nbsp;&middot;&nbsp;
> GitHub [@Rsverma](https://github.com/Rsverma) &nbsp;&middot;&nbsp;
> LinkedIn [@rsverma333](https://www.linkedin.com/in/rsverma333/)
