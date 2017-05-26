# Script Error

[![Build status](https://ci.appveyor.com/api/projects/status/5r0c75v55bm4627c?svg=true)](https://ci.appveyor.com/project/madskristensen/scripterror)

Download this extension from the [VS Marketplace](https://marketplace.visualstudio.com/items?itemName=MadsKristensen.JavaScriptErrorDetector)
or get the [CI build](http://vsixgallery.com/extension/36a06f2c-967d-4d2d-8285-5c1b039b769f/).

---------------------------------------

Detects any unhandled JavaScript errors from the running browser and shows them directly in the Visual Studio Error List.

See the [change log](CHANGELOG.md) for changes and road map.

## Detecting errors
By default, the detecotr runs when any ASP.NET generated page is loaded in the browser. That can be controlled from the Browser Link context menu on the *Standard* toolbar.

![Context menu](art/context-menu.png)

## Error List
Errors show up in the Error List inside Visual Studio after running the script error checker.

![Error List](art/error-list.png)

## Known limitations

### 1. Chrome Developer Tools
Google Chrome doesn't fire error events when the Developer Tools (F12) are open and therefore no errors will show up in the Error List in Visual Studio.

**Fix:** Close the Chrome Developer Tools and reload the page

### 2. Errors on page load
The extension cannot detect errors that occur before Browser Link has made the connection to Visual Studio. It doesn't take long to make the connection, but it might be long enough that the error has already occured.

**Fix:** None

## Contribute
Check out the [contribution guidelines](.github/CONTRIBUTING.md)
if you want to contribute to this project.

For cloning and building this project yourself, make sure
to install the
[Extensibility Tools](https://visualstudiogallery.msdn.microsoft.com/ab39a092-1343-46e2-b0f1-6a3f91155aa6)
extension for Visual Studio which enables some features
used by this project.

## License
[Apache 2.0](LICENSE)