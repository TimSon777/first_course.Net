module hw5.App

open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.Logging
open Microsoft.Extensions.DependencyInjection
open Giraffe

open Calculator
open InOutData
open ErrorHandler

let parametersCalculatorHandler:HttpHandler =
    fun next ctx ->
        let expression = ctx.TryBindQueryString<InputExpression>()
        let parsedArgs = errorExpressionHandler expression
        match parsedArgs with
        | Ok outputExpression -> (setStatusCode 200 >=> json (calculate outputExpression)) next ctx
        | Error error -> (setStatusCode 400 >=> json error) next ctx
            
let webApp =
    choose [
        GET >=> choose [
                    route "/" >=> text "Welcome to the 5th version of the calculator"
                    route "/calculate" >=> parametersCalculatorHandler ]
        setStatusCode 404 >=> text "Not Found" ]

type Startup() =
    member _.ConfigureServices (services : IServiceCollection) =
        services.AddGiraffe() |> ignore

    member _.Configure (app : IApplicationBuilder)
                        (_ : IHostEnvironment)
                        (_ : ILoggerFactory) =
        app.UseGiraffe webApp
        
    static member CreateHostBuilder (args:string[]) =
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(
                fun webHostBuilder ->
                    webHostBuilder
                        .UseStartup<Startup>()
                        |> ignore)
             
[<EntryPoint>]
let main args =
    Startup.CreateHostBuilder(args).Build().Run()
    0
    