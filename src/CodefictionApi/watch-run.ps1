Start-Process Powershell "ng build --env=dev --app 0 --watch" ; Start-Process Powershell "ng build --env=dev --app 1 --watch" ;
if ($?) {
    Start-Process Powershell "dotnet run"
}
