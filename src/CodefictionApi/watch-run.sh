#!/bin/bash
ng build --env=dev --app 0 --watch &
dotnet watch --verbose run