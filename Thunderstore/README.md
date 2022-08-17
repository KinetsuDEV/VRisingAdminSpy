# AdminSpy
`Server side only` mod to notify players about admin actions.
`Hot reload` enabled.

This mod was created to bring some transparency to players about admin actions, in order to mitigate admin abuses.

## Installation
* Install [BepInEx](https://v-rising.thunderstore.io/package/BepInEx/BepInExPack_V_Rising/)
* Install [Wetstone](https://v-rising.thunderstore.io/package/molenzwiebel/Wetstone/)
* Extract _AdminSpy.dll_ into _(VRising server folder)/BepInEx/plugins_

## Chat Commands
`!AdminSpy`: You can check if `AdminSpy Mod` is running on the server and check the configurations.

![alt text](https://github.com/KinetsuDEV/VRisingAdminSpy/blob/main/Thunderstore/admin-spy-command.png?raw=true)

## AdminSpy in action

![alt text](https://github.com/KinetsuDEV/VRisingAdminSpy/blob/main/Thunderstore/admin-spy-logs.png?raw=true)

## Configurable Values
```ini
[AdminSpyConfig]

## Announce following commands execution: Adminauth, AdminDeauth
# Setting type: Boolean
# Default value: false
AnnounceAuth = false

## Announce following commands execution: Give, GiveSet
# Setting type: Boolean
# Default value: true
AnnounceGive = true

## Announce following commands execution: All kind of teleport command
# Setting type: Boolean
# Default value: false
AnnounceTeleport = false

## Announce following command execution: ChangeDurability
# Setting type: Boolean
# Default value: false
AnnounceDurability = false

## Announce following commands execution: ChangeHealthOfClosestToMouse
# Setting type: Boolean
# Default value: true
AnnounceHealth = true

## Announce following command execution: SetAdminLevel
# Setting type: Boolean
# Default value: false
AnnounceAdminLevel = false
```