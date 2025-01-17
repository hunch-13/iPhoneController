[![Build](https://github.com/versx/iPhoneController/workflows/.NET%20Core/badge.svg)](https://github.com/versx/iPhoneController/actions)
[![GitHub Release](https://img.shields.io/github/release/versx/iPhoneController.svg)](https://github.com/versx/iPhoneController/releases/)
[![GitHub Contributors](https://img.shields.io/github/contributors/versx/iPhoneController.svg)](https://github.com/versx/iPhoneController/graphs/contributors/)
[![Discord](https://img.shields.io/discord/552003258000998401.svg?label=&logo=discord&logoColor=ffffff&color=7389D8&labelColor=6A7EC2)](https://discord.gg/zZ9h9Xa)  

# iPhoneController  
Reboot, grab a screenshot, running iOS versions, kill specific running processes, or remove Pokemon Go from multiple devices all from Discord.  

## Commands  

| Command | Description |
| ------------- | ------------- |
| `list [machine_name]`  | Retrieve a list of devices from all machines or a specific one. |
| `iosver [machine_name]` | Retrieve a list of iOS versions running on devices for all machines or a specific one. |
| `screen iPhone1, iPhone2` | Take a screenshot of specific device(s). |
| `sam iPhone1, iPhone2` | Reapply Single App Mode profile for provided device(s). |
| `reopen iPhone1, iPhone2` | Send restart game request to device(s). |
| `reboot iPhone1, iPhone2` | Reboot specific device(s). |
| `shutdown iPhone1, iPhone2` | Shutdown specific device(s). |
| `resign https://mega.nz/file/yS7C#Dsh0lZDkk 1.33.0b1 iPhone1,iPhone2` | Download latest app, resign, and deploy to specified devices (leave blank or specify `All` for all devices connected to the machine) |
| `deploy iPhone1,iPhone2` | Deploy latest already signed app from releases folder to specific device(s). |
| `rm-pogo iPhone1,iPhone2` | Removes Pokemon Go from specific device(s). |
| `kill usbmuxd [machine_name]` | Kill a specific process such as `usbmuxd`.  |

**Notes:**  
- *Parameters in brackets `[ ]` are optional*  
- *When specifying device names, spaces between commas is supported. i.e `!reboot iPhone1, iPhone2`*  
- *Best used with the same bot token if deploying to multiple machines. Devices not found will be skipped when executing commands.*  

## Installation  

Run the following commands and fill out config.  
```
wget https://raw.githubusercontent.com/versx/iPhoneController/master/install.sh && chmod +x install.sh && ./install.sh && rm install.sh
```

### App Deployment  
After building `iPhoneController` for the first time:  
1. In your `bin` folder, create a `releases/config` folder  
1. Copy your GC `config.json` to the new `releases/config` folder  
1. In your `bin` folder, create a `profiles` folder  
1. Copy your mobile provisioning profile to the new `profiles` folder  

### Single App Mode  
In order to reapply the SAM profile, you'll need to do the following:  
1. Copy `sam_pogo.mobileconfig` to your `bin` folder  
1. In AC2, click on the `Apple Configurator 2` menu and choose `Install Automation Tools`.  
1. In AC2, click on the `Apple Configurator 2` menu and choose `Preferences` > `Organization` > click on your org and choose `Export Supervision Identity` at the bottom left.  
1. Move the .crt and .der files to your `bin` folder and rename them to `org.crt` and `org.der`.  

## Updating  
1. `git pull` (from root of folder)  
1. `~/.dotnet/dotnet build`  
1. `cd bin`  
1. `~/.dotnet/dotnet iPhoneController.dll`  

## Running  
From the `bin` folder type the following:  
`~/.dotnet/dotnet iPhoneController.dll`  

## FAQ
Q. How do I get the profile ID?  
A. Run `security find-identity -p codesigning`  

Q. I'm receiveing `{"Command":"list","Output":{},"Type"::CommandOutput","Devices":[]}` when `cfgutil --format JSON list` is run.  
A. Reinstall Apple Configurator 2 automation tools  

## TODO  
- Localization  
