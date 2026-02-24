open System

let rec firstnumber number : int =
    if number / 10 = 0
    then  number
    else firstnumber (number/10)
    

[<EntryPoint>]
let main _ =
    printfn "Введите натуральное число"
    let number = int(Console.ReadLine())
    if number <= 0
    then
        printfn "Число не натуральное"
    else
        printfn "Первая цифра числа: %i" (firstnumber number)

    0