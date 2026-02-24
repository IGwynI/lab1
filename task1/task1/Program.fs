open System

let powers2 number =
    [
        for i in 0..number do
            yield pown 2 i
    ]

[<EntryPoint>]
let main _ =
    printfn "Введите до какой степени выводить степени числа 2"
    let number = int(Console.ReadLine())

    if number >= 0
    then
        printfn "Степени числа 2: "
        printfn "%A" (powers2 number)
    else
        printfn "Число должно быть неотрицательным."

    0