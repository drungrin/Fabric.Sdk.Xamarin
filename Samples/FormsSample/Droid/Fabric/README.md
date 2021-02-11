Setup
==========

#### 1. Add **Fabric** folder to the Android project with **generate.sh** script and **fabric.properties** file

#### 2. Update **Farbic/fabric.properties** file with your API Secret and Key

#### 3. Generate resources for the first time from the console (from the Android project folder)

```
sh Fabric/generate.sh
```

The script generates 2 files:

- `Assets/crashlytics-build.properties`
- `Resources/values/com_crashlytics_export_strings.xml`

#### 4. Add generated files to the Android project

#### 5. Add Pre-Build step to Android project

1. Open **Project Options -> Build -> Custom Commands**
2. Add **Before Build** step
3. Command: `sh Fabric/generate.sh`
4. Working Directory: `${ProjectDir}`
5. Ensure build step added for every Android configuration (Debug, Release, etc.)

#### 6. Update .gitignore to not commit tools and secrets

- `crashlytics-devtool.jar`
- `fabric.properties`


## Notes

To automate Fabric properties generation we use **crashlytics-devtools.jar** tool.

It's downloaded if needed as part of the script from the fabric.io.

In case it's not available from the fabric.io, just find it somewhere and save in **Fabric** folder.
