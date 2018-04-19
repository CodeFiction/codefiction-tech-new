Start-Process Powershell "ng build --env=dev --app 0 --watch" | Out-Null
Start-Process Powershell "dotnet watch run"