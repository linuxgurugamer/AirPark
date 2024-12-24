# AirPark
KSP Mod to land vessel in atmosphere. 

Basic Usage Instructions

Attach the airpark part located under the command and control tab to use. 

Toggle on to freeze vessel in place and mark it as landed to enable vehicle 
switching and toggle off to resume flight. 

Enable AutoPark to automatically unpark when attached inactive vessel is 
within 1.5 km of active vessel and automatically park when greater than 2 km 
away from the  active vessel. Use this feature to facilitate mid-air 
refueling or other shenanigans.

-------------------

Written by @Smelly, maintained for a while by @dunclaw, then by  @gomker, original thread is here:  https://forum.kerbalspaceprogram.com/index.php?/topic/162504-145-airpark-continued/

AirPark - Continued

Freeze your vessels during flight. Useful for parking large vessels such as airships boats, submarines etc... Vessel will be set to a "landed" state and previous state will be recorded.

Thanks to the original Author : @Smelly and previous maintainer : @dunclaw

Use the supplied part to Park the vessel by right click menu 
When a vessel is un-parked its previous velocity and speed will be restored
Auto Un-Park - if set to on will un-park any vessel once within physics range
Current Work In progress issues
The toolbar functions are known to be buggy at the moment
I am working to move this to a Vessel module to allow for more consistent behavior
Availability

Source:https://github.com/linuxgurugamer/AirPark
Download: https://github.com/linuxgurugamer/AirPark/releases
License: GPLv3
Available via CKAN

Dependencies

Click Through Blocker
ToolbarController
SpaceTuxLibrary
ModuleManager (for 1.12 version)
Changelog

1.7.1

Added AssemblyVersion.tt
Added InstallChecker
Converted from stock toolbar to ToolbarController
Added support for ClickThroughBlocker
Made window draggable
Enabled toolbar button to change color when autopark is enabled
Fixed bug where when leaving scene (to spacecenter) and returning, would be at 0 altitude (confirmed in 1.4.5)
Added new dependencies
ToolbarController
ClickthroughBlocker
1.7.1.1

Removed static instance reference to part, necessary to allow multiple craft to have the module loaded
Really fixed bug where leaving game and returning would be at 0 altitude
Fixed autopark on/off
Moved autopark setting into stock settings page
Deleted old commented code
Added new dependency:  SpaceTuxLibrary
1.7.1.2

Fixed agent title
Resized buttons for both toolbars
1.7.1.3

Restored missing icons (toolbar)
1.7.1.4

Added AssemblyFileVersion
Updated version file for KSP 1.12
1.7.1.5

Added MM script to add AirPark module to all parts with ModuleCommand
1.7.1.6 (supported on 1.12.2)

Fixed name of settings page
Added option to allow parking while suborbital
 

Note that while 1.7.1.6 is only "officially" supported for 1.12.2, I have tested it back to 1.8.1 and it works there as well. 

 

