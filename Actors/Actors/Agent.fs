module Actors.Agents

open System

type Agent<'T> = MailboxProcessor<'T>

type message = End | Rectangle of int *int | Circle of float

let start() =
  Agent.Start(fun inbox ->
  let rec loop () = async {
    let! msg = inbox.Receive()
    match msg with 
    | End ->
      printfn "Bye"
      return()
    | Rectangle(width, height) ->
      printfn "Area is %O" (width * height)
      return! loop()
    | Circle(radius) ->
      printfn "Area is %O" (Math.PI * radius * radius)
      return! loop()
  }
  loop())

let pid = start()
pid.Post(Rectangle(10,3))
pid.Post(Circle(3.9))
pid.Post(End)
