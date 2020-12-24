#r @"./libs/Newtonsoft.Json.dll"
#r @"../../src/Farmer/bin/Debug/netstandard2.0/Farmer.dll"

open Farmer
open Farmer.Builders

let myFunctions = functions {
    name "isaacsuperfun"
}

let deployment =
    arm {
        location Location.NorthEurope
        add_resource myFunctions
        output "functionsPassword" myFunctions.PublishingPassword
        output "functionsAIKey" (myFunctions.AppInsightsKey |> Option.defaultValue ArmExpression.Empty)
        output "storageAccountKey" myFunctions.StorageAccountKey
    }

deployment.Deploy "my-resource-group-name"
