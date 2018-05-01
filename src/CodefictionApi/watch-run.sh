#!/bin/bash
ng build --env=dev --app 0 --watch & ng build --env=dev --app 1 && dotnet run