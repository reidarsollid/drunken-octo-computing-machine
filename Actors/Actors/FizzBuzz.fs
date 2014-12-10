for i in 1 .. 100 do
  match i with
    | x when x % 15 = 0 -> printfn "FizzBuzz"
    | x when x % 3 = 0 -> printfn "Fizz"
    | x when x % 5 = 0 -> printfn "Buzz"
    | x -> printfn "%i" i
